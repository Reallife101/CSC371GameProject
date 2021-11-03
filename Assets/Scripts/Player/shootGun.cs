using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject gun;

    private float maxMana = 4;
    private float currentMana;

    public manabar manabar;

    private void Start()
    {
        currentMana = maxMana;
        manabar.SetMaxMana(maxMana);
        manabar.SetMana(currentMana);
    }
    // Update is called once per frame
    void Update()
    {
        if(currentMana < 4)
        {
            currentMana = Mathf.Min(maxMana, currentMana + Time.deltaTime);
            manabar.SetMana(currentMana);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            if(currentMana >= 1)
            {
                Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation);
                currentMana -= 1;
                manabar.SetMana(currentMana);
            }
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
                if(currentMana >= 2)
                {
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * 10));
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * -10));
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up));
                    currentMana -= 2;
                    manabar.SetMana(currentMana);
                }
        }

    }
}
