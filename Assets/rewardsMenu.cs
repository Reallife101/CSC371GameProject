using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class rewardsMenu : MonoBehaviour
{
    [SerializeField] Sprite reward1Image;
    [SerializeField] Sprite reward2Image;
    [SerializeField] Sprite reward3Image;

    [SerializeField] int reward1Goal;
    [SerializeField] int reward2Goal;
    [SerializeField] int reward3Goal;

    [SerializeField] Image reward1im;
    [SerializeField] Image reward2im;
    [SerializeField] Image reward3im;

    [SerializeField] scoreManager sm;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text reward1text;
    [SerializeField] TMP_Text reward2text;
    [SerializeField] TMP_Text reward3text;

    // Start is called before the first frame update
    private void OnEnable()
    {        
        reward1text.text = reward1Goal + " Score achieved: Unlocked New Song";
        reward2text.text = reward2Goal + " Score achieved: Unlocked New Song";
        reward3text.text = reward3Goal + " Score achieved: Unlocked New Song";

        reward1im.sprite = reward1Image;
        reward2im.sprite = reward2Image;
        reward3im.sprite = reward3Image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
