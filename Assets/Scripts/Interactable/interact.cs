using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public LayerMask PlayerLayerMask;
    public float selectDistance = 10f;

    private interactable lastIB;


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
            if (hit.collider.gameObject.GetComponent<interactable>())
            {
                lastIB = hit.collider.gameObject.GetComponent<interactable>();
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
