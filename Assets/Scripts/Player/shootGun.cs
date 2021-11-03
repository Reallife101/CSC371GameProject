using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{

    public GameObject myPrefab;
    public GameObject gun;

    public int maxMana = 1000;
    public int currentMana;

    [SerializeField] manabar manabar;

    private void Start()
    {

        currentMana = maxMana;
        manabar.SetMaxMana(maxMana);
        manabar.SetMana(currentMana);
    }
    // Update is called once per frame
    void Update()
    {
        if(currentMana < 1000)
        {
            currentMana += 2;
            manabar.SetMana(currentMana);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            if(currentMana >= 250)
            {
                Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation);
                currentMana -= 250;
                manabar.SetMana(currentMana);
            }
            
        }

        if (Input.GetButtonDown("Fire2"))
        {
                if(currentMana >= 500)
                {
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * 10));
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up * -10));
                    Instantiate(myPrefab, gun.transform.position + gun.transform.forward, gun.transform.rotation * Quaternion.Euler(Vector3.up));
                    currentMana -= 500;
                    manabar.SetMana(currentMana);
                }
        }

    }
}
