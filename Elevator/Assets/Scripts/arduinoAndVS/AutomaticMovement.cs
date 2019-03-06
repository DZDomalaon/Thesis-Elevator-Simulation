using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMovement : MonoBehaviour
{
    public GameObject[] wp;
    public GameObject door;
    public Text liftCurrent;
    public int current = 0;
    public int moveCounter = 0;

    private GameObject movingTowards ;
    private GameObject objectTest;

    int full = 0;
    float speed = 8;
    float WPradius = 1;
    public int isUp;
    public bool isMoving = true;
    bool isOpen = true;

    Door doorScript;
    ElevatorManager manager;

    void Start()
    {
        doorScript = door.GetComponent<Door>();        
        manager = GetComponent<ElevatorManager>();
        isUp = 1;
        movingTowards = wp[moveCounter];
        full = Random.Range(0,9);        
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
            transform.position = Vector3.MoveTowards(transform.position, movingTowards.transform.position, Time.deltaTime * speed);
            StartCoroutine(Wait());           
        }
        else if(!isMoving)
        {
            if(isOpen)
            {
                DoorOpen();
            }            
        }
    }

    public IEnumerator Wait()
    {
        if(full == 0)
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
        if (full == 9)
        {
            liftCurrent.text = "Lift passenger #: Full";
            manager.isFull = true;

        }
        else
        {
            liftCurrent.text = "Lift passenger #: " + full;
        }

        yield return new WaitForSeconds(2);
        full = Random.Range(0,9);

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
}
