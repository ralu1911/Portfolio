using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Deteccion))]
[RequireComponent(typeof(NavMeshAgent))]

public class Comportamiento : MonoBehaviour
{

    #region Componentes
    private NavMeshAgent MF_NavAgent;
    private Deteccion MF_Deteccion;
    #endregion

    #region Movimiento
    [SerializeField] private Transform[] MP_PosicionesARecorrer;
    private bool[] MB_PosicionesBool;
    #endregion

    private void Awake()
    {
        MF_NavAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        InicializarBools();
    }




    // Update is called once per frame
    void Update()
    {
        PosicionInicial();
    }

    public void PosicionInicial()
    {
        for(int i = 0; i <= MP_PosicionesARecorrer.Length - 1 ; i++)
        {
            if ( MF_NavAgent.remainingDistance < 1.5 && MB_PosicionesBool[i] == true)
            {
                MF_NavAgent.destination = MP_PosicionesARecorrer[i].position;
                MB_PosicionesBool[i] = false;
                Debug.Log(i);
                if (i == MP_PosicionesARecorrer.Length - 1)
                {
                    HacerTrueBools();
                    Debug.Log("Entra");
                }
            }
        }
    }
    private void InicializarBools()
    {
        MB_PosicionesBool = new bool[MP_PosicionesARecorrer.Length];
        for(int i = 0; i < MB_PosicionesBool.Length; i++)
        {
            MB_PosicionesBool[i] = true;
        }
    }
    private void HacerTrueBools()
    {
        for (int i = 0; i < MB_PosicionesBool.Length; i++)
        {
            MB_PosicionesBool[i] = true;
        }
    }
         
}
