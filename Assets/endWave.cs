using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endWave : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            transform.parent.GetComponent<startWaves>().endWaves();
           gameObject.SetActive(false);

        }
    }
}
