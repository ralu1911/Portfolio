using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	[SerializeField] GameObject target;
    [SerializeField] float mouseSensibility = 5;

    float distance;
    
    void Start()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float mouseXInput = Input.GetAxis("Mouse X");
            transform.RotateAround(target.transform.position, Vector3.up, mouseXInput * mouseSensibility);
        }        
    }

    private void LateUpdate()
    {
        this.transform.position = target.transform.position - transform.forward * distance;
    }
}
