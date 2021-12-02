using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    //private Rigidbody rBody;
    bool atStart = true;
    bool atFinish = false;
    void Start()
    {
        //rBody = GetComponent<Rigidbody>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        //StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        //fromAtoB(gameObject, startPosition, speed);
    }

    void FixedUpdate()
    {


        float step = speed * Time.deltaTime; // calculate distance to move
        print("Atstart:  " + atStart);
        print("AtFinish:  " + atFinish);
        if (atStart && !atFinish)
        {
            atFinish = fromAtoB(endPosition, step);
            print("going from SP to EP");
            if (atFinish)
            {
                atStart = false;
            }
        }

        if (!atStart && atFinish)
        {
            print("going from EP to SP");

            atStart = fromAtoB(startPosition, step);
            if (atStart)
                atFinish = false;
        }


        /*
        print("beginning of update!");
        // get rid of coroutine, get private varaible called direction, 


        bool temp = AlmostEqual(this.transform.position, endPosition, (float)0.5);
        bool temp1 = AlmostEqual(this.transform.position, startPosition, (float)0.5);
        print(temp1);
        print(temp);
        if (AlmostEqual(rBody.position, startPosition, (float)0.5) && !atStart)
        {
            print("got here! Start");
            atStart = true;
            atFinish = false;
            //StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
            Move(gameObject, endPosition, speed);
        }
        if (AlmostEqual(rBody.position, endPosition, (float) 0.5) && !atFinish)
            //rBody.position.Equals(endPosition))
        {
            print("got into Ends");
            atStart = false;
            atFinish = true;
            Move(gameObject, startPosition, speed);
            //StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        //if (rBody.position.Equals(startPosition))
        */
    }

    public static bool AlmostEqual(Vector3 v1, Vector3 v2, float tolerance)
    {

        if (Mathf.Abs(v1.x - v2.x) > tolerance) return false;
        if (Mathf.Abs(v1.y - v2.y) > tolerance) return false;
        if (Mathf.Abs(v1.z - v2.z) > tolerance) return false;
        return true;
    }




    bool fromAtoB ( Vector3 finish, float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, finish, step);
        
        if (Vector3.Distance(transform.position, finish) < 0.001f)
        {
            return true;
        }
        else
        {
            print("fromAtoB: ");
            return false;

        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = transform;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }*/



}
