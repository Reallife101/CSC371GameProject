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
    [SerializeField]
    List<AudioClip> acs;

    private AudioSource au;

    void Start()
    {
        LoadMusic();
        prepCovers();
    }

    private void OnEnable()
    {
        au = GetComponent<AudioSource>();
        LoadMusic();
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
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[0]);
        }
    }
    public void setSong1(bool b)
    {
        songsInUse[1] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[1]);
        }
    }
    public void setSong2(bool b)
    {
        songsInUse[2] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[2]);
        }
    }
    public void setSong3(bool b)
    {
        songsInUse[3] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[3]);
        }
    }
    public void setSong4(bool b)
    {
        songsInUse[4] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[4]);
        }
    }
    public void setSong5(bool b)
    {
        songsInUse[5] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[5]);
        }
    }
    public void setSong6(bool b)
    {
        songsInUse[6] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[6]);
        }
    }
    public void setSong7(bool b)
    {
        songsInUse[7] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[7]);
        }
    }
    public void setSong8(bool b)
    {
        songsInUse[8] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[8]);
        }
    }
    public void setSong9(bool b)
    {
        songsInUse[9] = b;
        au.Stop();
        if (b)
        {
            au.PlayOneShot(acs[9]);
        }
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
