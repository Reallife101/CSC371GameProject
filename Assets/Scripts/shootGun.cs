using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject gun;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(myPrefab, gun.transform.position+ gun.transform.forward, gun.transform.rotation);
        }
    }
}
