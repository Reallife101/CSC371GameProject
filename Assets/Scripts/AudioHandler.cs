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
    [SerializeField]
    AudioClip FirstKill;
    [SerializeField]
    AudioClip SecondKill;
    [SerializeField]
    AudioClip ThirdKill;
    [SerializeField]
    AudioClip FourthKill;
    [SerializeField]
    AudioClip FifthKill;
    [SerializeField]
    AudioClip SixthKill;
    [SerializeField]
    List<AudioClip> LevelUp;


    private AudioSource audioPlayer;

    private bool levelUpPlaying;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        //hovertime = hoverSound.length;
    }

    // Style Sounds
    public void playDRankup()
    {
        audioPlayer.PlayOneShot(DRankup, 1f);
    }

    public void playCRankup()
    {
        audioPlayer.PlayOneShot(CRankup, 1f);
    }
    public void playBRankup()
    {
        audioPlayer.PlayOneShot(BRankup, 1f);
    }
    public void playARankup()
    {
        audioPlayer.PlayOneShot(ARankup, 1f);
    }
    public void playSRankup()
    {
        audioPlayer.PlayOneShot(SRankup, 1f);
    }
    public void playSSSRankup()
    {
        audioPlayer.PlayOneShot(SSSRankup, 1f);
    }
    public void playFirstKill()
    {
        audioPlayer.PlayOneShot(FirstKill, .45f);
    }

    public void playSecondKill()
    {
        audioPlayer.PlayOneShot(SecondKill, .45f);
    }
    public void playThirdKill()
    {
        audioPlayer.PlayOneShot(ThirdKill, .45f);
    }
    public void playFourthKill()
    {
        audioPlayer.PlayOneShot(FourthKill, .45f);
    }
    public void playFifthKill()
    {
        audioPlayer.PlayOneShot(FifthKill, .45f);
    }
    public void playSixthKill()
    {
        audioPlayer.PlayOneShot(SixthKill, .45f);
    }
    public void playLevelUp()
    {
        if (!levelUpPlaying)
        {
            int selction = Random.Range(0, LevelUp.Capacity - 1);
            audioPlayer.PlayOneShot(LevelUp[selction]);
            levelUpPlaying = true;
            StartCoroutine(handleLevelUp(selction));
        }
    }
    private IEnumerator handleLevelUp(int selection)
    {
        yield return new WaitForSecondsRealtime(LevelUp[selection].length);
        levelUpPlaying = false;
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
