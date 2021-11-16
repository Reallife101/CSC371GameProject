using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject UI;
    [SerializeField]
    lookAround la;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            UI.SetActive(true);
            la.enabled = false;
        }
    }

    public void resume()
    {
        Time.timeScale = 1f;
        UI.SetActive(false);
        la.enabled = true;
    }
    public void quit()
    {
        Application.Quit();
    }
}
