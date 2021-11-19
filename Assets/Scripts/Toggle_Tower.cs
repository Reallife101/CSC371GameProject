using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Tower : interactable
{
    public GameObject clickUI;
  //  public door ld;
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
              //  ld.numLocks -= 1;
                on = true;
                StartTheClock();

            }
            else
            {
              //  ld.numLocks += 1;
                on = false;
            }
        }
    }

    public override void deselected()
    {
        he.highlighted = false;
        clickUI.SetActive(false);
    }

    private void StartTheClock()
    {
        var Activate_Tower = this.GetComponentInParent<Activate_Tower>();

        Activate_Tower.timerIsRunning = true;

    }

}
