using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickUP : MonoBehaviour {
    private GameObject laser;
    private float lowerSwitch = 2f;
    private bool keycardispicked = false;
    private bool iskeycardpicked = false;
	// Use this for initialization
	void Start () {
        laser = GameObject.FindGameObjectWithTag("Laser");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "KeyCard" && iskeycardpicked == false)
        {
            keycardispicked = true;
            iskeycardpicked = true;
            StartCoroutine(LowerSwitch());
        }

    }
    public void OnTriggerStay(Collider other)
    {
        GameObject Main = GameObject.FindGameObjectWithTag("Main");
        GameObject Clone1 = GameObject.FindGameObjectWithTag("Clone1");
        Clone clonescr = Main.GetComponent<Clone>();
        CarryObjects carryscr = Main.GetComponent<CarryObjects>();
        if (other.gameObject.tag == "Main" && keycardispicked)
        {
            DrawLine(new Vector3(laser.transform.position.x, laser.transform.position.y, laser.transform.position.z), new Vector3(Main.transform.position.x,Main.transform.position.y + 1f, Main.transform.position.z), Color.red);
            keycardispicked = false;
        }
        if (other.gameObject.tag == "Clone1" && keycardispicked)
        {
            DrawLine(new Vector3(laser.transform.position.x, laser.transform.position.y, laser.transform.position.z), new Vector3(Clone1.transform.position.x, Clone1.transform.position.y + 1f, Clone1.transform.position.z), Color.red);
            keycardispicked = false;
            clonescr.OnRdown();
            carryscr.MBNUP();
        }
    }
    void DrawLine(Vector3 LaserStartP, Vector3 LaserEndP, Color color, float duration = 0.2f)
    {
        GameObject LaserLine = new GameObject();
        LaserLine.transform.position = LaserStartP;
        LaserLine.AddComponent<LineRenderer>();
        LineRenderer lr = LaserLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = Color.red;
        lr.startWidth = 1f;
        lr.SetPosition(0, LaserStartP) ;
        lr.SetPosition(1, LaserEndP);
        GameObject.Destroy(LaserLine, duration);;
    }
    private IEnumerator LowerSwitch()
    {
        Vector3 StartP = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Vector3 EndP = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.015f, gameObject.transform.position.z);
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / lowerSwitch;
            Vector3 CurrentPosition = Vector3.Lerp(StartP, EndP, t);
            gameObject.transform.position = CurrentPosition;

            yield return null;
        }     
    }
}
