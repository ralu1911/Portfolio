using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Piedra : MonoBehaviour
{
    private Rigidbody MF_rb;

    private Vector3 Arco;
    private void Awake()
    {
        MF_rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Arco.z = 6;
        Arco.y = 6;
        Arco = transform.TransformDirection(Arco);
        MF_rb.velocity = Arco;

        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit[] Sphere = Physics.SphereCastAll(transform.position, 5, transform.up, 4);
        for(int i = 0; i <= Sphere.Length - 1; i++)
        {
            if(Sphere[i].collider.GetComponent<IEnemy>() != null)
            {
                Sphere[i].collider.GetComponent<IEnemy>().IEnemyDeteccion(transform.position);
            }
        }
        Destroy(this.gameObject);
    }
}
