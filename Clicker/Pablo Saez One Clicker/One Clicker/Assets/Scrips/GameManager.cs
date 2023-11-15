using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float m_dinero;

    private float m_Puntos;

    private bool CP1_X2;
    private bool CP1_X4;
    private bool CP1_X8;
    private bool CP1_X16;

    private float m_Multiplicador;

    [SerializeField] private float WS_Puntos;
    [SerializeField] private float WS_Tiempo;

    public float PrecioAutomaticoCP1;
    public float SubidaDePuntosAutomticoCP1;
    public float BajadaDeTiempoAutomticoCP1;
    public float SubidaDeCantidadCP1;


    private float m_Puntos2;

    private bool CP2_X2;
    private bool CP2_X4;
    private bool CP2_X8;
    private bool CP2_X16;

    private float m_Multiplicador2;

    [SerializeField] private float WS_Puntos2;
    [SerializeField] private float WS_Tiempo2;

    public float PrecioAutomaticoCP2;
    public float SubidaDePuntosAutomticoCP2;
    public float BajadaDeTiempoAutomticoCP2;
    public float SubidaDeCantidadCP2;



    private float m_Puntos3;

    private bool CP3_X2;
    private bool CP3_X4;
    private bool CP3_X8;
    private bool CP3_X16;

    private float m_Multiplicador3;

    [SerializeField] private float WS_Puntos3;
    [SerializeField] private float WS_Tiempo3;

    public float PrecioAutomaticoCP3;
    public float SubidaDePuntosAutomticoCP3;
    public float BajadaDeTiempoAutomticoCP3;
    public float SubidaDeCantidadCP3;



    private float m_Puntos4;

    private bool CP4_X2;
    private bool CP4_X4;
    private bool CP4_X8;
    private bool CP4_X16;

    private float m_Multiplicador4;

    [SerializeField] private float WS_Puntos4;
    [SerializeField] private float WS_Tiempo4;

    public float PrecioAutomaticoCP4;
    public float SubidaDePuntosAutomticoCP4;
    public float BajadaDeTiempoAutomticoCP4;
    public float SubidaDeCantidadCP4;

    private Mercado M_mercado;
    // Start is called before the first frame update
    private void Awake()
    {
        M_mercado = GetComponent<Mercado>();
        
    }
    void Start()
    {
        m_Multiplicador = 1;
        m_Multiplicador2 = 1;
        m_Multiplicador3= 1;
        m_Multiplicador4 = 1;
        m_Puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SumarPuntos()
    {
        m_Puntos = m_Puntos + 1 * Multiplicadores_Temporales();
        int Num = Random.Range(0, 30);
        if (Num > 10 && Num <= 14)
        {
            CP1_X2 = true;
            Invoke("Desactivar_Multiplicadores_Temporales", 3);
        }
        if (Num > 14 && Num <= 17)
        {
            CP1_X4 = true;
            Invoke("Desactivar_Multiplicadores_Temporales", 3);
        }
        if (Num > 17 && Num < 19)
        {
            CP1_X8 = true;
            Invoke("Desactivar_Multiplicadores_Temporales", 3);
        }
        if (Num == 20)
        {
            CP1_X16 = true;
            Invoke("Desactivar_Multiplicadores_Temporales", 3);
        }
    }
    public float Multiplicadores_Temporales()
    {
        float MultyFinal;
        if(CP1_X2 == true)
        {
            return MultyFinal = m_Multiplicador * 2;
        }
        if (CP1_X4 == true)
        {
            return MultyFinal = m_Multiplicador * 4;
        }
        if (CP1_X8 == true)
        {
            return MultyFinal = m_Multiplicador * 8;
        }
        if (CP1_X16 == true)
        {
            return MultyFinal = m_Multiplicador * 16;
        }
        return MultyFinal = m_Multiplicador;
    }
    public void Desactivar_Multiplicadores_Temporales()
    {
        if (CP1_X2 == true)
        {   
            CP1_X2 = false;
        }   
        if (CP1_X4 == true)
        {   
            CP1_X4 = false;
        }   
        if (CP1_X8 == true)
        {   
            CP1_X8 = false;
        }   
        if (CP1_X16 == true)
        {   
            CP1_X16 = false;
        }
    }

    public void VenderCP1()
    {
        if (m_Puntos > 0)
        {
            m_dinero = m_dinero + M_mercado.VenderPuntos(m_Puntos);
            m_Puntos = 0;
        }   
    }

    public float C_Puntos()
    {
        return m_Puntos;
    }

    public void ModificacionMultiplicador(float aumento)
    {
        m_Multiplicador = m_Multiplicador + aumento;
    }

    public void ComprarAutomatico()
    {
        if (PrecioAutomaticoCP1 < m_dinero)
        {
            m_dinero = m_dinero - PrecioAutomaticoCP1;
            StartCoroutine(AutomaticoCP1());
        }
    }

    public IEnumerator AutomaticoCP1()
    {
        yield return new WaitForSeconds(WS_Tiempo);
        m_Puntos = m_Puntos + WS_Puntos;
        StartCoroutine(AutomaticoCP1());
    }

    public void A_CP1()
    {
        if (SubidaDePuntosAutomticoCP1 < m_dinero)
        {
            m_dinero = m_dinero - SubidaDePuntosAutomticoCP1;
            SubidaDePuntosAutomticoCP1 = SubidaDePuntosAutomticoCP1 * 2;
            AumentarCP1();
        }
    }
    public void D_CP1()
    {
        if (BajadaDeTiempoAutomticoCP1 < m_dinero)
        {
            m_dinero = m_dinero - BajadaDeTiempoAutomticoCP1;
            BajadaDeTiempoAutomticoCP1 = BajadaDeTiempoAutomticoCP1 * 2;
            DisminuirCP1();
        }
    }


    public void AumentarCP1()
    {
        WS_Puntos = WS_Puntos * 1.5f;
    }
    public void DisminuirCP1()
    {
        WS_Tiempo = WS_Tiempo / 1.5f;
    }
    public void AumentarProducion()
    {
        if(SubidaDeCantidadCP1 <= m_dinero)
        {
            m_dinero = m_dinero - SubidaDeCantidadCP1;
            m_Multiplicador = m_Multiplicador * 2;
            SubidaDeCantidadCP1 = SubidaDeCantidadCP1 * 2;
        }
    }





    public void SumarPuntos2()
    {
        m_Puntos2 = m_Puntos2 + 1 * Multiplicadores_Temporales2();
        int Num = Random.Range(0, 30);
        if (Num > 10 && Num <= 14)
        {
            CP2_X2 = true;
            Invoke("Desactivar_Multiplicadores_Temporales2", 3);
        }
        if (Num > 14 && Num <= 17)
        {
            CP2_X4 = true;
            Invoke("Desactivar_Multiplicadores_Temporales2", 3);
        }
        if (Num > 17 && Num < 19)
        {
            CP2_X8 = true;
            Invoke("Desactivar_Multiplicadores_Temporales2", 3);
        }
        if (Num == 20)
        {
            CP2_X16 = true;
            Invoke("Desactivar_Multiplicadores_Temporales2", 3);
        }
    }
    public float Multiplicadores_Temporales2()
    {
        float MultyFinal;
        if (CP2_X2 == true)
        {
            return MultyFinal = m_Multiplicador2 * 2;
        }
        if (CP2_X4 == true)
        {
            return MultyFinal = m_Multiplicador2 * 4;
        }
        if (CP2_X8 == true)
        {
            return MultyFinal = m_Multiplicador2 * 8;
        }
        if (CP2_X16 == true)
        {
            return MultyFinal = m_Multiplicador2 * 16;
        }
        return MultyFinal = m_Multiplicador2;
    }
    public void Desactivar_Multiplicadores_Temporales2()
    {
        if (CP2_X2 == true)
        {   
            CP2_X2 = false;
        }   
        if (CP2_X4 == true)
        {   
            CP2_X4 = false;
        }   
        if (CP2_X8 == true)
        {   
            CP2_X8 = false;
        }   
        if (CP2_X16 == true)
        {   
            CP2_X16 = false;
        }
    }

    public void VenderCP2()
    {
        if (m_Puntos2 > 0)
        {
            m_dinero = m_dinero + M_mercado.VenderPuntos2(m_Puntos2);
            m_Puntos2 = 0;
        }
    }

    public float C_Puntos2()
    {
        return m_Puntos2;
    }

    public void ModificacionMultiplicador2(float aumento)
    {
        m_Multiplicador2 = m_Multiplicador2 + aumento;
    }

    public void ComprarAutomatico2()
    {
        if (PrecioAutomaticoCP2 < m_dinero)
        {
            m_dinero = m_dinero - PrecioAutomaticoCP2;
            StartCoroutine(AutomaticoCP2());
        }
    }

    public IEnumerator AutomaticoCP2()
    {
        yield return new WaitForSeconds(WS_Tiempo2);
        m_Puntos2 = m_Puntos2 + WS_Puntos2;
        StartCoroutine(AutomaticoCP2());
    }

    public void A_CP2()
    {
        if (SubidaDePuntosAutomticoCP2 < m_dinero)
        {
            m_dinero = m_dinero - SubidaDePuntosAutomticoCP2;
            SubidaDePuntosAutomticoCP2 = SubidaDePuntosAutomticoCP2 * 2;
            AumentarCP2();
        }
    }
    public void D_CP2()
    {
        if (BajadaDeTiempoAutomticoCP2 < m_dinero)
        {
            m_dinero = m_dinero - BajadaDeTiempoAutomticoCP2;
            BajadaDeTiempoAutomticoCP2 = BajadaDeTiempoAutomticoCP2 * 2;
            DisminuirCP2();
        }
    }


    public void AumentarCP2()
    {
        WS_Puntos2 = WS_Puntos2 * 1.5f;
    }
    public void DisminuirCP2()
    {
        WS_Tiempo2 = WS_Tiempo2 / 1.5f;
    }
    public void AumentarProducion2()
    {
        if (SubidaDeCantidadCP2 <= m_dinero)
        {
            m_dinero = m_dinero - SubidaDeCantidadCP2;
            m_Multiplicador2 = m_Multiplicador2 * 2;
            SubidaDeCantidadCP2 = SubidaDeCantidadCP2 * 2;
        }
    }







    public void SumarPuntos3()
    {
        m_Puntos3 = m_Puntos3 + 1 * Multiplicadores_Temporales3();
        int Num = Random.Range(0, 30);
        if (Num > 10 && Num <= 14)
        {
            CP3_X2 = true;
            Invoke("Desactivar_Multiplicadores_Temporales3", 3);
        }
        if (Num > 14 && Num <= 17)
        {
            CP3_X4 = true;
            Invoke("Desactivar_Multiplicadores_Temporales3", 3);
        }
        if (Num > 17 && Num < 19)
        {
            CP3_X8 = true;
            Invoke("Desactivar_Multiplicadores_Temporales3", 3);
        }
        if (Num == 20)
        {
            CP3_X16 = true;
            Invoke("Desactivar_Multiplicadores_Temporales3", 3);
        }
    }
    public float Multiplicadores_Temporales3()
    {
        float MultyFinal;
        if (CP3_X2 == true)
        {
            return MultyFinal = m_Multiplicador3 * 2;
        }
        if (CP3_X4 == true)
        {
            return MultyFinal = m_Multiplicador3 * 4;
        }
        if (CP3_X8 == true)
        {
            return MultyFinal = m_Multiplicador3 * 8;
        }
        if (CP3_X16 == true)
        {
            return MultyFinal = m_Multiplicador3 * 16;
        }
        return MultyFinal = m_Multiplicador3;
    }
    public void Desactivar_Multiplicadores_Temporales3()
    {
        if (CP3_X2 == true)
        {
            CP3_X2 = false;
        }
        if (CP3_X4 == true)
        {
            CP3_X4 = false;
        }
        if (CP3_X8 == true)
        {
            CP3_X8 = false;
        }
        if (CP3_X16 == true)
        {
            CP3_X16 = false;
        }
    }

    public void VenderCP3()
    {
        if (m_Puntos3 > 0)
        {
            m_dinero = m_dinero + M_mercado.VenderPuntos3(m_Puntos3);
            m_Puntos3 = 0;
        }
    }

    public float C_Puntos3()
    {
        return m_Puntos3;
    }

    public void ModificacionMultiplicador3(float aumento)
    {
        m_Multiplicador3 = m_Multiplicador3 + aumento;
    }

    public void ComprarAutomatico3()
    {
        if (PrecioAutomaticoCP3 < m_dinero)
        {
            m_dinero = m_dinero - PrecioAutomaticoCP3;
            StartCoroutine(AutomaticoCP3());
        }
    }

    public IEnumerator AutomaticoCP3()
    {
        yield return new WaitForSeconds(WS_Tiempo3);
        m_Puntos3 = m_Puntos3 + WS_Puntos3;
        StartCoroutine(AutomaticoCP3());
    }

    public void A_CP3()
    {
        if (SubidaDePuntosAutomticoCP3 < m_dinero)
        {
            m_dinero = m_dinero - SubidaDePuntosAutomticoCP3;
            SubidaDePuntosAutomticoCP3 = SubidaDePuntosAutomticoCP3 * 2;
            AumentarCP3();
        }
    }
    public void D_CP3()
    {
        if (BajadaDeTiempoAutomticoCP3 < m_dinero)
        {
            m_dinero = m_dinero - BajadaDeTiempoAutomticoCP3;
            BajadaDeTiempoAutomticoCP3 = BajadaDeTiempoAutomticoCP3 * 2;
            DisminuirCP3();
        }
    }


    public void AumentarCP3()
    {
        WS_Puntos3 = WS_Puntos3 * 1.5f;
    }
    public void DisminuirCP3()
    {
        WS_Tiempo3 = WS_Tiempo3 / 1.5f;
    }
    public void AumentarProducion3()
    {
        if (SubidaDeCantidadCP3 <= m_dinero)
        {
            m_dinero = m_dinero - SubidaDeCantidadCP3;
            m_Multiplicador3 = m_Multiplicador3 * 2;
            SubidaDeCantidadCP3 = SubidaDeCantidadCP3 * 2;
        }
    }






    public void SumarPuntos4()
    {
        m_Puntos4 = m_Puntos4 + 1 * Multiplicadores_Temporales4();
        int Num = Random.Range(0, 30);
        if (Num > 10 && Num <= 14)
        {
            CP4_X2 = true;
            Invoke("Desactivar_Multiplicadores_Temporales4", 3);
        }
        if (Num > 14 && Num <= 17)
        {
            CP4_X4 = true;
            Invoke("Desactivar_Multiplicadores_Temporales4", 3);
        }
        if (Num > 17 && Num < 19)
        {
            CP4_X8 = true;
            Invoke("Desactivar_Multiplicadores_Temporales4", 3);
        }
        if (Num == 20)
        {
            CP4_X16 = true;
            Invoke("Desactivar_Multiplicadores_Temporales4", 3);
        }
    }
    public float Multiplicadores_Temporales4()
    {
        float MultyFinal;
        if (CP4_X2 == true)
        {
            return MultyFinal = m_Multiplicador4 * 2;
        }
        if (CP4_X4 == true)
        {
            return MultyFinal = m_Multiplicador4 * 4;
        }
        if (CP4_X8 == true)
        {
            return MultyFinal = m_Multiplicador4 * 8;
        }
        if (CP4_X16 == true)
        {
            return MultyFinal = m_Multiplicador4 * 16;
        }
        return MultyFinal = m_Multiplicador4;
    }
    public void Desactivar_Multiplicadores_Temporales4()
    {
        if (CP4_X2 == true)
        {
            CP4_X2 = false;
        }
        if (CP4_X4 == true)
        {
            CP4_X4 = false;
        }
        if (CP4_X8 == true)
        {
            CP4_X8 = false;
        }
        if (CP4_X16 == true)
        {
            CP4_X16 = false;
        }
    }

    public void VenderCP4()
    {
        if (m_Puntos4 > 0)
        {
            m_dinero = m_dinero + M_mercado.VenderPuntos4(m_Puntos4);
            m_Puntos4 = 0;
        }
    }

    public float C_Puntos4()
    {
        return m_Puntos4;
    }

    public void ModificacionMultiplicador4(float aumento)
    {
        m_Multiplicador4 = m_Multiplicador4 + aumento;
    }

    public void ComprarAutomatico4()
    {
        if (PrecioAutomaticoCP4 < m_dinero)
        {
            m_dinero = m_dinero - PrecioAutomaticoCP4;
            StartCoroutine(AutomaticoCP4());
        }
    }

    public IEnumerator AutomaticoCP4()
    {
        yield return new WaitForSeconds(WS_Tiempo4);
        m_Puntos4 = m_Puntos4 + WS_Puntos4;
        StartCoroutine(AutomaticoCP4());
    }

    public void A_CP4()
    {
        if (SubidaDePuntosAutomticoCP4 < m_dinero)
        {
            m_dinero = m_dinero - SubidaDePuntosAutomticoCP4;
            SubidaDePuntosAutomticoCP4 = SubidaDePuntosAutomticoCP4 * 2;
            AumentarCP4();
        }
    }
    public void D_CP4()
    {
        if (BajadaDeTiempoAutomticoCP4 < m_dinero)
        {
            m_dinero = m_dinero - BajadaDeTiempoAutomticoCP4;
            BajadaDeTiempoAutomticoCP4 = BajadaDeTiempoAutomticoCP4 * 2;
            DisminuirCP4();
        }
    }


    public void AumentarCP4()
    {
        WS_Puntos4 = WS_Puntos4 * 1.5f;
    }
    public void DisminuirCP4()
    {
        WS_Tiempo4 = WS_Tiempo4 / 1.5f;
    }
    public void AumentarProducion4()
    {
        if (SubidaDeCantidadCP4 <= m_dinero)
        {
            m_dinero = m_dinero - SubidaDeCantidadCP4;
            m_Multiplicador4 = m_Multiplicador4 * 2;
            SubidaDeCantidadCP4 = SubidaDeCantidadCP4 * 2;
        }
    }

}
