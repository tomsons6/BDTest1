using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Bridge : MonoBehaviour {
     GameObject[] bridge;

	void Update () {
		
	}
    void OnControllerColliderHit(ControllerColliderHit c)
    {
        bridge = GameObject.FindGameObjectsWithTag("Bridge");
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
