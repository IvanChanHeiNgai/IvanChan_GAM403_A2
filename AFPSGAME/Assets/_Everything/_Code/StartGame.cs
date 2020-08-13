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
        var mt = GameObject.FindGameObjectsWithTag("MainTrack");
        if(mt.Length > 1)
        {
            Destroy(mt[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(fade());
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator fade()
    {
        if(SoundTrack != null)
        {
            DontDestroyOnLoad(SoundTrack);
        }
        anim.SetBool("fade", true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(lvl);
    }
}
