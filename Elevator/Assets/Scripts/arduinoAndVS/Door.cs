using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    //public GameObject elevator;
    Animator anim;
    public int doorOpen;

    // Use this for initialization
    void Start () {
        doorOpen = 0;
        anim = GetComponent<Animator>();
    }
    void Update(){
        if(doorOpen == 1)
        {
            anim.SetTrigger("Open");
        }
        else if(doorOpen == 2)
        {
            anim.SetTrigger("Close");
        }
        else if(doorOpen == 3)
        {
            anim.SetTrigger("Idle");
        }
    }

}
