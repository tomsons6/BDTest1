using UnityEngine;
using System.Collections;

public class CarryObjects : MonoBehaviour
{
    public float interactDistance = 3;
    public float carryDistance = 2.5f;
    public LayerMask interactLayer;

    private Transform carryObject;
    public bool haveObject = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MBNDOWN();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MBNUP();
        }
        if (haveObject)
        {
            carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void MBNDOWN()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
                carryObject = hit.transform;
                carryObject.GetComponent<Rigidbody>().useGravity = false;
                haveObject = true;
        }
    }
    public void MBNUP()
    {
        if (haveObject)
        {
            haveObject = false;
            carryObject.GetComponent<Rigidbody>().useGravity = true;
            carryObject = null;
        }
    }
}