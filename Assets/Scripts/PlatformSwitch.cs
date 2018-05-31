using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour {

    private bool iswithinzone = false;
    private bool switchpulled = false;
    public GameObject switche;
    public GameObject platform;
    private float switchpullt = 0.5f;
    private float platfrommovet = 2.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(switchpulled == false)
            {
                StartCoroutine(SwitchMove());
                StartCoroutine(PlatfromMove());
            }
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Main" || other.gameObject.tag == "Clone1")
        {
            iswithinzone = true;
            
        }
    }
    private void OnTrigerExit(Collider other)
    {
        iswithinzone = false;
    }
    IEnumerator SwitchMove()
    {
        float t = 0f;
        Quaternion switchstart = new Quaternion(switche.transform.localRotation.x, switche.transform.localRotation.y, switche.transform.localRotation.z, switche.transform.localRotation.w);
        Quaternion switchEnd = new Quaternion(switche.transform.localRotation.x /12f, switche.transform.localRotation.y, switche.transform.localRotation.z, switche.transform.localRotation.w);
        if (iswithinzone == true)
        {
            while(t <= 1f)
            {
                t += Time.deltaTime * switchpullt;
                Quaternion currentposition = Quaternion.Lerp(switchstart, switchEnd, t);
                switche.transform.localRotation = currentposition;
                yield return null;
            }
        }
        switchpulled = true;
    }
    IEnumerator PlatfromMove()
    {
        Vector3 platformstart = new Vector3(62f, 8f, platform.transform.position.z);
        Vector3 platformmiddown = new Vector3(46f, 8f, platform.transform.position.z);
        Vector3 platfrommidup = new Vector3(46f, 11.5f, platform.transform.position.z);
        Vector3 platformEnd = new Vector3(62f, 8f, platform.transform.position.z);
        while(switchpulled == true) {
        float t = 0f;
        float t1 = 0f;
        float t2 = 0f;
        float t3 = 0f;
        while (t<= 1f)
        {
            t += Time.deltaTime / platfrommovet;
            Vector3 Currentposition = Vector3.Lerp(platformstart, platformmiddown, t);
            platform.transform.position = Currentposition;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        while (t1 <= 1f)
        {
            t1 += Time.deltaTime / platfrommovet;
            Vector3 Currentpositionup = Vector3.Lerp(platformmiddown, platfrommidup, t1);
            platform.transform.position = Currentpositionup;
            yield return null;
        }
        yield return new WaitForSeconds(5f);
        while (t2 <= 1f)
        {
            t2 += Time.deltaTime / platfrommovet;
            Vector3 Currentpositiondown = Vector3.Lerp(platfrommidup, platformmiddown, t2);
            platform.transform.position = Currentpositiondown;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        while(t3 <= 1f)
        {
            t3 += Time.deltaTime / platfrommovet;
            Vector3 Currentpositionback = Vector3.Lerp(platformmiddown, platformstart, t3);
            platform.transform.position = Currentpositionback;
            yield return null;
        }
        yield return new WaitForSeconds(5f);
        }
    }
}
