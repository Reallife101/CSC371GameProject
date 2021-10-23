using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    public GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            winScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
