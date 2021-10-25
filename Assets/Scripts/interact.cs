using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public LayerMask PlayerLayerMask;
    public float selectDistance = 10f;

    private switchButton lastIB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Right
        if (Physics.Raycast(transform.position, transform.forward, out hit, selectDistance, ~PlayerLayerMask))
        {
            if (hit.collider.gameObject.GetComponent<switchButton>())
            {
                lastIB = hit.collider.gameObject.GetComponent<switchButton>();
                lastIB.selected();
            }
        }
        else if (lastIB)
        {
            lastIB.deselected();
            lastIB = null;
        }
    }
}
