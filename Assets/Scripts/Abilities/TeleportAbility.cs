using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : Ability
{

    [SerializeField] GameObject TeleportEffect;

    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask wallMask;
    [SerializeField] CharacterController troubleMaker;

    public float Range = 10f;

    [SerializeField] CooldownBar cooldownbar;
    private float currentCool;

    private AudioSource au;
    [SerializeField] AudioClip abilityNoise;

    [SerializeField] float effectDuration = 4f;

    private void Awake()
    {
        if (Cooldown.Equals(Mathf.NegativeInfinity))
            Cooldown = 30f;
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
        // Sets the player postion
        Vector3 playerPos = player.transform.position;
        // Gets the target point
        Vector3 hitPoint = getTargetPoint(cam, groundMask, wallMask, playerPos);

        if (!hitPoint.Equals(Vector3.positiveInfinity))
        {
            // Checks if the point is in range
            if (InRange(playerPos, hitPoint, Range))
            {
                // Is in range, sets y to make sure no clipping
                hitPoint = new Vector3(hitPoint.x, playerPos.y, hitPoint.z);
            }
            else
            {
                // Is not in range, sets the hitPoint to a new vector based on scaled direction
                Vector3 scaledDirection = new Vector3(hitPoint.x - playerPos.x, 0f,
                    hitPoint.z - playerPos.z).normalized * Range;

                hitPoint = new Vector3(playerPos.x + scaledDirection.x,
                    playerPos.y, playerPos.z + scaledDirection.z);
            }

            // Makes sure teleport will mot teleport off the ground
            if(player.GetComponent<movement>().checkMove(hitPoint))
            {
                au.PlayOneShot(abilityNoise);
                GameObject effect = Instantiate(TeleportEffect, hitPoint,
                    new Quaternion(0f, 0f, 0f, 0f));
                troubleMaker.enabled = false;
                player.GetComponent<Collider>().enabled = false;
                player.GetComponent<MeshRenderer>().enabled = false;
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.position = hitPoint;
                StartCoroutine(HandleTeleportEffect(effect, player));
                troubleMaker.enabled = true;
                currentCool = 0;
                cooldownbar.SetCooldown(0);
                StartCoroutine(HandleCoolDown());
            }
        }
    }

    private IEnumerator HandleTeleportEffect(GameObject effect, GameObject player)
    {
        yield return new WaitForSecondsRealtime(effectDuration);
        player.GetComponent<Collider>().enabled = true;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.transform.GetChild(1).gameObject.SetActive(true);
        Destroy(effect);
    }
}
