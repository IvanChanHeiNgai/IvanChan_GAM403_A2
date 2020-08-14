using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string lvl;
    public Animator anim;
    public GameObject SoundTrack;

    private void Awake()
    {
        //check if there is another main SoundTrack
        var mt = GameObject.FindGameObjectsWithTag("MainTrack");
        if(mt.Length > 1)
        {
            Destroy(mt[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if player hits space load the level
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(fade());
        }
        //if player hit escape, wuit application
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator fade()
    {
        //dont destory soundtrack on load
        if(SoundTrack != null)
        {
            DontDestroyOnLoad(SoundTrack);
        }
        anim.SetBool("fade", true);
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(lvl);
    }
}
