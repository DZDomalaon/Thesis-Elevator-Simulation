using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Door : MonoBehaviour {

    //public GameObject elevator;
    Animator anim;
    bool doorOpen;

    // Use this for initialization
    void Start () {
        doorOpen = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision occured");
            doorOpen = true;
            openDoor("Open");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(doorOpen && other.gameObject.tag == "Player")
        {
            doorOpen = false;
            openDoor("Close");
        }
    }

    public void openDoor(string direction)
    {
        anim.SetTrigger(direction);
    }
}