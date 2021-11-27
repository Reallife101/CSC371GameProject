using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class genhealth : health
{
    // Start is called before the first frame update
    public healthBar hb;

    [SerializeField]
    bool isPlayer;

    [SerializeField]
    List<AudioClip> acs;
    [SerializeField]
    AudioSource au;
    [SerializeField]
    GameObject redJelly;


    private StyleManager sm;
    private respawnHandler rh;
    void Start()
    {
        healthTotal = healthMax;
        hb.sliderMax(healthMax);
        sm = GameObject.FindGameObjectWithTag("StyleManager").GetComponent<StyleManager>();
        rh = GameObject.FindGameObjectWithTag("respawnHandler").GetComponent<respawnHandler>();
    }

    // Update is called once per frame
    public override void takeDamage(int amount)
    {
        healthTotal = healthTotal - amount;
        hb.setSlider(healthTotal);

        if (isPlayer)
        {
            redJelly.SetActive(true);
            StartCoroutine(hideUI(0.1f));
        }

        if (healthTotal <= 0)
        {
            if (isPlayer)
            {
                rh.respawn();
            }
            else
            {
                au.PlayOneShot(acs[Random.Range(0, acs.Capacity-1)]);
                sm.numKills += 1;
                CameraShaker.Instance.ShakeOnce(1f, 10f, 0.05f, .05f);
                Destroy(gameObject);
            }
        }
    }

    public override void addHealth(int amount)
    {
        healthTotal = Mathf.Min(healthTotal + amount, healthMax);
        hb.setSlider(healthTotal);
    }

    IEnumerator hideUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        redJelly.SetActive(false);

    }
}
