using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Bridge : MonoBehaviour
{
    public GameObject[] bridge;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnControllerColliderHit(ControllerColliderHit c)
    {
        bridge = GameObject.FindGameObjectsWithTag("bridge");
        if (c.gameObject.tag == "Drop_Bridge")          
        {
            Debug.Log("kolizija");
            Destroy(c.gameObject);
            int i = 0;
            do
            {
                bridge[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
                i++;
                Debug.Log(i);
            } while (i < 11);
        }
    }
}

