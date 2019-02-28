using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public GameObject[] wp;
    int current = 0;
    float speed = 8;
    float WPradius = 1;
    Rigidbody rigid;
    bool isUp;
    bool isWaitng = false;
    bool isMoving = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        isUp = true;
        //StartCoroutine(Wait());
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wp[current].transform.position, transform.position) < WPradius)
        {
            current++;
            Debug.Log(current);
            if(current >= wp.Length)
            {
                current=0;
                isUp = false;                 
            }
            else if(current == 0)
            {
                isUp = true;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, wp[current].transform.position, Time.deltaTime * speed);
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {       
        foreach (GameObject waypoint in wp)
        {
            speed = 0;
            //transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
            yield return new WaitForSeconds(5);
            speed = 8;
        }
    }
}
