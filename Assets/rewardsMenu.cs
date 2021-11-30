using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rewardsMenu : MonoBehaviour
{
    [SerializeField] Sprite reward1Image;
    [SerializeField] Sprite reward2Image;
    [SerializeField] Sprite reward3Image;

    [SerializeField] int reward1Goal;
    [SerializeField] int reward2Goal;
    [SerializeField] int reward3Goal;

    [SerializeField] int reward1trackNum;
    [SerializeField] int reward2trackNum;
    [SerializeField] int reward3trackNum;

    [SerializeField] Image reward1im;
    [SerializeField] Image reward2im;
    [SerializeField] Image reward3im;

    [SerializeField] scoreManager sm;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text reward1text;
    [SerializeField] TMP_Text reward2text;
    [SerializeField] TMP_Text reward3text;

    [SerializeField] string nextScene;

    // Start is called before the first frame update
    private void OnEnable()
    {        
        reward1text.text = reward1Goal + " Score achieved: Unlocked New Song";
        reward2text.text = reward2Goal + " Score achieved: Unlocked New Song";
        reward3text.text = reward3Goal + " Score achieved: Unlocked New Song";

        reward1im.sprite = reward1Image;
        reward2im.sprite = reward2Image;
        reward3im.sprite = reward3Image;

        score.text = "Score: " + sm.score;

        reward1text.gameObject.SetActive(false);
        reward2text.gameObject.SetActive(false);
        reward3text.gameObject.SetActive(false);

        musicData data = saveMusic.loadMusic();

        if (sm.score >= reward1Goal)
        {
            reward1text.gameObject.SetActive(true);
            data.songsUnlocked[reward1trackNum] = true;
        }

        if (sm.score >= reward2Goal)
        {
            reward2text.gameObject.SetActive(true);
            data.songsUnlocked[reward2trackNum] = true;
        }

        if (sm.score >= reward3Goal)
        {
            reward3text.gameObject.SetActive(true);
            data.songsUnlocked[reward3trackNum] = true;
        }

        saveMusic.SaveMusic(data);
    }

    public void loadScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}