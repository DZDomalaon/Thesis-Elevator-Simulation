using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ElevatorManager : MonoBehaviour
{
    //SerialPort stream = new SerialPort("COM7", 9600);
    SerialPort stream2 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);

    public bool shouldDoorOpen;
    public bool isFull;
    public Animator doorsOpen;

    float speed = 8;

    public int personFloor;
    public bool personRequest = false;
    public bool personDelivered = false;
    public int personRequestFloor;

    public int personRequestDirection;   
    public GameObject[] elevators;       

    int temp;
    int[] requestedFloors;

    int data;

    void Start()
    {
        stream2.Open();
        stream2.ReadTimeout = 25;
    }

    void Update()
    {
        if(stream2 != null)
        {
            if(stream2.IsOpen)
            {
                personFloor = GameObject.FindWithTag("Player").GetComponent<PlayerScript>().currentFloor;

                GameObject chosenElevator = elevators[GetNearestElevator(personFloor)];
                AutomaticMovement chosen = chosenElevator.GetComponent<AutomaticMovement>();

                if (personRequest && !isFull && personRequestDirection == chosen.isUp)
                {
                    chosen.enabled = false;

                    chosenElevator.transform.position = Vector3.MoveTowards(chosenElevator.transform.position, chosen.wp[personFloor - 1].transform.position, Time.deltaTime * speed);
                }
                if (personDelivered) GetComponent<AutomaticMovement>().enabled = true;

                if (Input.GetKey("x"))
                {
                    personRequest = !personRequest;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    personRequestDirection = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    personRequestDirection = 0;
                }

                try
                {
                    Debug.Log("random");

                    ////Data to Arduino (inside)
                    if (chosen.current == 1 && chosen.isUp == 1)
                    {
                        stream2.Write("a");
                    }
                    if (chosen.current == 2 && chosen.isUp == 1)
                    {
                        stream2.Write("b");
                    }
                    if (chosen.current == 2 && chosen.isUp == 2)
                    {
                        stream2.Write("c");
                    }
                    if (chosen.current == 3 && chosen.isUp == 1)
                    {
                        stream2.Write("d");
                    }
                    if (chosen.current == 3 && chosen.isUp == 2)
                    {
                        stream2.Write("e");
                    }
                    if (chosen.current == 4 && chosen.isUp == 1)
                    {
                        stream2.Write("f");
                    }
                    if (chosen.current == 4 && chosen.isUp == 2)
                    {
                        stream2.Write("g");
                    }
                    if (chosen.current == 5 && chosen.isUp == 2)
                    {
                        stream2.Write("h");
                    }

                    ////Data from Arduino (inside)
                    //string value = stream.ReadLine();
                    //if (value == "12")
                    //{
                    //    data = 12;
                    //    Debug.Log("UPDOWN");
                    //}
                    //if (value == "1")
                    //{
                    //    data = 1;
                    //    Debug.Log("UP");
                    //}
                    //if (value == "2")
                    //{
                    //    data = 2;
                    //    Debug.Log("DOWN");
                    //}

                    ////Data from Arduino (outside)
                    //string value2 = stream2.ReadLine();
                    //if (value2 == "!")
                    //{
                    //    data = 0;
                    //}
                    //if (value2 == "<")
                    //{
                    //    data = 1;
                    //}
                    //if (value2 == ">")
                    //{
                    //    data = 2;
                    //}
                }
                catch (System.Exception)
                {
                    Debug.Log("Error");
                }
            }
        }        
    }

    int GetNearestElevator(int personFloor)
    {
        //TODO: Compare floors each elevator. PersonFloor -ElevatorFloor . Abs(). Assume lowest value is nearestElevator.        
        temp = personFloor - elevators[0].GetComponent<AutomaticMovement>().moveCounter;
        for (int i = 1; i < elevators.Length; i++)
        {
            if(temp < elevators[i].GetComponent<AutomaticMovement>().moveCounter)
            {
                temp = Mathf.Abs(elevators[i].GetComponent<AutomaticMovement>().moveCounter - personFloor);
            }

            if(temp >= elevators.Length)
            {
                temp = elevators.Length-1;
            }
        }
        return Mathf.Abs(temp);
    }
}
