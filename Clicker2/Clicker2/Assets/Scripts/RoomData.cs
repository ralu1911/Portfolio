using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData 
{
    public enum RoomType { ENEMY, ITEM, TRAP};

    public RoomType  m_roomType;
    public TrapData  m_trap;
    public EnemyData m_enemy;
    public ItemData  m_item;

    public      RoomData (RoomType type, TrapData trap)
    {
        m_roomType = RoomType.TRAP;
        m_trap     = trap;
    }

    public      RoomData (RoomType type, EnemyData enemy)
    {
        m_roomType = RoomType.ENEMY;
        m_enemy    = enemy;
    }

    public      RoomData (RoomType type, ItemData item)
    {
        m_roomType = RoomType.ITEM;
        m_item     = item;
    }
}
