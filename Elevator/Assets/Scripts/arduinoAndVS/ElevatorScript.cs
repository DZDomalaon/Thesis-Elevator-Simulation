using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public bool shouldDoorOpen;
    public bool isFull;
    public bool goingUp;
    public Animator doorsOpen;
    public Transform[] elev;

    void StopElevator()
    {
        
    }

    void OpenDoors()
    {
        
    }

    void CloseDoor()
    {
        // Start Close door aniation
    }

    void Start()
    {
        //sdoorOpen = GetComponent<Animator>();

    }

    void Update()
    {
        if(shouldDoorOpen)
        {
            doorsOpen.SetBool("Open", true);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        // IF() 
    }

    Transform getNearestElevator(Transform[] elev)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 current = transform.position;
        foreach(Transform t in elev)
        {
            float dist = Vector3.Distance(t.position, GameObject.Find("Player").transform.position);
            if(dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
