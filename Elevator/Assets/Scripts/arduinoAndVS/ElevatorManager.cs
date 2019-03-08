using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ElevatorManager : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);
    //SerialPort stream2 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);

    public bool shouldDoorOpen;
    public bool isFull;
    public GameObject chosenElevator;
    public bool doneRequesting = false;

    float speed = 8;

    public int personFloor;
    public bool personRequest = false;
    public bool personDelivered = false;
    public int personRequestFloor;

    public int personRequestDirection;   
    public GameObject[] elevators;       

    int[] requestedFloors;

    int data;

    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 25;
    }

    void Update()
    {
        // if(stream != null)
        // {
        //     if(stream.IsOpen)
        //     {
                personFloor = GameObject.FindWithTag("Player").GetComponent<PlayerScript>().currentFloor;
                stream.Write(personFloor.ToString());
                
                if(chosenElevator){
                    chosenElevator.transform.position = Vector3.MoveTowards(chosenElevator.transform.position, chosenElevator.GetComponent<AutomaticMovement>().wp[personFloor - 1].transform.position, Time.deltaTime * speed);
                    if(chosenElevator.transform.position == chosenElevator.GetComponent<AutomaticMovement>().wp[personFloor - 1].transform.position)
                    {   
                        Debug.Log("Followed the Person");
                        GameObject door = chosenElevator.GetComponent<AutomaticMovement>().door;
                        Door script = door.GetComponent<Door>();
                        script.doorOpen = 1;
                    }
                }
                


                if(personRequest == true && doneRequesting == false)
                {
                    chosenElevator = elevators[GetNearestElevator(personFloor)];
                    AutomaticMovement chosen = chosenElevator.GetComponent<AutomaticMovement>();

                    if (personRequest && !chosen.isFull && doneRequesting == false)
                    {
                        chosen.enabled = false;
                        doneRequesting = true;
                    }
                    else
                    {

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
                }
                

                // try
                // {
                //     Debug.Log("random");

                    ////Data to Arduino (inside)
                    //Debug.Log(stream2.ReadLine());
                    //if (chosen.current == 1 && chosen.isUp == 1)
                    //{
                    //    stream2.Write("a");
                    //}
                    //if (chosen.current == 2 && chosen.isUp == 1)
                    //{
                    //    stream2.Write("b");
                    //}
                    //if (chosen.current == 2 && chosen.isUp == 2)
                    //{
                    //    stream2.Write("c");
                    //}
                    //if (chosen.current == 3 && chosen.isUp == 1)
                    //{
                    //    stream2.Write("d");
                    //}
                    //if (chosen.current == 3 && chosen.isUp == 2)
                    //{
                    //    stream2.Write("e");
                    //}
                    //if (chosen.current == 4 && chosen.isUp == 1)
                    //{
                    //    stream2.Write("f");
                    //}
                    //if (chosen.current == 4 && chosen.isUp == 2)
                    //{
                    //    stream2.Write("g");
                    //}
                    //if (chosen.current == 5 && chosen.isUp == 2)
                    //{
                    //    stream2.Write("h");
                    //}

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

                    //Data from Arduino (outside)
        //             string value2 = stream.ReadLine();
        //             if (value2 == "!")  
        //             {
        //                 data = 0;
        //             }
        //             if (value2 == "<")
        //             {
        //                 data = 1;
        //                 stream.Write(data.ToString()); 
        //             }
        //             if (value2 == ">")
        //             {
        //                 data = 2;
        //                 stream.Write(data.ToString());
        //             }
        //         }
        //         catch (System.Exception)
        //         {
        //             Debug.Log("Error");
        //         }
        //     }
        // }        
    }

    IEnumerator MoveElevator(GameObject floor){
        Debug.Log("MOVING");
        yield return new WaitForSeconds(6);
    }
    int GetNearestElevator(int personFloor)
    {
        int nearestElevator = elevators.Length;
        //  = personFloor - elevators[0].GetComponent<AutomaticMovement>().moveCounter;
        //TODO: Compare floors each elevator. PersonFloor -ElevatorFloor . Abs(). Assume lowest value is nearestElevator.       
        int tmpMax = 5;
    
        if(personFloor == 5) {
            for (int i = 0; i < elevators.Length; i++)
            {
                GameObject currentElevator = elevators[i];
                AutomaticMovement movement = currentElevator.GetComponent<AutomaticMovement>();
                
                int direction = movement.isUp;
                int movementNew = movement.moveCounter + 1;

                int abs = Mathf.Abs(movementNew - personFloor);  
                             
                if(abs < tmpMax && direction == 1)
                {
                    nearestElevator = i;
                    Debug.Log(nearestElevator);
                }
            }
        } else if (personFloor == 1){
            for (int i = 0; i < elevators.Length; i++)
            {
                GameObject currentElevator = elevators[i];
                AutomaticMovement movement = currentElevator.GetComponent<AutomaticMovement>();
                
                int direction = movement.isUp;
                int movementNew = movement.moveCounter + 1;

                int abs = Mathf.Abs(movementNew - personFloor);  
                             
                if(abs < tmpMax && direction == 0)
                {
                    nearestElevator = i;
                    Debug.Log(nearestElevator);
                }
            }
        } else {
            for (int i = 0; i < elevators.Length; i++)
            {
                GameObject currentElevator = elevators[i];
                AutomaticMovement movement = currentElevator.GetComponent<AutomaticMovement>();
                
                int movementNew = movement.moveCounter + 1;

                int abs = Mathf.Abs(movementNew - personFloor);  
                             
                if(abs < tmpMax)
                {
                    nearestElevator = i;
                    Debug.Log(nearestElevator);
                }
            }
        }

        Debug.Log("RETURNED VALUE" + nearestElevator);
        return Mathf.Abs(nearestElevator);
    }
}
