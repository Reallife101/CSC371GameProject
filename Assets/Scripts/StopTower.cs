using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tower;
    public GameObject RotatePlatform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Tower.GetComponent<Activate_Tower>().pauseTower();
           /* if (RotatePlatform != null)
            {
                RotatePlatform.GetComponent<RotatePlatform>
            }*/

        }
    }

}
