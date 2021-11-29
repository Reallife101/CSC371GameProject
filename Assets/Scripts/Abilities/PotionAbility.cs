using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAbility : Ability
{
    [SerializeField] GameObject PotionEffect;

    [SerializeField] CooldownBar cooldownbar;
    private float currentCool;

    private AudioSource au;
    [SerializeField] AudioClip abilityNoise;

    [SerializeField] Transform parent;

    [SerializeField] float effectDuration = 1.5f;

    // Sets Cooldown
    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 60f;
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (OnCooldown)
        {
            currentCool += 1.0f / Cooldown * Time.deltaTime;
            cooldownbar.SetCooldown(currentCool);
        }
    }

    public override void TriggerEffect(Camera cam, GameObject player)
    {
        if (!OnCooldown)
        {
            // Sets the health object and restore amount
            health h = player.GetComponent<health>();
            int restore = h.healthMax / 2;

            // Does not trigger if at max health
            if (!h.healthMax.Equals(h.healthTotal))
            {
                GameObject effect = Instantiate(PotionEffect, new Vector3(player.transform.position.x, player.transform.position.y + 1f, player.transform.position.z), new Quaternion(0f, 0f, 0f, 0f), parent);
                effect.transform.Rotate(new Vector3(-90f, 0f, 0f));
                au.PlayOneShot(abilityNoise);
                StartCoroutine(HandlePotionEffect(effect));
                currentCool = 0;
                cooldownbar.SetCooldown(0);
                // If the amount restored would bea bove max health instead set to max
                if (h.healthTotal + restore > h.healthMax)
                {
                    h.addHealth(h.healthMax - h.healthTotal);
                }
                else
                {
                    h.addHealth(restore);
                }

                StartCoroutine(HandleCoolDown());
            }
        }
    }

    private IEnumerator HandlePotionEffect(GameObject effect)
    {
        yield return new WaitForSecondsRealtime(effectDuration);
        Destroy(effect);
    }
}
