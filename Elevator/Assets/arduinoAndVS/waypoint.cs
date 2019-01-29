  using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using DG.Tweening; 
using UnityEngine;

public class waypoint : MonoBehaviour {

    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = 1;
    public int nextFloor;
    public int minHeight;
    private int getInput = 0;


    public static SerialPort sp = new SerialPort("COM7", 9600);    
    
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        getInput = sp.ReadByte();
    }


    void Update()
    {
        /*
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }          
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);          
        */
        moveLift();
    }
 

    void moveLift()
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
                        //else if (getInput == 2)
                        //{
                        //    current = 1;

                        //    while (gameObject.transform.position.y < nextFloor)
                        //    {
                        //        transform.DOMoveY(nextFloor, speed);
                        //    }
                        //}
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

    private void OnTriggerEnter(Collider other)
    {
        if (getInput == 2)
        {
            current = 1;

            while (gameObject.transform.position.y < nextFloor)
            {
                transform.DOMoveY(nextFloor, speed);
            }
        }  
    }
}
