using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Door : MonoBehaviour {

    public int floor;
    public GameObject elevator;
    Animator door;

    // Use this for initialization
    void Start () {
        door = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision occured");
        if (other.gameObject.tag == "Player")
        {
            //elevator;
            elevator.GetComponent<ElevatorScript>().shouldDoorOpen = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        door.SetInteger("Open", 0);
    }
}