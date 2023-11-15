using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{

    private enum M_States {IDLE, ALERT, ATTACK};
    private M_States MS;
    #region Caracteristicas

    [SerializeField] private float MC_RangoDeteccionSonidoPie;
    [SerializeField] private float MC_RangoDeteccionSonidoAgachado;
    [SerializeField] private float MC_RangoDeteccionVisual;
    [SerializeField] private float MC_AnguloDeteccionVisual;

    #endregion
    #region Variables de la logica

    [SerializeField] private Transform MT_Cabeza;

    private Transform MT_objetivo;

    private RaycastHit[] MR_DeteccionSonidoPie;
    private RaycastHit[] MR_DeteccionSonidoAgachado;
    private RaycastHit[] MR_DeteccionVisual;
    private RaycastHit MR_DeteccionVisualRayo;


    #endregion
    #region Estados
    private bool MB_EnRango;
    #endregion


    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    //private void Deteccion_de_Sonido()
    //{
    //    MR_DeteccionSonidoAgachado = Physics.SphereCastAll(transform.position, MC_RangoDeteccionSonidoAgachado, Vector3.forward);
    //    MR_DeteccionSonidoPie = Physics.SphereCastAll(transform.position, MC_RangoDeteccionSonidoPie, Vector3.forward);
    //
    //    for (int i = 0; i < MR_DeteccionSonidoAgachado.Length -  1; i++)
    //    {
    //        if (MR_DeteccionSonidoAgachado[i].collider.GetComponent<IPlayer>()!= null)
    //        {
    //            
    //        }
    //    }
    //    for (int i = 0; i < MR_DeteccionSonidoPie.Length - 1; i++)
    //    {
    //        if (MR_DeteccionSonidoPie[i].collider.GetComponent<IPlayer>() != null)
    //        {
    //            
    //        }
    //    }
    //}
    public bool Deteccion_de_Visual(out Transform Objetivo)
    {
        MR_DeteccionVisual = Physics.SphereCastAll(transform.position, 50000, Vector3.forward);

        if (MR_DeteccionVisual.Length != 0 && MT_objetivo == null)
        {
            for (int i = 0; i <= MR_DeteccionVisual.Length - 1; i++)
            {

                if (MR_DeteccionVisual[i].collider.GetComponent<IPlayer>() != null)
                {
                    Debug.Log("te veo");
                    MT_objetivo = MR_DeteccionVisual[i].collider.GetComponentInChildren<Transform>();
                    Objetivo = MT_objetivo;
                }
            }
        }
        if (MT_objetivo != null)
        {
            bool rayo = Physics.Raycast(MT_Cabeza.position, MT_objetivo.position - MT_Cabeza.position, out MR_DeteccionVisualRayo, MC_RangoDeteccionVisual);
 
            Debug.DrawRay(MT_Cabeza.position, MT_objetivo.position - MT_Cabeza.position, Color.red);
            if (rayo == true)
            {
                if (MR_DeteccionVisualRayo.collider.GetComponent<IPlayer>() != null)
                {
                    Vector3 RayoEntreJugadores = MT_objetivo.position - MT_Cabeza.position;

                    if (Vector3.Angle(transform.forward, RayoEntreJugadores) < MC_AnguloDeteccionVisual)
                    {
                        Objetivo = MT_objetivo;
                        return true;
                    }
                }
            }
        }
        if(MT_objetivo != null)
        {
            Objetivo = MT_objetivo;
            return false;
        }
        Objetivo = null;
        return false;
    }




}
