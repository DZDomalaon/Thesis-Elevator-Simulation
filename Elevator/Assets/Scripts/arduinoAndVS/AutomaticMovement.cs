using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    public GameObject[] wp;
    int current = 0;
    float speed = 8;
    float WPradius = 1;
    Rigidbody rigid;
    bool isUp;
    bool isWaitng = false;
    bool isMoving = false;
    private GameObject objectTest;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        isUp = true;
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
           
        if (transform.position.y != wp[current].transform.position.y)
        {                        
            transform.position = Vector3.MoveTowards(transform.position, wp[current].transform.position, Time.deltaTime * speed);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        if(isMoving == false)
        {
            StartCoroutine(Wait());
        }
    }
    
    IEnumerator Wait()
    {
        isWaitng = true;
        Debug.Log("Start to wait");
        yield return new WaitForSeconds(5);
        speed = 8;
        //objectTest.GetComponent<Door>().openDoor("Open");
        Debug.Log("Waiting Complete");
    }
}
