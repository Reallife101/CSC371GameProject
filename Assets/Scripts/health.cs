using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthMax = 15;
    public int healthTotal;
    public healthBar hb;
    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
    }

    // Update is called once per frame
    public void takeDamage(int amount)
    {
        healthTotal = healthTotal - amount;
        hb.setSlider(healthTotal);
        if (healthTotal <= 0)
            Destroy(gameObject);
    }
}
