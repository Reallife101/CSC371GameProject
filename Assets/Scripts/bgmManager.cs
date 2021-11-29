using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bgmManager : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> acs;
    [SerializeField]
    GameObject trackUI;
    [SerializeField]
    GameObject mainUI;
    private AudioSource au;
    private int trackCounter;
    private float timer;
    private musicData data;
    private List<AudioClip> usedClips = new List<AudioClip>();

    void Start()
    {
        data = saveMusic.loadMusic();
        addSongs();
        au = GetComponent<AudioSource>();
        trackCounter = 0;
        au.PlayOneShot(usedClips[trackCounter]);
        showTrackUI();
    }
    
    void addSongs()
    {
        for (int i=0; i< acs.Count; i++)
        {
            Debug.Log(i);
            Debug.Log(acs[i].name);
            if (data.songsInUse[i])
            {
                usedClips.Add(acs[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= usedClips[trackCounter].length)
        {
            trackCounter += 1;

            if (trackCounter >= usedClips.Count)
            {
                trackCounter = 0;
            }

            timer = 0;
            au.PlayOneShot(usedClips[trackCounter]);
            showTrackUI();
        }
        timer += Time.deltaTime;
    }

    void showTrackUI()
    {
        mainUI.SetActive(true);
        trackUI.GetComponent<TMP_Text>().text = "Now Playing: "+ usedClips[trackCounter].name;
        StartCoroutine(hideUI(5f));
    }

    IEnumerator hideUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mainUI.SetActive(false);

    }
}
