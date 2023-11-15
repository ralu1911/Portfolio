using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void IEnemyDamage();
    void IEnemyDeteccion(Vector3 Posicion);
}
