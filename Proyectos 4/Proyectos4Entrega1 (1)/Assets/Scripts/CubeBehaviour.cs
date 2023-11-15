using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public GameObject soldierSquad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 12)
        {
            soldierSquad.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
