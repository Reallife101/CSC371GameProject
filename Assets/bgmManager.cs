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

    void Start()
    {
        au = GetComponent<AudioSource>();
        trackCounter = 0;
        au.PlayOneShot(acs[trackCounter]);
        showTrackUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= acs[trackCounter].length)
        {
            trackCounter += 1;

            if (trackCounter >= acs.Capacity)
            {
                trackCounter = 0;
            }

            timer = 0;
            au.PlayOneShot(acs[trackCounter]);
            showTrackUI();
        }
        timer += Time.deltaTime;
    }

    void showTrackUI()
    {
        mainUI.SetActive(true);
        trackUI.GetComponent<TMP_Text>().text = "Now Playing: "+ acs[trackCounter].name;
        StartCoroutine(hideUI(5f));
    }

    IEnumerator hideUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mainUI.SetActive(false);

    }
}
