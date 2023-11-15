using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    private Mercado m_mercado;
    private GameManager Manager;

    public float PrecioSubida1;
    public float PrecioSubida2;
    public float PrecioSubida3;
    public float PrecioSubida4;
    public float PrecioBajadaCorrupcion;
    public float Corrupcion;

    public bool GameOver;

    private void Awake()
    {
        m_mercado = GetComponent<Mercado>();
        Manager = GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        StartCoroutine(Detencion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AumenatarPrecio(float aumento)
    {
        if (Manager.m_dinero > PrecioSubida1)
        {
            m_mercado.CambiarCP1_HuecoMercado(aumento);
            Corrupcion = Corrupcion + 5;
            Manager.m_dinero = Manager.m_dinero - PrecioSubida1;
        }
    }

    public void DisminuirCorrupcion()
    {
        if (Manager.m_dinero > PrecioBajadaCorrupcion)
        {
            Manager.m_dinero = Manager.m_dinero - PrecioBajadaCorrupcion;
            Corrupcion = Corrupcion - 10;
            if (Corrupcion < 0)
            {
                Corrupcion = 0;
            }
            if (Corrupcion >= 100)
            {
                GameOver = true;
            }
        }
    }
    public IEnumerator Detencion()
    {
        yield return new WaitForSeconds(180);
        float Aleatorio = Random.Range(1, 100);
        if (Aleatorio < Corrupcion)
        {
            GameOver = true;
        }
    }

    public void AumenatarPrecio2(float aumento)
    {
        if (Manager.m_dinero > PrecioSubida2)
        {
            Manager.m_dinero = Manager.m_dinero - PrecioSubida2;
            m_mercado.CambiarCP1_HuecoMercado2(aumento);
            Corrupcion = Corrupcion + 5;
        }
       
    }
    public void AumenatarPrecio3(float aumento)
    {
        if (Manager.m_dinero > PrecioSubida3)
        {
            Manager.m_dinero = Manager.m_dinero - PrecioSubida3;
            m_mercado.CambiarCP1_HuecoMercado3(aumento);
            Corrupcion = Corrupcion + 5;
        }
    }
    public void AumenatarPrecio4(float aumento)
    {
        if (Manager.m_dinero > PrecioSubida4)
        {
            Manager.m_dinero = Manager.m_dinero - PrecioSubida4;
            m_mercado.CambiarCP1_HuecoMercado4(aumento);
            Corrupcion = Corrupcion + 5;
        }
    }
}
