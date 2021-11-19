using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenu : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject music;
    // Start is called before the first frame update
    public void setMainMenu()
    {
        music.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void setMusicUI()
    {
        mainmenu.SetActive(false);
        music.SetActive(true);
    }
}
