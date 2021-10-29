using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myself = transform;
        var parent = transform.parent;
        if (parent.GetChild(0) == myself)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <=0 )
        {
            var hold = GetNext();
            Debug.Log(hold);
            hold.gameObject.SetActive(true);
            gameObject.SetActive(false);

        }
    }

    Transform GetNext()
    {
        var myself = transform;
        var parent = transform.parent;
        var childCount = parent.childCount;
        for (int i = 0; i < childCount - 1; i++)
        {
            if (parent.GetChild(i) == myself)
                return parent.GetChild(i + 1);
        }
        return parent.GetChild(0);
    }
}
