using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Got to ontE");
            Player.transform.parent = transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Got to ontExit");

            Player.transform.parent = null;
        }
    }
}
