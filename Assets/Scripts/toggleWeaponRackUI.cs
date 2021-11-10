using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWeaponRackUI : interactable
{
    public GameObject clickUI;
    public GameObject WeaponRackUI;
    public bool on = false;

    private float buttonCooldown = 0.2f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        he = GetComponent<HighlightPlus.HighlightEffect>();
        timer = buttonCooldown;
    }
    private void Update()
    {
        timer = Mathf.Min(timer + Time.deltaTime, buttonCooldown);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            selected();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deselected();
        }
    }

    public override void selected()
    {

        he.highlighted = true;
        clickUI.SetActive(true);

        if (Input.GetKey(KeyCode.F) && timer >= buttonCooldown)
        {
            timer = 0;

            if (!on)
            {
                WeaponRackUI.SetActive(true);
                on = true;

            }
            else
            {
                WeaponRackUI.SetActive(false);
                on = false;
            }
        }
    }

    public override void deselected()
    {
        he.highlighted = false;
        clickUI.SetActive(false);
    }
}
