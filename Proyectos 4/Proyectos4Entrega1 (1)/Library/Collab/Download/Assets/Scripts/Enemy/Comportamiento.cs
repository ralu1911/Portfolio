using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Deteccion))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Comportamiento : MonoBehaviour, IEnemy
{

    #region Componentes
    private NavMeshAgent MF_NavAgent;
    private Deteccion MF_Deteccion;
    private Animator MF_Animator;
    private CapsuleCollider MF_collider;
    #endregion
    #region Movimiento
    [SerializeField] private Transform[] MP_PosicionesARecorrer;
    private int PosicionARecorrer;
    #endregion
    #region Estados
    private bool MB_muerto = false;
    private bool MB_alerta = false;
    private bool MB_eliminacion = false;
    private bool MB_piedra = false;
    private bool MB_mirar = false;
    #endregion
    #region Deteccion
    private float MT_deteccion;
    #endregion
    private Transform protagonista;

    private void Awake()
    {
        MF_NavAgent = GetComponent<NavMeshAgent>();
        MF_Deteccion = GetComponent<Deteccion>();
        MF_Animator = GetComponent<Animator>();
        MF_collider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        PosicionARecorrer = 0;

    }





    // Update is called once per frame
    void Update()
    {
        MF_Animator.SetFloat("zSpeed", MF_NavAgent.velocity.magnitude);
        if (MB_eliminacion == false && MB_muerto == false)
        {
            Persecucion();
        }
        if (MB_muerto == true)
        {

        }
        else if (MB_alerta == true && MB_mirar == true)
        {
            transform.LookAt(protagonista);
            MF_NavAgent.SetDestination(transform.position);
        }
        else if (MB_piedra == true)
        {
            if (MF_NavAgent.pathPending == false && MF_NavAgent.remainingDistance < 0.2)
            {
                Invoke("Volver", 1);
            }
        }
        else
        {
            MF_NavAgent.speed = 3.5f;
            PosicionInicial();
        }
    }

    public void GetKnockedOut()
    {
        
    }
    public void PosicionInicial()
    {
        if ( MF_NavAgent.remainingDistance < 1 && MF_NavAgent.pathPending == false)
        {
            PosicionARecorrer++;
            if (PosicionARecorrer >= MP_PosicionesARecorrer.Length)
            {
                PosicionARecorrer = 0;
            }
            MF_NavAgent.SetDestination(MP_PosicionesARecorrer[PosicionARecorrer].position);
        }
    }
    public void Persecucion()
    {
        if (MF_Deteccion.Deteccion_de_Visual(out protagonista) == true)
        {
            MB_alerta = true;
            MB_mirar = true;
            MT_deteccion += Time.deltaTime;
        }
        else if (MT_deteccion >= 0)
        {
            MT_deteccion -= Time.deltaTime;
        }

        if(MT_deteccion < 6 && MF_Deteccion.Deteccion_de_Visual(out protagonista) == false)
        {
            MB_alerta = false;
        }
        if ((MT_deteccion >= 3 && protagonista.GetComponent<Controller>().ComprobarAgachado() == false) || ((MT_deteccion >= 6 && protagonista.GetComponent<Controller>().ComprobarAgachado() == true)))
        {
            MB_mirar = false;
            MF_NavAgent.speed = 8;
            MF_NavAgent.SetDestination(protagonista.position);
            if (MF_NavAgent.remainingDistance < 1 && MF_NavAgent.pathPending == false)
            {
                MB_eliminacion = true;
                MB_alerta = false;
                MF_NavAgent.SetDestination(protagonista.position);
                Golpear();
                SceneManager.LoadScene("w");
            }
        }
    
        
    }
    public void Golpear()
    {
        MF_Animator.SetTrigger("attack");
    }


    public void IEnemyDamage()
    {
        MB_muerto = true;
        MF_Animator.SetBool("Muerte", true);
        MF_collider.isTrigger = true;
        MF_NavAgent.SetDestination(transform.position);
    }
    public void IEnemyDeteccion(Vector3 posicion)
    {
        MF_NavAgent.SetDestination(posicion);
        MB_piedra = true;
        
    }
    private void Volver()
    {
        MB_piedra = false;
    }
}
