using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchButton : interactable
{
    public GameObject clickUI;
    public lockedDoor ld;
    private bool gotten = false;
    // Start is called before the first frame update
    void Start()
    {
        he = GetComponent<HighlightPlus.HighlightEffect>();
        gotten = false;
    }

    public override void selected()
    {
        if (!gotten)
        {
            he.highlighted = true;
            clickUI.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            if (!gotten)
            {
                ld.numLocks -= 1;
                gotten = true;
                he.highlighted = false;
                clickUI.SetActive(false);

            }
        }
    }

    public override void deselected()
    {
        if (!gotten)
        {
            he.highlighted = false;
            clickUI.SetActive(false);
        }
    }
}
