using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpPush : MonoBehaviour {

    public bool isWithinOpenZoneBtnUp = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter(Collider other)
    {
        //validate if Player or other entity that can open door
        if (other.gameObject.tag == "Clone1")
            isWithinOpenZoneBtnUp = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //validate if Player or other entity that can open door
        isWithinOpenZoneBtnUp = false;
    }
}
