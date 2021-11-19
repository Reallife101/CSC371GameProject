using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatMode : MonoBehaviour
{
    [SerializeField]
    GameObject UI;
    [SerializeField]
    health h;

    int oldHealthMax;
    bool cheat;
    // Start is called before the first frame update
    void Start()
    {
        oldHealthMax = h.healthMax;
        cheat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!cheat)
            {
                oldHealthMax = h.healthMax;
                UI.SetActive(true);
                h.healthMax = 99999999;
                h.healthTotal = h.healthMax;
                cheat = true;
            }
            else
            {
                resume();
            }
        }
    }

    public void resume()
    {
        UI.SetActive(false);
        h.healthMax = oldHealthMax;
        h.healthTotal = h.healthMax;
        cheat = false;
    }

}
