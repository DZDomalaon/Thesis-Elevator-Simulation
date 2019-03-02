using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int currentFloor = 0;
    void OnCollisionEnter(Collision col){
        switch(col.gameObject.name){
            case "Floor1":
                currentFloor = 1;
                break;
            case "Floor2":
                currentFloor = 2;
                break;
            case "Floor3":
                currentFloor = 3;
                break;
            case "Floor4":
                currentFloor = 4;
                break;
            case "Floor5":
                currentFloor = 5;
                break;
        }
    }
}
