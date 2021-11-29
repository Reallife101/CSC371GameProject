using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneManager : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Video.VideoPlayer videoplayer;

    [SerializeField]
    GameObject ui;

    [SerializeField]
    string sc;

    // Start is called before the first frame update
    private void Update()
    {
        if (videoplayer.enabled && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(sc);
        }
    }


    public void playVideo()
    {
        videoplayer.enabled = true;
        ui.SetActive(false);
        videoplayer.Play();
        videoplayer.loopPointReached += load;
    }

    void load(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(sc);
    }
}
