using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoorOpen : MonoBehaviour
{

    public GameObject DoorLeft, DoorRight, BtnUp;
    private bool isWithinOpenZone = false;
    private bool isDoorOpeningInProgress = false;
    private float doorOpenTimeInSeconds = 2f;

    void Start()
    {
        BtnUp = GameObject.FindGameObjectWithTag("BtnUp");
      
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {         
            TriggerOpenDoorInput();
        }
    }
    private void TriggerOpenDoorInput()
    {
        if (isWithinOpenZone && !isDoorOpeningInProgress && BtnUp.GetComponent<BtnUpPush>().isWithinOpenZoneBtnUp)
        {
            StartCoroutine(OpenDoorRoutine());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //validate if Player or other entity that can open door
        if (other.gameObject.tag == "BtnDown")
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

        Vector3 fromLeft = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, DoorLeft.transform.position.z);
        Vector3 toLeft = new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, -1.65f);
        Vector3 fromRight = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, DoorRight.transform.position.z);
        Vector3 toRight = new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, 1.65f);

        float t = 0f;

        while (t <= 1f)
        {
            t += Time.deltaTime / doorOpenTimeInSeconds;

            Vector3 currentLeft = Vector3.Lerp(fromLeft, toLeft, t);
            Vector3 currentRight = Vector3.Lerp(fromRight, toRight, t);

            //Apply current 
            DoorLeft.transform.position = currentLeft;
            DoorRight.transform.position = currentRight;

            yield return null;
        }

        isDoorOpeningInProgress = false;
    }
}
