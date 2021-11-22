using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshealth : health
{
    // Start is called before the first frame update
    public healthBar hb;

    public bool invincible;

    [SerializeField] GameObject invincibleUI;
    [SerializeField] cellHealth ch1;
    [SerializeField] cellHealth ch2;

    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
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

        healthTotal = healthTotal - amount;
        hb.setSlider(healthTotal);


        if (healthTotal <= 0)
        {
            //do something
        }
    }

    public override void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
    }

}
