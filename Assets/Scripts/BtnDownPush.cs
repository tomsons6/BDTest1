using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDownPush : MonoBehaviour {

    public bool isWithinOpenZoneBtnDown = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //validate if Player or other entity that can open door
        if (other.gameObject.tag == "Clone1" || other.gameObject.tag == "Main")
            isWithinOpenZoneBtnDown = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //validate if Player or other entity that can open door
        isWithinOpenZoneBtnDown = false;
    }
}
