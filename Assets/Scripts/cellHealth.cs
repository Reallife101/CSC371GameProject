using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellHealth : health
{
    // Start is called before the first frame update
    public healthBar hb;

    [SerializeField] Material yellow;
    [SerializeField] Material blue;
    [SerializeField] List<AudioClip> acs;
    [SerializeField] GameObject cellBeam;

    AudioSource au;
    bool playAudio;

    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
        au = GetComponent<AudioSource>();
        playAudio = true;
    }

    // Update is called once per frame
    public override void takeDamage(int amount)
    {

        healthTotal = Mathf.Max(0, healthTotal - amount);
        hb.setSlider(healthTotal);


        if (healthTotal <= 0 && playAudio)
        {
            gameObject.GetComponent<MeshRenderer>().material = yellow;
            au.PlayOneShot(acs[Random.Range(0, acs.Capacity - 1)]);
            playAudio = false;
            cellBeam.SetActive(false);
        }
    }

    public override void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
        gameObject.GetComponent<MeshRenderer>().material = blue;
        playAudio = true;
        cellBeam.SetActive(true);
    }
}
