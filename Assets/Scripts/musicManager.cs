using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager : MonoBehaviour
{
    public bool[] songsInUse = new bool[10];
    public bool[] songsUnlocked = new bool[10];

    [SerializeField]
    List<GameObject> songsUI;

    void Start()
    {
        prepCovers();
    }
    
    private void prepCovers()
    {
        for (int i = 0; i< 10; i++)
        {
            if (songsUnlocked[i])
            {
                songsUI[i].SetActive(true);
            }
            else
            {
                songsUI[i].SetActive(false);
            }
        }
    }

    public void setSong0(bool b)
    {
        songsInUse[0] = b;
    }
    public void setSong1(bool b)
    {
        songsInUse[1] = b;
    }
    public void setSong2(bool b)
    {
        songsInUse[2] = b;
    }
    public void setSong3(bool b)
    {
        songsInUse[3] = b;
    }
    public void setSong4(bool b)
    {
        songsInUse[4] = b;
    }
    public void setSong5(bool b)
    {
        songsInUse[5] = b;
    }
    public void setSong6(bool b)
    {
        songsInUse[6] = b;
    }
    public void setSong7(bool b)
    {
        songsInUse[7] = b;
    }
    public void setSong8(bool b)
    {
        songsInUse[8] = b;
    }
    public void setSong9(bool b)
    {
        songsInUse[9] = b;
    }

    public void SaveMusic()
    {
        saveMusic.SaveMusic(this);
    }

    public void LoadMusic()
    {
        musicData data = saveMusic.loadMusic();
        if (data != null)
        {
            songsInUse = data.songsInUse;
            songsUnlocked = data.songsUnlocked;
        }
        else
        {
            songsInUse = new bool[10];
            songsUnlocked = new bool[10];
            songsInUse[0] = true;
            songsUnlocked[0] = true;
        }

        updateUI();
    }

    void updateUI()
    {
        for (int i = 0; i < 10; i++)
        {
            if (songsInUse[i])
            {
                songsUI[i].GetComponentInChildren<Toggle>().isOn = true;
            }
            else
            {
                songsUI[i].GetComponentInChildren<Toggle>().isOn = false;
            }
        }
    }


}
