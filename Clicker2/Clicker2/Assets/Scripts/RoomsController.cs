using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject m_enemyRoom;
    public GameObject m_itemRoom;
    public GameObject m_trapRoom;

    public void SetRoom (EnemyData data)
    {
        m_enemyRoom.SetActive(true);
        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(false);
        m_enemyRoom.GetComponent<EnemyBehaviour>().SetEnemy(data);
    }

    public void SetRoom (ItemData data)
    {
        m_enemyRoom.SetActive(false);
        m_itemRoom.SetActive(true);
        m_trapRoom.SetActive(false);
        m_itemRoom.GetComponent<ItemBehaviour>().m_itemData = data;
    }

    public void SetRoom (TrapData data)
    {
        m_enemyRoom.SetActive(false);
        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(true);
        m_trapRoom.GetComponent<TrapBehaviour>().m_trapData = data;
    }

    public void DisableRooms ()
    {
        m_enemyRoom.SetActive(false);
        m_itemRoom.SetActive(false);
        m_trapRoom.SetActive(false);
    }

    public EnemyBehaviour GetEnemyRoom ()
    {
        return m_enemyRoom.GetComponent<EnemyBehaviour>();
    }
}
