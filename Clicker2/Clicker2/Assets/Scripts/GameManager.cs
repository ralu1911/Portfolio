using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController      m_player;
    private LabyrinthData   m_labyrinth;
    private bool            m_gameOver = false;
    public  RoomsController m_roomController;

    void Start()
    {
        Weapon weapon = new Weapon ("Stick",       10);
        Shield shield = new Shield ("Wood Shield", 10);
        m_player = new PlayerController (10, 5, 20, 100, 20, weapon, shield);

        // CREAMOS EL LABERINTO QUE CONTIENE LAS HABITACIONES
        m_labyrinth = new LabyrinthData();

        // SE AÑADEN LAS HABITACIONES
        EnemyData enemy = new EnemyData ("Angry Ent", 5, 5, 20, 60, 10, 10, 1, 20);
        RoomData  room  = new RoomData  (RoomData.RoomType.ENEMY, enemy);
        m_labyrinth.AddRoom(room);

        ItemData item = new ItemData("J+RB", -5, 10, 10, 10, 0, -5);
        room = new RoomData(RoomData.RoomType.ITEM, item);
        m_labyrinth.AddRoom(room);

        TrapData trap = new TrapData("Examen", -10, -10);
        room = new RoomData(RoomData.RoomType.TRAP, trap);
        m_labyrinth.AddRoom(room);

        enemy = new EnemyData("30fps", 5, 5, 120, 60, 10, 10, 1, 20);
        room = new RoomData(RoomData.RoomType.ENEMY, enemy);
        m_labyrinth.AddRoom(room);
    }

    public void StartGame ()
    {
       // ARRANCA EL LABERINTO
        ChangeRoom();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerAttack       ()
    {
        if (!m_gameOver)
        {
            if (m_labyrinth.GetCurrentRoom().m_roomType == RoomData.RoomType.ENEMY)
            { 
                int damageToApply = m_player.Attack(m_roomController.GetEnemyRoom().m_enemyData);
                
                m_roomController.GetEnemyRoom().RecieveDamage(damageToApply);

                if (m_roomController.GetEnemyRoom().IsDie())
                {
                    Debug.Log("No pudiste aguantar los meteoros caballero de hojalata");
                    ChangeRoom (); 
                }
            }
        }
    }

    public void PlayerStrongAttack ()
    {
        if (!m_gameOver)
        {
            if (m_labyrinth.GetCurrentRoom().m_roomType == RoomData.RoomType.ENEMY)
            {
                int damageToApply = m_player.StrongAttack(m_roomController.GetEnemyRoom().m_enemyData);

                m_roomController.GetEnemyRoom().RecieveDamage(damageToApply);

                if (m_roomController.GetEnemyRoom().IsDie())
                {
                    Debug.Log("Hola, ¿estas bien?");
                    ChangeRoom (); 
                }
            }
        }
    }

    public void ChangeRoom         ()
    {
        m_labyrinth.ChangeRoom();

        if (m_labyrinth.IsFinished())
        {
            // GAME END
            m_roomController.DisableRooms();
            m_gameOver = true;
            return;
        }
        Debug.Log("ChangeROOMM!!!!!!!!!!!!!");
        switch (m_labyrinth.GetCurrentRoom().m_roomType)
        {
            case RoomData.RoomType.ENEMY:
                m_roomController.SetRoom (m_labyrinth.GetCurrentRoom().m_enemy);
                break;
            case RoomData.RoomType.ITEM:
                Debug.Log("ITEM!!!!!!!!!!!!!");
                m_roomController.SetRoom (m_labyrinth.GetCurrentRoom().m_item);
                break;
            case RoomData.RoomType.TRAP:
                Debug.Log("TRAP!!!!!!!!!!!!!");
                m_roomController.SetRoom (m_labyrinth.GetCurrentRoom().m_trap);
                break;
            default:
                break;
        }
    }

    public void EnemyAttack (int damage)
    {
        m_player.RecieveDamage(damage);

        if (m_player.IsDie())
        {
            // GAME OVER.
            m_roomController.DisableRooms();
            m_gameOver = true;
        }
    }

    public void ApplyItem   ()
    {
        m_player.ApplyItem(m_labyrinth.GetCurrentRoom().m_item);
    }

    public void ApplyTrap   ()
    {
        m_player.ApplyTrap(m_labyrinth.GetCurrentRoom().m_trap);
    }
}
