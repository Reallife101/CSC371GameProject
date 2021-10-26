using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleDoor : door
{
    public GameObject doorModel;

    // Update is called once per frame
    void Update()
    {
        if (numLocks <= 0)
        {
            doorModel.SetActive(false);
        }
        else
        {
            doorModel.SetActive(true);
        }
    }
}
