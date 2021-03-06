using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public float speed;
    public bool destroyAfterTime;
    public float destroytime;

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        timer = timer + Time.deltaTime;
        if (timer > destroytime)
        {
            Destroy(gameObject);
        }
    }
}
