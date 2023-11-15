using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercado : MonoBehaviour
{
    public float CP1_Mercado;
    public float CP1_HuecoMercado;
    public float CP1_PrecioBase;

    public float CP2_Mercado;
    public float CP2_HuecoMercado;
    public float CP2_PrecioBase;

    public float CP3_Mercado;
    public float CP3_HuecoMercado;
    public float CP3_PrecioBase;

    public float CP4_Mercado;
    public float CP4_HuecoMercado;
    public float CP4_PrecioBase;

    // Start is called before the first frame update
    void Start()
    {
        CP1_Mercado = 10000;
        CP1_HuecoMercado = 10000;
        StartCoroutine(SubidaPrecio());

        CP2_Mercado = 5000;
        CP2_HuecoMercado = 5000;
        StartCoroutine(SubidaPrecio2());

        CP3_Mercado = 20000;
        CP3_HuecoMercado = 20000;
        StartCoroutine(SubidaPrecio3());

        CP4_Mercado = 3000;
        CP4_HuecoMercado = 3000;
        StartCoroutine(SubidaPrecio4());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float MercadoPuntos()
    {
        float precio;
        precio = (CP1_HuecoMercado / CP1_Mercado) * CP1_PrecioBase;
        return precio;
    }

    public float VenderPuntos(float cantidad)
    {
        float dinero;
        CP1_Mercado = CP1_Mercado + cantidad;
        return dinero = cantidad * MercadoPuntos();
    }

    public IEnumerator SubidaPrecio()
    {
        yield return new WaitForSeconds(120);
        CP1_HuecoMercado = CP1_HuecoMercado + 40;
        StartCoroutine(SubidaPrecio());
    }
    public void CambiarCP1_HuecoMercado(float AumentoDelPrecio)
    {
        CP1_HuecoMercado = CP1_HuecoMercado + AumentoDelPrecio;
    }



    public float MercadoPuntos2()
    {
        float precio;
        precio = (CP2_HuecoMercado / CP2_Mercado) * CP2_PrecioBase;
        return precio;
    }

    public float VenderPuntos2(float cantidad)
    {
        float dinero;
        CP2_Mercado = CP2_Mercado + cantidad;
        return dinero = cantidad * MercadoPuntos2();
    }

    public IEnumerator SubidaPrecio2()
    {
        yield return new WaitForSeconds(120);
        CP2_HuecoMercado = CP2_HuecoMercado + 40;
        StartCoroutine(SubidaPrecio2());
    }
    public void CambiarCP1_HuecoMercado2(float AumentoDelPrecio)
    {
        CP2_HuecoMercado = CP2_HuecoMercado + AumentoDelPrecio;
    }




    public float MercadoPuntos3()
    {
        float precio;
        precio = (CP3_HuecoMercado / CP3_Mercado) * CP3_PrecioBase;
        return precio;
    }

    public float VenderPuntos3(float cantidad)
    {
        float dinero;
        CP3_Mercado = CP3_Mercado + cantidad;
        return dinero = cantidad * MercadoPuntos2();
    }

    public IEnumerator SubidaPrecio3()
    {
        yield return new WaitForSeconds(120);
        CP3_HuecoMercado = CP3_HuecoMercado + 40;
        StartCoroutine(SubidaPrecio2());
    }
    public void CambiarCP1_HuecoMercado3(float AumentoDelPrecio)
    {
        CP3_HuecoMercado = CP3_HuecoMercado + AumentoDelPrecio;
    }



    public float MercadoPuntos4()
    {
        float precio;
        precio = (CP4_HuecoMercado / CP4_Mercado) * CP4_PrecioBase;
        return precio;
    }

    public float VenderPuntos4(float cantidad)
    {
        float dinero;
        CP4_Mercado = CP4_Mercado + cantidad;
        return dinero = cantidad * MercadoPuntos4();
    }

    public IEnumerator SubidaPrecio4()
    {
        yield return new WaitForSeconds(120);
        CP4_HuecoMercado = CP4_HuecoMercado + 40;
        StartCoroutine(SubidaPrecio4());
    }
    public void CambiarCP1_HuecoMercado4(float AumentoDelPrecio)
    {
        CP4_HuecoMercado = CP4_HuecoMercado + AumentoDelPrecio;
    }
}
