using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class interact : MonoBehaviour
{
    [SerializeField]
    float selectDistance = 10f;

    private interactable lastIB;
    private bool deselect;


    // Start is called before the first frame update
    void Start()
    {
        deselect = false;
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, selectDistance);

        bool foundIB = false;

        foreach (var hitCollider in hitColliders)
        {
            var ib = hitCollider.gameObject.GetComponent<interactable>();
            

            if (ib)
            {
                lastIB = ib;
                lastIB.selected();
                deselect = true;
            }
            else if (lastIB = ib)
            {
                foundIB = true;
            }
            /*
            else if (deselect)
            {
                lastIB.deselected();
                lastIB = null;
                deselect = false;
            }
            */
        }

        if (deselect && !foundIB)
        {
            lastIB.deselected();
            lastIB = null;
            deselect = false;
        }

    }
}
