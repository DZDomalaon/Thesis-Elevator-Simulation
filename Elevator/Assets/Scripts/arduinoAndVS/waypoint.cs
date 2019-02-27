  using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using DG.Tweening; 
using UnityEngine;

public class waypoint : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject elevator; 
    public float speed = 100;
    //bool isUp = true;


    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime = 5;
    private float currentLerpTime = 0;
    private bool keyHit;

    //public static SerialPort sp = new SerialPort("COM8", 9600);    
    
    void Start()
    {
        startPos = elevator.transform.position;
        endPos = elevator.transform.position + Vector3.up * waypoints[4].transform.position.y;
    }


    void Update()
    {
          if (Input.GetKey(KeyCode.X))
          {
                keyHit = true;
                //requested = sp.ReadByte();
                if(keyHit==true)
                {
                    currentLerpTime += Time.deltaTime;
                    if(currentLerpTime >= lerpTime)
                    {
                        currentLerpTime = lerpTime;
                    }
                }

                float Perc = currentLerpTime / lerpTime;
                
                if(startPos.y < endPos.y)
                {
                    elevator.transform.position = Vector3.Lerp(startPos, endPos, Perc);
                }
        }
    }
 
    /*

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
                        else if (Input.GetKey(KeyCode.X))
                        {
                            
                            current = 1;

                            //requested = sp.ReadByte();
                            while (gameObject.transform.position.y < waypoints[2].transform.position.y)
                            {
                                Debug.Log("2");
                                transform.position += Vector3.MoveTowards(transform.position, waypoints[2].transform.position, Time.deltaTime * speed);
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
    }*/
}
