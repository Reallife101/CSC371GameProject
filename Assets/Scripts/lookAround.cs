using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);


        Vector3 worldPosition;
        Plane plane = new Plane(Vector3.up, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            transform.LookAt(new Vector3(worldPosition.x, transform.position.y, worldPosition.z));
        }


    }
}
