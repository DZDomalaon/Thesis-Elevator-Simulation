using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public static bool shouldDoorOpen;
    public static bool isFull;
    public Animator doorOpen;
    public Elevator elevatorScript;

    void Start()
    {
        doorOpen = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldDoorOpen)
        {
            Debug.Log("Door should be open already");
            //doorOpen.setInteger("Open", 1);
        }
    }
}
