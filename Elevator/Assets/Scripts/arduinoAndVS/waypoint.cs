  using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using DG.Tweening; 
using UnityEngine;

public class waypoint : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject elevator; 
    int current = 1;
    public float speed = 100;
    int requested;
    bool isUp = true;


    public static SerialPort sp = new SerialPort("COM8", 9600);    
    
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
       
    }


    void Update()  
    {
        elevator.gameObject.transform.position =  waypoints[3].gameObject.transform.position;
        Debug.Log(waypoints[3].transform.position);
        Debug.Log(elevator.transform.position);
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
    }
 

    void moveLift()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                try
                {
                    if (current == waypoints.Length)
                    {
                        current = current + waypoints.Length;
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
                            
                            current = 1;

                            requested = sp.ReadByte();
                            while (gameObject.transform.position.y < waypoints[requested].transform.position.y)
                            {
                                Debug.Log("2");
                                transform.position += Vector3.MoveTowards(transform.position, waypoints[requested].transform.position, Time.deltaTime * speed);
                            }
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
