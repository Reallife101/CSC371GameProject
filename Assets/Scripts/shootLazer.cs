using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLazer : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {   
    }

    private void OnEnable()
    {
        StartCoroutine(attack(1f));
    }

    IEnumerator attack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(projectile, transform.position + transform.forward * 2, transform.rotation);

        StartCoroutine(attack(.1f));

    }
}
