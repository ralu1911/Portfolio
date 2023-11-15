using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public DoorBehavior assignedDoor;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Playerhere");
        if (other.gameObject.tag == "Player")
        {
            assignedDoor.Unlock();
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
