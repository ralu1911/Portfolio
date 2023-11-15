using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [SerializeField] float pushPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            Vector3 pushDirection = hit.gameObject.transform.position - transform.position;
            pushDirection.y = 0;
            pushDirection.Normalize();
            rb.AddForceAtPosition(pushDirection * pushPower, transform.position, ForceMode.Impulse);
        }
    }
}
