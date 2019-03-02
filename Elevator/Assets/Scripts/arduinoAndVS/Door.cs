using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    //public GameObject elevator;
    Animator anim;
    public bool doorOpen;

    // Use this for initialization
    void Start () {
        doorOpen = false;
        anim = GetComponent<Animator>();
    }
    void Update(){
        if(doorOpen)
        {
            anim.SetTrigger("Open");
        }
        else if(!doorOpen)
        {
            anim.SetTrigger("Close");
        }
    }

}
