using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    Canvas MainMenu;
    public bool start = false;
    // Use this for initialization    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && start == true)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Play()
    {
        
        MainMenu = Canvas.FindObjectOfType<Canvas>();
        Debug.Log(MainMenu);
        MainMenu.GetComponent<Image>().sprite = Resources.Load<Sprite>("MainMenu/InstructionScreen 1");
        MainMenu.transform.GetChild(0).gameObject.SetActive(false);
        MainMenu.transform.GetChild(1).gameObject.SetActive(false);
        start = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
