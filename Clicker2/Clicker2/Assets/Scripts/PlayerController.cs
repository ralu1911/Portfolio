using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    private int m_damage;
    private int m_defense;
    private int m_maxLife;
    private int m_maxMana;
    private int m_experienceToNextLevel;

    private int m_currentLife;
    private int m_currentMana;
    private int m_currentExperience;

    private Weapon m_currentWeapon;
    private Shield m_currentShield;

    public PlayerController              (int damage, int defense, int maxLife, int maxMana, int experienceToNextLevel, Weapon currentWeapon, Shield currentShield)
    {
        m_damage                = damage;
        m_defense               = defense;
        m_maxLife               = maxLife;
        m_maxMana               = maxMana;
        m_experienceToNextLevel = experienceToNextLevel;
        
        m_currentLife           = maxLife;
        m_currentMana           = maxMana;
        m_currentExperience     = 0;
        
        m_currentWeapon         = currentWeapon;
        m_currentShield         = currentShield;
    }
    
    public void AddExperience  (int experience)
    {
        m_currentExperience += experience;

        if (m_currentExperience > m_experienceToNextLevel)
        {
            UpLevel ();
        }
    }

    public void RecieveDamage  (int damage)
    {
        int currentDamage = damage - m_defense;

        if (currentDamage > 0)
        {
            m_currentLife -= damage - m_defense;
            Debug.Log("Ay!");
        }
    }

    public int Attack         (EnemyData enemy)
    {
        Debug.Log("Meteoros de Pegaso! ");
        int damageAux = m_damage;

        return damageAux;
    }

    public int StrongAttack   (EnemyData enemy)
    {
        Debug.Log("Kaaaa Meeee Haaaa Meee HA!");
        int damageAux = m_damage * 2;

        return damageAux;
    }

    public void SetWeapon      (Weapon weapon)
    {
        m_currentWeapon = weapon;
    }

    public void SetShield      (Shield shield)
    {
        m_currentShield = shield;
    }
    
    public void ApplyItem      (ItemData item)
    {
        
    }

    public void ApplyTrap      (TrapData trap)
    {
        
    }  

    public void UpLevel        ()
    {
        m_currentExperience      = 0;
        m_experienceToNextLevel *= 2;
        m_damage                += 10;
        m_maxLife               += 15;
        m_maxMana               += 10;
        m_defense               += 10; 

        m_currentLife            = m_maxLife;
        m_currentMana            = m_maxMana;
    }

    public bool IsDie          ()
    {
        if (m_currentLife < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
