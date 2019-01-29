using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject[] target;
    public Transform doorToOpen;
    public float speed;
    float WPradius = 1;

    Random random = new Random();
    int current = 3;

    Animator anim;
    void Start ()
    {
        anim = doorToOpen.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
          if()
    }
}
