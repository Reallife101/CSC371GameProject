using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    [SerializeField]
    AudioClip DRankup;
    [SerializeField]
    AudioClip CRankup;
    [SerializeField]
    AudioClip BRankup;
    [SerializeField]
    AudioClip ARankup;
    [SerializeField]
    AudioClip SRankup;
    [SerializeField]
    AudioClip SSSRankup;


    private AudioSource audioPlayer;

    private float hovertime;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        //hovertime = hoverSound.length;
    }

    // Style Sounds
    public void playDRankup()
    {
        audioPlayer.PlayOneShot(DRankup, 0.7f);
    }

    public void playCRankup()
    {
        audioPlayer.PlayOneShot(CRankup, 0.7f);
    }
    public void playBRankup()
    {
        audioPlayer.PlayOneShot(BRankup, 0.7f);
    }
    public void playARankup()
    {
        audioPlayer.PlayOneShot(ARankup, 0.7f);
    }
    public void playSRankup()
    {
        audioPlayer.PlayOneShot(SRankup, 0.7f);
    }
    public void playSSSRankup()
    {
        audioPlayer.PlayOneShot(SSSRankup, 0.7f);
    }
    /*
    public void playHover(float tm)
    {
        hovertime = hovertime + tm;
        if (hovertime > hoverSound.length)
        {
            audioPlayer.PlayOneShot(hoverSound, 0.7f);
            hovertime = 0;
        }

    }
    */
}
