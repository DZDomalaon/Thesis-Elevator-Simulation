using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CheckInside : MonoBehaviour
{
    GameObject manage;
    SerialPort stream = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);

    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 20;        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("Player"))
        {
            manage.GetComponent<ElevatorManager>().isInside = true;
        }        
    }

    void OnTriggerStay(Collider other)
    {
        if(manage.GetComponent<ElevatorManager>().isInside == true)
        {
            if(stream != null)
            {
                if(stream.IsOpen)
                {
                    try
                    {
                        int value;
                        value = stream.ReadByte();
                        if (value == 9)
                        {
                            Door closed = GetComponent<Door>();
                            closed.doorOpen = 2;
                        }
                    }
                    catch (System.TimeoutException) { }                   
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        manage.GetComponent<ElevatorManager>().isInside = false;
    }

}
