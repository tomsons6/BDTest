using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public float sphereRadius;
    bool colisionTrue = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CollisionDetectin();
    }
    void CollisionDetectin()
    {
        
        if (Physics.CheckBox(transform.position, new Vector3(1, 1)))
        {
            colisionTrue = true;
            Debug.Log("collision");
            


        }
        else
        {
            colisionTrue = false;
        }
        /*while(colisionTrue == true)
        {
           transform.position = new Vector3(transform.position.x + 5 , transform.position.y, transform.position.z);
        }*/
        Debug.Log(colisionTrue);
        Debug.Log(Physics.CheckBox(transform.position, new Vector3(1, 1)).ToString());
    }
}
