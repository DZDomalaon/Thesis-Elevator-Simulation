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
        if (Vector3.Distance(target[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= target.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, target[current].transform.position, Time.deltaTime * speed);
        OpenLift();
        StartCoroutine(Delay());
    }

    void OpenLift()
    {
        anim.Play("DoorOpen");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
    }
}
