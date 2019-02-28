using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDetector : MonoBehaviour
{
    public LiftManagerScript LiftManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_00;
        if (other.gameObject.CompareTag("Floor2"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_02;
        if (other.gameObject.CompareTag("Floor3"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_03;
        if (other.gameObject.CompareTag("Floor4"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_04;
        if (other.gameObject.CompareTag("Floor5"))
            LiftManager.GetComponent<LiftManagerScript>().CurrentLevel = LiftManagerScript.LiftLevel.Level_05;
    }
}