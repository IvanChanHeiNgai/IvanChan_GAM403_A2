using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject MissionComplete;

    void OnTriggerEnter(Collider other)
    {
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
