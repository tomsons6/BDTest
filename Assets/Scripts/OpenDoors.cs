using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public GameObject Door;
    private bool isWithinOpenZone = false;
    private bool isDoorOpeningInProgress = false;
    private float doorOpenTimeInSeconds = 2.5f;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            TriggerOpenDoorInput();
        }
    }
    private void TriggerOpenDoorInput()
    {
        if (isWithinOpenZone && !isDoorOpeningInProgress)
        {
            StartCoroutine(OpenDoorRoutine());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //validate if Player or other entity that can open door
        if(other.gameObject.tag == "Test1BtnDown")
        isWithinOpenZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //validate if Player or other entity that can open door
        isWithinOpenZone = false;
    }
    private IEnumerator OpenDoorRoutine()
    {
        isDoorOpeningInProgress = true;

        Vector3 from = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z);
        Vector3 to = new Vector3(Door.transform.position.x, Door.transform.position.y, 4.5f);

        float t = 0f;

        while (t <= 1f)
        {
            t += Time.deltaTime / doorOpenTimeInSeconds;

            Vector3 current = Vector3.Lerp(from, to, t);

            //Apply current 
            Door.transform.position = current;

            yield return null;
        }

        isDoorOpeningInProgress = false;
    }
}
