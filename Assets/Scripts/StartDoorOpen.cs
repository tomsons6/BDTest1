using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoorOpen : MonoBehaviour
{

    public GameObject DoorLeft, DoorRight, BtnUp, BtnDown, UpBtn,DownBtn;
    private float doorOpenTimeInSeconds = 2f;
    private float btnpushSec = .2f;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {         
            TriggerOpenDoorInput();
        }
    }
    private void TriggerOpenDoorInput()
    {
        if (BtnDown.GetComponent<BtnDownPush>().isWithinOpenZoneBtnDown)
        {
            StartCoroutine(BtnDownPush());
        }
        if (BtnUp.GetComponent<BtnUpPush>().isWithinOpenZoneBtnUp)
        {
            StartCoroutine(BtnUpPush());
        }
        if (BtnUp.GetComponent<BtnUpPush>().isWithinOpenZoneBtnUp && BtnDown.GetComponent<BtnDownPush>().isWithinOpenZoneBtnDown)
        {
            StartCoroutine(OpenDoorRoutine());
        }
    }
    private IEnumerator BtnDownPush()
    {
        Vector3 BtnStart = new Vector3(0f, DownBtn.transform.localPosition.y, DownBtn.transform.localPosition.z);
        Vector3 BtnEnd = new Vector3( -0.0046f, DownBtn.transform.localPosition.y, DownBtn.transform.localPosition.z);
        float t = 0f;
        float t1 = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / btnpushSec;
            Vector3 CurrentPush = Vector3.Lerp(BtnStart, BtnEnd,t);
            DownBtn.GetComponentInChildren<Transform>().localPosition = CurrentPush;
            yield return null;
        }
        yield return new WaitForSeconds(.1f);
        while (t1 <= 1f)
        {
            t1 += Time.deltaTime / btnpushSec;
            Vector3 CurrentPush = Vector3.Lerp(BtnEnd, BtnStart, t);
            DownBtn.GetComponentInChildren<Transform>().localPosition = CurrentPush;
            yield return null;
        }
    }
    private IEnumerator BtnUpPush()
    {
        Vector3 BtnStart = new Vector3(0, UpBtn.transform.localPosition.y, UpBtn.transform.localPosition.z);
        Vector3 BtnEnd = new Vector3( -0.0046f, UpBtn.transform.localPosition.y, UpBtn.transform.localPosition.z);
        float t = 0f;
        float t1 = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / btnpushSec;
            Vector3 CurrentPush = Vector3.Lerp(BtnStart, BtnEnd, t);
            UpBtn.GetComponentInChildren<Transform>().localPosition = CurrentPush;
            yield return null;
        }
        yield return new WaitForSeconds(.1f);
        while (t1 <= 1f)
        {
            t1 += Time.deltaTime / btnpushSec;
            Vector3 CurrentPush = Vector3.Lerp(BtnEnd, BtnStart, t);
            UpBtn.GetComponentInChildren<Transform>().localPosition = CurrentPush;
            yield return null;
        }
    }
    private IEnumerator OpenDoorRoutine()
    {
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
    }
}
