using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMovement : MonoBehaviour
{   
    public int globalWaitTime = 1; 
    public GameObject[] wp;
    public GameObject door;
    public Text liftCurrent;
    public int current = 0;
    public int moveCounter = 0;
    public bool isFull = false;
    public bool[] floorRequests;
    public int passengers = 0;

    private GameObject movingTowards;
    private GameObject objectTest;

    float speed = 8;
    float WPradius = 1;
    public int isUp;
    public bool isMoving = true;
    bool isOpen = true;

    public Door doorScript;
    ElevatorManager manager;

    void Start()
    {
        doorScript = door.GetComponent<Door>();
        manager = GetComponent<ElevatorManager>();
        isUp = 1;
        movingTowards = wp[moveCounter];
        floorRequests = new bool[wp.Length];
        passengers = Random.Range(0,11);
        GenerateRandomFloors();
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wp[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if(current >= wp.Length)
            {
                current = 0;
                isUp = 0;
            }
            else if(current == 0)
            {
                isUp = 1;
            }
        }


        if(isMoving)
        {
            if(passengers != 0){
                if(!isFull){
                    transform.position = Vector3.MoveTowards(transform.position, movingTowards.transform.position, Time.deltaTime * speed);
                    StartCoroutine(Wait());
                }
                else if(isFull) {
                    transform.position = Vector3.MoveTowards(transform.position, movingTowards.transform.position, Time.deltaTime * speed);

                    if(transform.position == movingTowards.transform.position){
                        floorRequests[moveCounter] = false;
                        StartCoroutine(WaitForTime(4));
                    } else {
                        StartCoroutine(DeliverPassengersUntilEmpty());
                    }
                }
            } else {
                // STOP and WaitForPassengers
                // StartCoroutine(WaitForPassengers());
            }
        }
        else if(!isMoving)
        {
            if(isOpen)
            {
                DoorOpen();
            }
        }
    }

    IEnumerator WaitForPassengers(){
        int seconds = Random.Range(5, 10);

        Debug.Log("Elevator is Resting and Waiting For Passengers for " + seconds);
        yield return new WaitForSeconds(seconds);

        passengers = Random.Range(10, 20);
        GenerateRandomFloors();
        StopAllCoroutines();
    }

    public IEnumerator Wait()
    {
        if(passengers == 0)
        {
            yield return new WaitForSeconds(7);
            doorScript.doorOpen = 3;
        }

        yield return new WaitForSeconds(2);
        if(isMoving)
        {
            doorScript.doorOpen = 3;
        }

        //Randomize
        yield return new WaitForSeconds(2);
        if (passengers == 9)
        {
            liftCurrent.text = "Lift passenger #: Full";
            isFull =     true;
        }
        else if (passengers > 9)
        {
            liftCurrent.text = "Lift passenger #: Overloaded";
            isFull = true;
        }
        else
        {
            liftCurrent.text = "Lift passenger #: " + passengers;
        }

        yield return new WaitForSeconds(2);
        passengers = Random.Range(0,10);
        GenerateRandomFloors();

        if(passengers > 9)
        {
            doorScript.doorOpen = 1;
            yield return new WaitForSeconds(2);
            passengers = 9;
            doorScript.doorOpen = 2;
        }

        if (isUp == 1)
        {
            moveCounter++;
        }
        else if (isUp == 0)
        {
            moveCounter--;

            if (moveCounter == 0)
            {
                isUp = 1;
            }
        }

        isMoving = true;
        movingTowards = wp[moveCounter];

        StopAllCoroutines();
    }

    public IEnumerator DoorOpen()
    {
        doorScript.doorOpen = 1;
        yield return new WaitForSeconds(4);
    }

    //TODO: retain floors after changing floors
    void GenerateRandomFloors()
    {
        int rand;

        if(passengers > 4)
        {
            for(int i = 0; i < wp.Length; i++)
            {
                rand = Random.Range(0,2);

                if(rand == 1)
                {
                    floorRequests[i] = true;
                }
                else
                {
                    floorRequests[i] = false;
                }
            }
        }
        else
        {
            int trueCounter = 0;

            for(int i = 0; i < wp.Length; i++)
            {
                rand = Random.Range(0,2);

                if(rand == 1 && trueCounter < 4)
                {
                    floorRequests[i] = true;
                    trueCounter++;
                }
                else
                {
                    floorRequests[i] = false;
                }
            }
        }
    }

    public IEnumerator DeliverPassengersUntilEmpty()
    {   // TODO: Loop each FloorRequests, if true, moveTowards wp[floorReqwuestIndex]
        StopAllCoroutines();
        Debug.Log("DELIVERING");
        for(int i = 0; i < wp.Length; i++)
        {
            if(floorRequests[i] == true)
            {
                moveCounter = i;
                break;
            }
        }
        Debug.Log(moveCounter);
        movingTowards = wp[moveCounter];


        yield return new WaitForSeconds(2);
    }


    IEnumerator WaitForTime(int s){
        yield return new WaitForSeconds(s);
        StartCoroutine(DeliverPassengersUntilEmpty());
    }
}
