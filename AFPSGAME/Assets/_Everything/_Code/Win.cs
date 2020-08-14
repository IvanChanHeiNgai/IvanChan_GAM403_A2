using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject MissionComplete;

    void OnTriggerEnter(Collider other)
    {
        //when player enters the trigger volume, enable text "Mission Complete" and load to main menu
        if(other.CompareTag("Player"))
        {
            MissionComplete.SetActive(true);
            StartCoroutine(MC());
        }
    }

    IEnumerator MC()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
