using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bosshealth : health
{
    // Start is called before the first frame update
    public healthBar hb;

    public bool invincible;

    [SerializeField] GameObject invincibleUI;
    [SerializeField] cellHealth ch1;
    [SerializeField] cellHealth ch2;
    [SerializeField] List<AudioClip> damageSounds;

    [SerializeField] GameObject bossFight;
    [SerializeField] GameObject lazers;
    [SerializeField] GameObject newPlatform;
    [SerializeField] AudioClip win1;
    [SerializeField] AudioSource au2;

    AudioSource au;

    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
        au = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (invincible)
        {
            invincibleUI.SetActive(true);
        }
        else
        {
            invincibleUI.SetActive(false);
        }

        if (ch1.healthTotal <=0 && ch2.healthTotal <=0)
        {
            invincible = false;
        } else
        {
            invincible = true;
        }
    }

    // Update is called once per frame
    public override void takeDamage(int amount)
    {
        if (invincible)
        {
            return;
        }

        healthTotal = Mathf.Max(healthTotal - amount, 0);
        hb.setSlider(healthTotal);
        au.PlayOneShot(damageSounds[Random.Range(0, damageSounds.Capacity - 1)], 1f);


        if (healthTotal <= 0)
        {
            au2.PlayOneShot(win1);
            newPlatform.SetActive(true);
            lazers.SetActive(false);
            bossFight.SetActive(false);

            //SceneManager.LoadScene("Win Scene");
        }
    }

    public override void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
    }

}
