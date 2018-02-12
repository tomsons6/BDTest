using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PowerUp : MonoBehaviour
{
    public Transform clone1T, clone2T, clone3T;
    public GameObject clone1, clone2, clone3;
    private int count,characterint2, characterint4;  
    // Use this for initialization
    void Start()
    {
        characterint2 = 1;
        characterint4 = 1;
        count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        clone1 = GameObject.FindGameObjectWithTag("Clone1");
        clone2 = GameObject.FindGameObjectWithTag("Clone2");
        clone3 = GameObject.FindGameObjectWithTag("Clone3");
        OnEdown();
        OnQdown();
        OnRdown();
        
    }
    //Cloning 
    void OnQdown()
    {
        if (Input.GetKeyDown("q"))
        {
            count= count + 1;
            Debug.Log(count.ToString());
            Vector3 pos = gameObject.transform.position;
            
            if (count == 1 )
            {
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(-4.5f, 0f, 5f, 5f);
                Instantiate(clone1T, pos + new Vector3(5, 0, 0), Quaternion.identity);
                clone1T.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 5f, 5f);
            }
            if (count == 2)
            {
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(-4.5f, .5f, 5f, 5f);
                clone1T.GetComponentInChildren<Camera>().rect = new Rect(.5f, .5f, 5f, 5f);
                Instantiate(clone2T, pos + new Vector3(0, 0, -5), Quaternion.identity);
                clone2T.GetComponentInChildren<Camera>().rect = new Rect(-4.5f, -4.5f, 5f, 5f);
                Instantiate(clone3T, pos + new Vector3(5, 0, -5), Quaternion.identity);
                clone3T.GetComponentInChildren<Camera>().rect = new Rect(.5f, -4.5f, 5f, 5f);
            }
        }
    }
    void OnRdown()
    {
        if (Input.GetKeyDown("r"))
        {
            
            if (count == 1)
            {
                Destroy(clone1);
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 5f, 5f);
                count = 0;
            }
            if (count == 2)
            {
                Destroy(clone2);
                Destroy(clone3);
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(-4.5f, 0f, 5f, 5f);
                clone1.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 5f, 5f);
                count = 1;
            }
        }
    }
    //switching between clones
    void OnEdown()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log(characterint4);
            characterint4++;
            characterint2++;
            // count = 0 -> no clones ar spawned
            if (count == 0)
            {
                characterint2 = 1;
                characterint4 = 1;
                gameObject.GetComponent<FirstPersonController>().enabled = true;
                gameObject.GetComponentInChildren<Camera>().enabled = true;
            }
            //count = 1 -> 1 clone is spawned
            if (count == 1)
            {
                    switch (characterint2)
                    {
                        case 1:
                            gameObject.GetComponent<FirstPersonController>().enabled = true;
                            clone1.GetComponent<FirstPersonController>().enabled = false;

                            transform.gameObject.GetComponentInChildren<Camera>().tag = "MainCamera";
                            clone1.GetComponentInChildren<Camera>().tag = "Untagged";
                            break;
                        case 2:
                            gameObject.GetComponent<FirstPersonController>().enabled = false;
                            clone1.GetComponent<FirstPersonController>().enabled = true;

                            gameObject.GetComponentInChildren<Camera>().tag = "Untagged";
                            clone1.GetComponentInChildren<Camera>().tag = "MainCamera";
                            break;
                    }
                    if (characterint2 == 2)
                    {
                        characterint2 = 0;
                        characterint4 = 0;
                    }
                }
            }
            //count = 2 -> 3 clones ar spawned
            if (count == 2)
            {
                switch (characterint4)
                {
                    case 0:
                        gameObject.GetComponent<FirstPersonController>().enabled = false;
                        clone1.GetComponent<FirstPersonController>().enabled = false;
                        clone2.GetComponent<FirstPersonController>().enabled = false;
                        clone3.GetComponent<FirstPersonController>().enabled = true;

                        gameObject.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone1.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone2.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone3.GetComponentInChildren<Camera>().tag = "MainCamera";
                        break;
                    case 1:
                        gameObject.GetComponent<FirstPersonController>().enabled = true;
                        clone1.GetComponent<FirstPersonController>().enabled = false;
                        clone2.GetComponent<FirstPersonController>().enabled = false;
                        clone3.GetComponent<FirstPersonController>().enabled = false;

                        transform.gameObject.GetComponentInChildren<Camera>().tag = "MainCamera";
                        clone1.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone2.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone3.GetComponentInChildren<Camera>().tag = "Untagged";

                        break;
                    case 2:
                        gameObject.GetComponent<FirstPersonController>().enabled = false;
                        clone1.GetComponent<FirstPersonController>().enabled = true;
                        clone2.GetComponent<FirstPersonController>().enabled = false;
                        clone3.GetComponent<FirstPersonController>().enabled = false;

                        gameObject.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone1.GetComponentInChildren<Camera>().tag = "MainCamera";
                        clone2.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone3.GetComponentInChildren<Camera>().tag = "Untagged";
                        break;
                    case 3:
                        gameObject.GetComponent<FirstPersonController>().enabled = false;
                        clone1.GetComponent<FirstPersonController>().enabled = false;
                        clone2.GetComponent<FirstPersonController>().enabled = true;
                        clone3.GetComponent<FirstPersonController>().enabled = false;

                        gameObject.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone1.GetComponentInChildren<Camera>().tag = "Untagged";
                        clone2.GetComponentInChildren<Camera>().tag = "MainCamera";
                        clone3.GetComponentInChildren<Camera>().tag = "Untagged";
                        break;

                }
                if (characterint4 == 4)
                {
                    characterint2 = 0;
                    characterint4 = 0;
                }
            }
        }
    }

    /**
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        
        if (hit.gameObject.tag == "Cube")
        {
            count++;
            Vector3  pos= gameObject.transform.position;
            Debug.Log(count.ToString());
            if (count == 2 )
            {
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(.5f, 0f, .5f, 1f);
                Instantiate(prefab, pos + new Vector3(-3, 0, -3), Quaternion.identity);
                prefab.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, .5f, 1f);


            }
            if (count == 3)
            {
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(.5f, .5f, .5f, .5f);
                gameObject.GetComponentInChildren<Camera>().rect = new Rect(.5f, 0f, .5f, .5f);
                Instantiate(prefab,pos + new Vector3(3, 0, -3), Quaternion.identity);
                prefab.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, .5f, .5f);
                Instantiate(prefab, pos + new Vector3(-6, 0, -3), Quaternion.identity);
                prefab.GetComponentInChildren<Camera>().rect = new Rect(0f, .5f, .5f, 5f);
            }
            Destroy(hit.gameObject);
           
        } 
        
    }**/ 