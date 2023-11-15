using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public  GameManager    m_gameManager;
    public  EnemyData      m_enemyData;
    public  SpriteRenderer m_sprite;
    private float          m_counterTime;

    public void Start()
    {
        m_counterTime = 0;
    }

    public void SetEnemy (EnemyData enemyData)
    {
        m_enemyData = enemyData;
    }

    public void Greet         ()
    {
        Debug.Log("Un enemigo ha aparecido! Es un " + m_enemyData.m_name + "!");
        Debug.Log("Tiene una fuerza de " + m_enemyData.m_damage      + " unidades de energía");
        Debug.Log("Tiene " + m_enemyData.m_currentLife + " corazoncicos");
    }

    public void Attack        ()
    {
        int attackValue = Random.Range(0, 100);
        int damage      = 0;

        if (attackValue <= m_enemyData.m_percentageStrongAttack)
        {
            damage = m_enemyData.m_damage;
            Debug.Log(m_enemyData.m_name + " da una Toñina!");
        }
        else
        {
            damage = m_enemyData.m_damage * 2;
            Debug.Log(m_enemyData.m_name + " da una OstiaFina!");
        }

        m_gameManager.EnemyAttack(damage);
    }

    public void RecieveDamage (int damage)
    {
        int currentDamage = damage - m_enemyData.m_defense;

        if (currentDamage > 0)
        {
            Debug.Log("Ouch!");
            m_enemyData.m_currentLife -= damage - m_enemyData.m_defense;
        }

        if (m_enemyData.m_currentLife < 0)
        {
            // PLAYER DIE
            Debug.Log("Not tod...argfrfgfgr");
        }
    }

    public bool IsDie         ()
    {
        if (m_enemyData.m_currentLife < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Update   ()
    {
        m_counterTime += Time.deltaTime;

        if (m_counterTime > m_enemyData.m_timeBetweenAttacks)
        {
            m_counterTime = 0;
            Attack ();
        }
    }
}
