using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour , IPlayer
{
    [Header("Gravity")]
    [SerializeField] float gravity = -9.8f;
    [Header("Movement")]    
    [SerializeField] float forwardSpeed = 5;
    [SerializeField] float sideSpeed = 2;
    [SerializeField] float stickToGroundSpeed = -3;
    [Header("Jump")]
    [SerializeField] float jumpSpeed = 5;
    [SerializeField] bool useJumpAnimEvent = true;
    [SerializeField] float endJumpRaycastDistance = 3;
    [SerializeField] float TiempoDeSalto;
    [Header("Sliding")]
    [SerializeField] float slideSlope = 45;
    [SerializeField] float slideSpeed = 6;
    [SerializeField] float slideSlowdonTime = 2;
    [SerializeField] AnimationCurve slideSlowDownCurve = AnimationCurve.EaseInOut(0,1,1,0);
    [SerializeField] Transform cameraTransform;

    Animator P_a;
    CharacterController P_cc;

    Vector3 playerVelocity;
    float verticalVelocity;
    Vector3 slideVelocity;

    bool ApplyForce = false;
    bool HasJump = false;
    bool jumping;
    bool jumpEnded = true;
    bool waitingForJumpAnimEvent;
    bool isCrouching = false;

    bool sliding;
    float slidingTime;
    float slidePlayerVelocityFactor = 1;
    float TiempoSalto;

    public bool useRootMotion = true;


    

    // Start is called before the first frame update
    void Start()
    {
        P_cc = GetComponent<CharacterController>();
        P_a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TiempoSalto += Time.deltaTime;
        UpdatePlayerVelocity();
        UpdateVerticalVelocity();
        UpdatePlayerStance();
        UpdatePlayerAttack();
        UpdateSlideVelocity();

        ApplyTotalVelocity();
        
        UpdateRotation();
    }
    public void UpdatePlayerStance()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching == false)
            {
                isCrouching = true;
                Debug.Log("TRUE");
                P_a.SetBool("isCrouching", true);
            }

            else if (isCrouching == true)
            {
                isCrouching = false;
                Debug.Log("False");
                P_a.SetBool("isCrouching", false);
            }

        }        
    }
    public void UpdatePlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            P_a.SetTrigger("attack");
        }
    }

    private void ApplyTotalVelocity()
    {
        // Muevo al personaje combinando los ejes de movimiento (XZ e Y)
        // en una única llamada para que detecte el suelo y colisiones correctamente
        Vector3 totalVelocity = playerVelocity * slidePlayerVelocityFactor + slideVelocity + Vector3.up * verticalVelocity;
        Debug.DrawRay(this.transform.position, Vector3.ProjectOnPlane(totalVelocity, Vector3.up), Color.magenta, 3);
        if (jumping || !useRootMotion)
        {
            P_cc.Move(totalVelocity * Time.deltaTime);
        }
    }

    private void UpdateRotation()
    {
        
    }

    private void UpdatePlayerVelocity()
    {
        // Accedo al input de las flechas
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Combino el input y lo normalizo para que no se mueve más rápido en diagonal
        Vector3 input = new Vector3(xInput, 0, zInput);
        if (input.magnitude > 1) { input.Normalize(); }
        input = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * input;
        
        // Calculo la velocidad y la convierto a local al personaje
        Vector3 localPlayerVelocity = new Vector3(input.x * sideSpeed, 0, input.z * forwardSpeed);
        playerVelocity = localPlayerVelocity;

        // Le paso al animator la velocidad de movimiento del personaje en cada eje
        P_a.SetFloat("zSpeed", localPlayerVelocity.z);
        P_a.SetFloat("xSpeed", localPlayerVelocity.x);
    }

    private void UpdateVerticalVelocity()
    {
        // Si pulso espacio, activo la animación de salto. Esta debe tener un evento Jump que producirá el salto.
        if (Input.GetKeyDown(KeyCode.Space) && P_cc.isGrounded && !sliding && !jumping && !waitingForJumpAnimEvent)
        {
            jumping = true;            
            jumpEnded = false;
            TiempoSalto = 0;

            P_a.SetTrigger("jump");
            waitingForJumpAnimEvent = useJumpAnimEvent;
            ApplyForce = true;
        }
        if (!waitingForJumpAnimEvent && ApplyForce == true && TiempoDeSalto <= TiempoSalto)
        {
            ApplyForce = false;
            HasJump = true;
            verticalVelocity = jumpSpeed;
            slidingTime = slideSlowdonTime;
        }
        // Si no estoy saltando, y estoy en el suelo, reseteo la velocidad
        // a un valor negativo pequeño, para mantenerme pegado al suelo
        if (!waitingForJumpAnimEvent && jumpEnded && verticalVelocity < 0 && P_cc.isGrounded)
        {
            jumping = false;            
            verticalVelocity = stickToGroundSpeed;
        }

        // Calculo si debería empezar a reproducir la animación de final de salto
        if (jumping && !jumpEnded && HasJump == true && !waitingForJumpAnimEvent && verticalVelocity < 0)
        {
            if(Physics.Raycast(transform.position, Vector3.down, endJumpRaycastDistance))
            {
                jumpEnded = true;
                HasJump = false;
                P_a.SetTrigger("endJump");                
            }            
        }

        // En todo momento, aplico la gravedad reduciendo la velocidad en Y
        verticalVelocity += gravity * Time.deltaTime;
    }

   
    void JumpAnimEvent()
    {        
        if(waitingForJumpAnimEvent) { 
            verticalVelocity = jumpSpeed;
            slidingTime = slideSlowdonTime;
            waitingForJumpAnimEvent = false; 
        }
    }

    private void UpdateSlideVelocity()
    {
        bool currentlySliding = sliding;
        Vector3 maxSlideVelocity = Vector3.zero;
        RaycastHit hitInfo;
        if (!jumping && P_cc.isGrounded && Physics.SphereCast(this.transform.position + P_cc.center, 0.5f, Vector3.down, out hitInfo))
        {
            float angle = Vector3.Angle(hitInfo.normal, Vector3.up);
            print(angle);
            if (angle > slideSlope)
            {
                currentlySliding = true;
                
                Vector3 slideDirection = Vector3.ProjectOnPlane(Vector3.down, hitInfo.normal).normalized;
                maxSlideVelocity = slideDirection * slideSpeed;

                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.blue, 3);
                Debug.DrawRay(hitInfo.point, slideDirection, Color.red, 3);
            }
            else
            {
                currentlySliding = false;
                slidingTime = 0;
            }
        }

        if(sliding && currentlySliding) { slidingTime += Time.deltaTime; }
        sliding = currentlySliding;        

        slideVelocity = sliding 
            ? Vector3.Lerp(slideVelocity, maxSlideVelocity, Time.deltaTime * 3) 
            : Vector3.Lerp(slideVelocity, Vector3.zero, Time.deltaTime * 5);

        slidePlayerVelocityFactor = sliding
            ? slideSlowDownCurve.Evaluate(Mathf.Clamp01(slidingTime / slideSlowdonTime))
            : Mathf.Lerp(slidePlayerVelocityFactor, 1, 10 * Time.deltaTime);        

    }

    private void OnAnimatorMove()
    {
        if(!jumping && useRootMotion)
        {
            Vector3 rootMotionMove = P_a.rootPosition - this.transform.position;
            Vector3 totalMovement = rootMotionMove * slidePlayerVelocityFactor + slideVelocity * Time.deltaTime + Vector3.up * verticalVelocity * Time.deltaTime;
            P_cc.Move(totalMovement);

            this.transform.rotation = P_a.rootRotation;
        }        
    }
    public void IPlayerAction(PlayerControl Player)
    {

    }
}
