using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    public GameObject winScreen;

    [SerializeField] AudioSource au;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            winScreen.SetActive(true);
            gameObject.SetActive(false);
            player.GetComponent<movement>().enabled = false;
            player.GetComponent<lookAround>().enabled = false;
            player.transform.GetChild(1).gameObject.SetActive(false);
            au.Stop();
        }
    }
}
