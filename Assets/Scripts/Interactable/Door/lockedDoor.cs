using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : door
{

    // Update is called once per frame
    void Update()
    {
        if (numLocks <=0)
        {
            Destroy(gameObject);
        }
    }
}
