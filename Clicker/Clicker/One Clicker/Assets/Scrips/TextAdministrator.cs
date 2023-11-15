using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAdministrator : MonoBehaviour
{
    private GameManager Manager;
    private Mercado m_mercado;
    private Trampas m_trampa;

    [SerializeField] private Text t_Puntos1;
    [SerializeField] private Text t_Puntos2;
    [SerializeField] private Text t_Puntos3;
    [SerializeField] private Text t_Puntos4;
    [SerializeField] private Text t_dinero;


    [SerializeField] private GameObject Productos;
    [SerializeField] private GameObject Venta;
    [SerializeField] private GameObject Competencia;
    [SerializeField] private GameObject Victoria;
    [SerializeField] private GameObject Mejoras;
    [SerializeField] private GameObject Derrota;


    [SerializeField] private Text t_precio;
    [SerializeField] private Text t_precio2;
    [SerializeField] private Text t_precio3;
    [SerializeField] private Text t_precio4;


    [SerializeField] private Text AS;
    [SerializeField] private Text BS;
    [SerializeField] private Text CS;
    [SerializeField] private Text DS;

    [SerializeField] private Text AH;
    [SerializeField] private Text BH;
    [SerializeField] private Text CH;
    [SerializeField] private Text DH;

    [SerializeField] private Text ACar;
    [SerializeField] private Text BCar;
    [SerializeField] private Text CCar;
    [SerializeField] private Text DCar;

    [SerializeField] private Text ACasa;
    [SerializeField] private Text BCasa;
    [SerializeField] private Text CCasa;
    [SerializeField] private Text DCasa;


    [SerializeField] private Text SA;
    [SerializeField] private Text HA;
    [SerializeField] private Text COA;
    [SerializeField] private Text CAA;
    [SerializeField] private Text ELA;



    // Start is called before the first frame update
    private void Awake()
    {
        Manager = GetComponent<GameManager>();
        m_mercado = GetComponent<Mercado>();
        m_trampa = GetComponent<Trampas>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_trampa.GameOver == true)
        {
            CambiarADerrota();
        }
        if (Manager.m_dinero >= 1000000)
        {
            CambiarAVictoria();
        }
        ActualizacionDelTexto();
    }
    public void ActualizacionDelTexto()
    {
        t_Puntos1.text = Manager.C_Puntos().ToString();
        t_Puntos2.text = Manager.C_Puntos2().ToString();
        t_Puntos3.text = Manager.C_Puntos3().ToString();
        t_Puntos4.text = Manager.C_Puntos4().ToString();
        t_dinero.text = Manager.m_dinero.ToString();
        t_precio.text = m_mercado.MercadoPuntos().ToString();
        if (Venta.gameObject.active == true)
        {
            t_precio.text = m_mercado.MercadoPuntos().ToString();
            t_precio2.text = m_mercado.MercadoPuntos2().ToString();
            t_precio3.text = m_mercado.MercadoPuntos3().ToString();
            t_precio4.text = m_mercado.MercadoPuntos4().ToString();
        }
        if (Mejoras.active == true)
        {
            if (AS.gameObject.active == true)
            {
                AS.text = Manager.PrecioAutomaticoCP1.ToString();
            }
            if (AH.gameObject.active == true)
            {
                AH.text = Manager.PrecioAutomaticoCP2.ToString();
            }
            if (ACar.gameObject.active == true)
            {
                ACar.text = Manager.PrecioAutomaticoCP3.ToString();
            }
            if (ACasa.gameObject.active == true)
            {
                ACasa.text = Manager.PrecioAutomaticoCP4.ToString();
            }

            BS.text = Manager.BajadaDeTiempoAutomticoCP1.ToString();
            BH.text = Manager.BajadaDeTiempoAutomticoCP2.ToString();
            BCar.text = Manager.BajadaDeTiempoAutomticoCP3.ToString();
            BCasa.text = Manager.BajadaDeTiempoAutomticoCP4.ToString();


            CS.text = Manager.SubidaDePuntosAutomticoCP1.ToString();
            CH.text = Manager.SubidaDePuntosAutomticoCP2.ToString();
            CCar.text = Manager.SubidaDePuntosAutomticoCP3.ToString();
            CCasa.text = Manager.SubidaDePuntosAutomticoCP4.ToString();


            DS.text = Manager.SubidaDeCantidadCP1.ToString();
            DH.text = Manager.SubidaDeCantidadCP2.ToString();
            DCar.text = Manager.SubidaDeCantidadCP3.ToString();
            DCasa.text = Manager.SubidaDeCantidadCP4.ToString();
        }
        if (m_trampa.gameObject.active == true)
        {
            SA.text = m_trampa.PrecioSubida1.ToString();
            HA.text = m_trampa.PrecioSubida2.ToString();
            COA.text = m_trampa.PrecioSubida3.ToString();
            CAA.text = m_trampa.PrecioSubida4.ToString();
            ELA.text = m_trampa.PrecioBajadaCorrupcion.ToString();
        }

    }
    public void CambiarAProductos()
    {
        Productos.SetActive(true);
        Mejoras.SetActive(false);
        Competencia.SetActive(false);
        Venta.SetActive(false);
    }
    public void CambiarAVentas()
    {
        Productos.SetActive(false);
        Mejoras.SetActive(false);
        Competencia.SetActive(false);
        Venta.SetActive(true);
    }
    public void CambiarACompetencia()
    {
        Productos.SetActive(false);
        Mejoras.SetActive(false);
        Competencia.SetActive(true);
        Venta.SetActive(false);
    }
    public void CambiarAMejoras()
    {
        Productos.SetActive(false);
        Mejoras.SetActive(true);
        Competencia.SetActive(false);
        Venta.SetActive(false);
    }
    public void CambiarAVictoria()
    {
        Productos.SetActive(false);
        Mejoras.SetActive(false);
        Competencia.SetActive(false);
        Venta.SetActive(false);
        Victoria.SetActive(true);
    }
    public void CambiarADerrota()
    {
        Productos.SetActive(false);
        Mejoras.SetActive(false);
        Competencia.SetActive(false);
        Venta.SetActive(false);
        Derrota.SetActive(true);
    }

}
