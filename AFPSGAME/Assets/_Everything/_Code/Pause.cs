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
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
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
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Time.timeScale = 1;
        Application.Quit();
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
