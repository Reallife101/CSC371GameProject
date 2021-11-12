using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnHandler : MonoBehaviour
{
    public Vector3 respawnPoint;

    [SerializeField]
    List<EnemyWaveManager> ew;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void respawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint;
        player.GetComponent<health>().addHealth(10000);
        player.GetComponent<CharacterController>().enabled = true;

        foreach (EnemyWaveManager wave in ew)
        {
            wave.restart();
        }
    }
}
