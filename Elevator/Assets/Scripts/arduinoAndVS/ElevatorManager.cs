using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ElevatorManager : MonoBehaviour
{

    public bool shouldDoorOpen;
    public bool isFull;
    public Animator doorsOpen;

    bool up;

    float speed = 8;

    public int personFloor;
    public bool personRequest = false;
    public bool personDelivered = false;
    public int personRequestFloor;

    public bool personRequestDirection = false;    
    public GameObject[] elevators;       

    float minPosition;
    int temp;
    int counter;

    void Update(){

        personFloor = GameObject.FindWithTag("Player").GetComponent<PlayerScript>().currentFloor;

        Debug.Log("NEAREST" + GetNearestElevator(personFloor));
        GameObject chosenElevator = elevators[GetNearestElevator(personFloor)];
        AutomaticMovement chosen = chosenElevator.GetComponent<AutomaticMovement>();

        if(personRequest && !isFull && personRequestDirection == up) {
            chosen.enabled = false;

            chosenElevator.transform.position = Vector3.MoveTowards(chosenElevator.transform.position, chosen.wp[personFloor - 1].transform.position, Time.deltaTime * speed);
        }
        if(personDelivered) GetComponent<AutomaticMovement>().enabled = true;

        if(Input.GetKey("x"))
        {
            personRequest = !personRequest;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            personRequestDirection = true;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            personRequestDirection = false;
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
