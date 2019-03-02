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
    public bool isUp;
    bool isWaitng = false;
    bool isMoving = true;

    Rigidbody rigid ;
    Door doorScript;

    void Start()
    {
        doorScript = door.GetComponent<Door>();
        rigid = GetComponent<Rigidbody>();
        isUp = true;
        movingTowards = wp[moveCounter];
        full = Random.Range(0,9);
        //current = Random.Range(0, (wp.Length - 2));
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(wp[current].transform.position, transform.position) < WPradius)
        {
            current++;
            Debug.Log(current);
            if(current == wp.Length)
            {
                current=0;
                isUp = false;
            }
            else if(current == 0)
            {
                isUp = true;
            }
        }

        if(isMoving){
            transform.position = Vector3.MoveTowards(transform.position, movingTowards.transform.position, Time.deltaTime * speed);
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        Debug.Log("Start waiting");
        isWaitng = true;
        rigid.velocity = Vector3.zero;

        yield return new WaitForSeconds(2);

        doorScript.doorOpen = true;
        //Randomize
        if(full == 9)
        {
            liftCurrent.text = "The lift is full";
        }
        else
        {
            liftCurrent.text = full.ToString();
        }
        yield return new WaitForSeconds(2);
        doorScript.doorOpen = false;
        yield return new WaitForSeconds(3);
        full = Random.Range(0,9);
        if(isUp)
        {
            moveCounter++ ;
        }
        else if(!isUp)
        {
            moveCounter--;

            if(moveCounter==0)
            {
                isUp = true;
            }
        }
        isMoving = true;
        movingTowards = wp[moveCounter];

        StopAllCoroutines();
        Debug.Log("Waiting Complete");        
    }
}
