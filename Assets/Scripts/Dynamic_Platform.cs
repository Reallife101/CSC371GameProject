using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic_Platform : MonoBehaviour
{

    [SerializeField] float _time;
    public Transform[] waypointArray;
    [SerializeField] bool _Moving;
    [SerializeField] float _percentsPerSecond; // %2 of the path moved per second
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.transform.SetParent(gameObject.transform);
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.transform.SetParent(null);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_Moving)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash(
                "path", waypointArray,
                "time", _time,
                "easetype", iTween.EaseType.linear)); ;
        }
      
    }

    void OnDrawGizmos()
    {
        //Visual. Not used in movement
        iTween.DrawPath(waypointArray);
    }






}
