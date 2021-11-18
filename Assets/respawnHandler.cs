using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnHandler : MonoBehaviour
{
    public Vector3 respawnPoint;

    [SerializeField]
    List<EnemyWaveManager> ew;
    [SerializeField]
    List<AudioClip> acs;

    private GameObject player;

    private float holdTimer;

    private AudioSource au;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        au = GetComponent<AudioSource>();
        holdTimer = 0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            holdTimer += Time.deltaTime;
            if (holdTimer > 5f)
            {
                respawn();
            }
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            holdTimer = 0;
        }
    }

    public void respawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint;
        player.GetComponent<health>().addHealth(10000);
        player.GetComponent<CharacterController>().enabled = true;
        au.PlayOneShot(acs[Random.Range(0, acs.Capacity - 1)]);

        foreach (EnemyWaveManager wave in ew)
        {
            wave.restart();
        }
    }
}
