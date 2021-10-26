using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleButton : interactable
{
    public GameObject clickUI;
    public door ld;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        he = GetComponent<HighlightPlus.HighlightEffect>();
    }

    public override void selected()
    {
        
        he.highlighted = true;
        clickUI.SetActive(true);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!on)
            {
                ld.numLocks -= 1;
                on = true;

            }
            else
            {
                ld.numLocks += 1;
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
