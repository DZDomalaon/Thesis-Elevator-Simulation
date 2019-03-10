using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ElevatorManager : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM7", 9600);

    public bool shouldDoorOpen;
    public bool isInside = true ;
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
    int value;

    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 25;
    }

    void Update()
    {        
        personFloor = GameObject.FindWithTag("Player").GetComponent<PlayerScript>().currentFloor;        

        if (chosenElevator)
        {
            chosenElevator.transform.position = Vector3.MoveTowards(chosenElevator.transform.position, chosenElevator.GetComponent<AutomaticMovement>().wp[personFloor - 1].transform.position, Time.deltaTime * speed);
            if (chosenElevator.transform.position == chosenElevator.GetComponent<AutomaticMovement>().wp[personFloor - 1].transform.position)
            {
                Debug.Log("Followed the Person");
                GameObject door = chosenElevator.GetComponent<AutomaticMovement>().door;
                Door script = door.GetComponent<Door>();
                script.doorOpen = 1;
            }
        }


        if (personRequest == true && doneRequesting == false)
        {
            chosenElevator = elevators[GetNearestElevator(personFloor)];
            AutomaticMovement chosen = chosenElevator.GetComponent<AutomaticMovement>();

            if (personRequest && !chosen.isFull && doneRequesting == false)
            {
                chosen.enabled = false;
                doneRequesting = true;
            }            

            if (personDelivered)
            {
                GetComponent<AutomaticMovement>().enabled = true;
            }
        }


        if (stream != null)
        {            
            Debug.Log(stream.IsOpen);
            if (stream.IsOpen)
            {                
                try
                {
                    if (isInside == true)
                    {
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 1 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 1)
                        {
                            stream.Write("a");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 2 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 1)
                        {
                            stream.Write("b");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 2 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 2)
                        {
                            stream.Write("c");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 3 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 1)
                        {
                            stream.Write("d");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 3 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 2)
                        {
                            stream.Write("e");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 4 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 1)
                        {
                            stream.Write("f");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 4 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 2)
                        {
                            stream.Write("g");
                        }
                        if (chosenElevator.GetComponent<AutomaticMovement>().moveCounter == 5 && chosenElevator.GetComponent<AutomaticMovement>().isUp == 2)
                        {
                            stream.Write("h");
                        }

                        value = stream.ReadByte();
                        if (value == 6)
                        {
                            data = 6;
                            Debug.Log("OPEN");
                        }
                        if (value == 9)
                        {
                            data = 9;
                            Debug.Log("CLOSE");
                        }
                        else
                        {
                            var val = value.ToString();
                            var arr = val.ToCharArray();
                            for (int i=0; i<arr.Length; i++)
                            {
                                Debug.Log(arr[i]);
                            }
                        }
                    }

                    if (isInside == false)
                    {
                        stream.Write(personFloor.ToString());
                        if (personFloor == 1)
                        {
                            stream.Write("1");
                        }
                        if (personFloor == 2)
                        {
                            stream.Write("2");
                        }
                        if (personFloor == 3)
                        {
                            stream.Write("3");
                        }
                        if (personFloor == 4)
                        {
                            stream.Write("4");
                        }
                        if (personFloor == 5)
                        {
                            stream.Write("5");
                        }

                        value = stream.ReadByte();
                        if (value == 12)
                        {
                            data = 12;
                            Debug.Log("UP/DOWN");
                        }
                        if (value == 1)
                        {
                            data = 1;
                            Debug.Log("UP");
                        }
                        if (value == 1)
                        {
                            data = 2;
                            Debug.Log("DOWN");
                        }
                    }
                }
                catch (System.Exception)
                {
                    Debug.Log("Error");
                }
            }    
            else
            {
                stream.Open();
            }
        }     
    }


    IEnumerator MoveElevator(GameObject floor)
    {
        Debug.Log("MOVING");
        yield return new WaitForSeconds(6);
    }


    int GetNearestElevator(int personFloor)
    {
        int nearestElevator = elevators.Length;      
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
        }
        else if (personFloor == 1)
        {
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
        }
        else
        {
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
        return Mathf.Abs(nearestElevator);
    }
}
