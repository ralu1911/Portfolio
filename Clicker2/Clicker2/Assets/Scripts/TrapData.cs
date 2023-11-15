using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData 
{
    public string m_name;
    public int    m_playerDamage;
    public int    m_manaDamage;

    public TrapData (string name, int playerDamage, int manaDamage)
    {
        m_name         = name;
        m_playerDamage = playerDamage;
        m_manaDamage   = manaDamage;
    }
}
