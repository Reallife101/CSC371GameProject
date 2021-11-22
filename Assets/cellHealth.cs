using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellHealth : health
{
    // Start is called before the first frame update
    public healthBar hb;

    [SerializeField]
    bosshealth bh;

    [SerializeField]
    Material yellow;

    [SerializeField]
    Material blue;

    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
    }

    // Update is called once per frame
    public override void takeDamage(int amount)
    {

        healthTotal = healthTotal - amount;
        hb.setSlider(healthTotal);


        if (healthTotal <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = yellow;
        }
    }

    public override void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
        gameObject.GetComponent<MeshRenderer>().material = blue;
    }
}
