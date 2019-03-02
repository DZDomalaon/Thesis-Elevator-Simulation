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
        endPos = elevator.transform.position + Vector3.up * waypoints[1].transform.position.y;
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
}
