using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject[] wp;
    public bool shouldDoorOpen;
    public bool isFull;
    public bool goingUp;
    public Animator doorsOpen;

    bool up;

    float speed = 8;

    // false is down, true is up

    void Start()
    {
       //  up = GetComponent<AutomaticMovement>().isUp;
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision col)
    {
        // IF()
    }

    // Transform getNearestElevator(Transform[] elev)
    // {
    //     // float dist = Vector3.Distance(t.position, GameObject.Find("Player").transform.position);
    //
    // }
}
