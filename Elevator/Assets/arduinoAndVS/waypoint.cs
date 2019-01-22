  using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using DG.TWeening;
using UnityEngine;

public class waypoint : MonoBehaviour {

    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = 1;
    public int maxHeight;
    public int minHeight;


    public static SerialPort sp = new SerialPort("COM7", 9600);    

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        //anim = doorToOpen.GetComponent<Animator>();
    }

    void Update()
    {   /*             
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }          
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        StartCoroutine(Delay());
        */               
    }

    void OnTriggerEnter(Collider coll)
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                try
                {
                    if (current >= waypoints.Length)
                    {
                        current = 0;
                    }
                    else
                    {
                        if (sp.ReadByte() == 1)
                        {
                            current++;
                            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
                        }
                        else if (sp.ReadByte() == 2)
                        {                            
                            current++;
                            if(waypoints[current].transform.position.y < maxHeight)
                            {
                                transform.
                            }
                            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
                        }
                        else if (sp.ReadByte() == 3)
                        {
                            current++;
                            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
                        }
                        else if (sp.ReadByte() == 4)
                        {
                            current++;
                            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
                        }
                        else
                        {
                            current++;
                            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
                        }
                    }
                }
                catch (System.Exception)
                {
                }
            }
            else
            {
                sp.Open();
            }
        }
    }

}
