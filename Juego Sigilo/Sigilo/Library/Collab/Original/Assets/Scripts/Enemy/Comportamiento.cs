using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Deteccion))]
[RequireComponent(typeof(NavMeshAgent))]

public class Comportamiento : MonoBehaviour , IEnemy
{

    #region Componentes
    private NavMeshAgent MF_NavAgent;
    private Deteccion MF_Deteccion;
    #endregion
    #region Movimiento
    [SerializeField] private Transform[] MP_PosicionesARecorrer;
    private int PosicionARecorrer;
    #endregion
    #region Estados
    private bool Muerto = false;
    #endregion

    private void Awake()
    {
        MF_NavAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        PosicionARecorrer = 0;
    }




    // Update is called once per frame
    void Update()
    {
        if(Muerto == true)
        {

        }
        else
        {
            PosicionInicial();
        }
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

    public void IEnemyDamage()
    {
        Muerto = true;
    }
    public void IEnemyDeteccion()
    {

    }
}
