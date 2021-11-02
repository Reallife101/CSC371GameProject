using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthMax = 15;
    public int healthTotal;
    public healthBar hb;

    private StyleManager sm;
    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
        sm = GameObject.FindGameObjectWithTag("StyleManager").GetComponent<StyleManager>();
    }

    // Update is called once per frame
    public void takeDamage(int amount)
    {
        healthTotal = healthTotal - amount;
        hb.setSlider(healthTotal);
        if (healthTotal <= 0)
        {
            Destroy(gameObject);
            sm.numKills += 1;
            CameraShaker.Instance.ShakeOnce(1f, 10f, 0.05f, .05f);
        }
    }

    public void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
    }
}
