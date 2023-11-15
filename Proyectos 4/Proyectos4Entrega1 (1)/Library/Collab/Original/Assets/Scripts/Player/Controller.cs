using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Controller : MonoBehaviour, IPlayer
{
    private  CharacterController         m_charCtrl;
    private  Animator                    m_animator;
    private  IEnemy                      m_attackedEnemy;

    public Transform            m_cameraTransform;

    [SerializeField] private       float      walkSpeed;
    [SerializeField] private       float      runSpeed;
    [SerializeField] private       float      crouchSpeed;
    [SerializeField] private       float      jumpForce;
    [SerializeField] private       float      acceleration;
    [SerializeField] private       float      attackDistance;
    

    [SerializeField] private       LayerMask  GetUpRaycastLayers;
    [SerializeField] private       LayerMask  AttackRaycastLayers;

    RaycastHit hitInfo;

    private    float            zInput;
    private    float            xInput;
    private    float            speedInput;
    private    float            ySpeed;
    private    float            currentSpeed;
              
              
    private    bool             isCrouched = false;
    private    bool             hasJumped = false;
    private    bool             isGrounded;
    private    bool             beenCaught;

    Vector3 velocity;

    private GameObject ObjetoALanzar;




    public void Crouching ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouched == false)
            {
                Debug.Log(isCrouched);

                isCrouched = true;
                m_charCtrl.height = 1;
                m_charCtrl.center = new Vector3(0, 0.555f, 0);
                speedInput = crouchSpeed;
            }

            
            else
            {
                if(Physics.Raycast(this.transform.position + Vector3.up* 0.5f, Vector3.up, 2f, 0 ))
                {
                    Debug.Log("Hit");
                }

                else if (!Physics.SphereCast(this.transform.position + Vector3.up, 0.1f, Vector3.up, out hitInfo, GetUpRaycastLayers))
                {
                    Debug.Log(isCrouched);
                    isCrouched = false;
                    m_charCtrl.height = 2;
                    m_charCtrl.center = new Vector3(0, 1.055f, 0);
                    speedInput = walkSpeed;
                }              
            }
        }

    }
    public void Jumping ()
    {
        if (m_charCtrl.isGrounded & Input.GetButton("Jump"))
        {
            ySpeed = jumpForce;
            m_animator.SetBool("isJumping", true);
            hasJumped = true;
            Debug.Log(m_charCtrl.isGrounded);
        }

    }


    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) & !hasJumped)
        {
            m_animator.SetTrigger("attack");
            Physics.SphereCast(this.transform.position + Vector3.forward * attackDistance, attackDistance, Vector3.forward, out RaycastHit attackHitInfo, AttackRaycastLayers);
            if (attackHitInfo.collider.GetComponent<IEnemy>() != null)
            {
                attackHitInfo.collider.GetComponent<IEnemy>().IEnemyDamage();
            }
        }     
    }

    public void CheckJumpState ()
    {
        if (hasJumped == true & m_charCtrl.isGrounded)
        {
            hasJumped = false;
            isGrounded = true;
            m_animator.SetBool("isGrounded", true);
        }
        if (m_charCtrl.isGrounded)
        {
            ySpeed = 0;
            isGrounded = true;
            hasJumped = false;
            m_animator.SetBool("isGrounded", true);
            m_animator.SetBool("isJumping", false);
            m_animator.SetBool("isFalling", false);
        }

        else
        {
            m_animator.SetBool("isGrounded", false);
            isGrounded = false;

            if ((hasJumped && (ySpeed > 0)) || (ySpeed < -2))
            {
                m_animator.SetBool("isFalling", true);
            }

        }
    }
    public void IPlayerAction(PlayerControl Player)
    {

    }
    public void Lanzamiento()
    {
        GameObject Piedra = Instantiate(ObjetoALanzar);
        Piedra.transform.rotation = transform.rotation;
    }

    private void Awake()
    {
        m_charCtrl = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(xInput, 0, zInput);

        Crouching();
        Attack();
        Jumping();

        m_animator.SetBool("isCrouching", isCrouched);

       
       if (isGrounded == false)
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }
     

        if ((Input.GetKey(KeyCode.LeftShift)) & !isCrouched)
        {
            speedInput = runSpeed;
        }

        else if (!isCrouched)
        {
            speedInput = walkSpeed;
        }

        if (isCrouched)
        {
            speedInput = crouchSpeed;
        }

        movementDirection = Quaternion.AngleAxis(m_cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        currentSpeed = Mathf.Lerp(currentSpeed, speedInput, Time.deltaTime * acceleration);

        m_animator.SetFloat("zSpeed", zInput * currentSpeed);
        m_animator.SetFloat("xSpeed", xInput * currentSpeed);

        velocity = movementDirection * currentSpeed;

        velocity.y = ySpeed;
        
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            velocity = Vector3.zero;
        }

        m_charCtrl.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Vector3 cameraDirection = m_cameraTransform.forward;
            cameraDirection.y = 0;
            transform.forward = cameraDirection;
        }

        
        CheckJumpState();

    }
    public bool ComprobarAgachado()
    {
        return isCrouched;
    }
}
   
