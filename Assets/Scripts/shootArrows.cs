using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrows : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject gun;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * 10));
            Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * 5));
            Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation);
            Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * -5));
            Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * -10));
        }
    }
}
