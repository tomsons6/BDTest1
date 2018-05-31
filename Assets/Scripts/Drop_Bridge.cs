using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Bridge : MonoBehaviour {
     GameObject[] bridge;

	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        bridge = GameObject.FindGameObjectsWithTag("Bridge");
        if (other.gameObject.tag == "Main" || other.gameObject.tag == "Clone1")
        {
            Debug.Log("kolizija");
            Destroy(this);
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
