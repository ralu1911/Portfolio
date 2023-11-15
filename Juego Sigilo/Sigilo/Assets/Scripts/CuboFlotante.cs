using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboFlotante : MonoBehaviour
{
    private BoxCollider bx;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        bx = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
