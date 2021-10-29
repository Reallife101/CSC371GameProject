using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject gun;

    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(myPrefab, gun.transform.position+ gun.transform.forward, gun.transform.rotation);
        }

        if (Input.GetButton("Fire2"))
        {
            timer += Time.deltaTime;
            
            if (timer > 1.5f)
            {
                Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * 10));
                Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * -10));
                Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up));
                timer = 0f;

            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            timer = 0;
        }
    }
}
