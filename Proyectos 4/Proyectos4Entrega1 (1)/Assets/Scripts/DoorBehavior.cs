using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public GameObject       DoorPanel;
    public bool             isLocked;
    public GameObject       messageHowToOpen;
    public GameObject       messageLocked;

    private void Awake()
    {
        messageHowToOpen.SetActive(false);
       messageLocked.SetActive(false);
    }

    public void Unlock()
    {
        isLocked = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (isLocked)
        {
            messageLocked.SetActive(true);
            
        }

        else if (!isLocked)
        {
            messageHowToOpen.SetActive(true);
        }

        Debug.Log("PlayerEntered");
        if (Input.GetKeyDown(KeyCode.F)& other.gameObject.tag == "Player")
        {
            if (!isLocked)
            {
                DoorPanel.SetActive(false);
                messageHowToOpen.SetActive(false);
            }
            if (isLocked)
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        DoorPanel.SetActive(true);
        messageLocked.SetActive(false);
        messageHowToOpen.SetActive(false);
        
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
