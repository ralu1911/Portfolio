using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image m_image;


    public void LifeBar (int amount, int maxLife)
    {
        m_image.fillAmount = (float)amount / maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
