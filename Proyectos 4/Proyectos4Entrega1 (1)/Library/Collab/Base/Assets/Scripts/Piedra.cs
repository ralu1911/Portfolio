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
        Arco.y = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Arco.x = 20 * Time.deltaTime;
        Arco.y += Arco.y * Time.deltaTime + 9.8f * Time.deltaTime * Time.deltaTime;
        MF_rb.velocity = Arco;

    }

}
