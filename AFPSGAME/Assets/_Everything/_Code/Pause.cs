using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //Input Systen Setup
    _Input input;

    public GameObject PauseUI;
    public GameObject NormalUI;

    public bool paused;

    public PlayerMovement PM;
    public AssultRifle ar;
    public Shotgun sg;
    public Pistol p;
    public grenadeThrow gre;
    public Slowmo sm;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.Pause.performed += ctx => pause();
    }

    public void pause()
    {
        paused = !paused;
        if(paused)
        {
            //if paused unlock the mouse cursor
            Cursor.lockState = CursorLockMode.None;
            //pause time
            Time.timeScale = 0;
            //disable all the hud and enable the pausse menu
            NormalUI.SetActive(false);
            PauseUI.SetActive(true);
            PM.enabled = false;
            ar.enabled = false;
            sg.enabled = false;
            p.enabled = false;
            gre.enabled = false;
            sm.enabled = false;
        }
        else
        {
            //if unpaused lock the mouse cursor
            Cursor.lockState = CursorLockMode.Locked;
            //unpause time
            Time.timeScale = 1;
            //reenable the hud
            NormalUI.SetActive(true);
            PauseUI.SetActive(false);
            PM.enabled = true;
            ar.enabled = true;
            sg.enabled = true;
            p.enabled = true;
            gre.enabled = true;
            sm.enabled = true;
        }
    }

    public void mainMenu()
    {
        //if player hits the Quit to main menu button, load main menu scene
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        //if player hit the quit to destop button, quit the application
        Time.timeScale = 1;
        Application.Quit(); //this doesnt work in editor only on build
    }

    //Enable and disable Input System
    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }
}
