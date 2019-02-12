using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public bool shouldDoorOpen;
    public bool isFull;
    public bool goingUp;
    public bool goingDown;
    public Animator doorsOpen;

    void StopElevator()
    {
        // Stop 
    }

    void OpenDoors()
    {
        // Start Open Door Animation
    }

    void CloseDoor()
    {
        // Start Close door aniation
    }

    void Start()
    {
        //sdoorOpen = GetComponent<Animator>();

    }

    // Update is called once per frame
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

    /** Colldi
     * 
     * */
}
