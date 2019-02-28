using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManagerScript : MonoBehaviour
{
    public enum LiftLevel
    {
        Level_00,
        Level_02,
        Level_03,
        Level_04,
        Level_05
    }

    public LiftLevel CurrentLevel;

    public enum LiftState
    {
        movingUp,
        movingDown,
        notMoving
    }

    public LiftState CurrentLiftState;

    public enum LevelSelection
    {
        Lvl00,
        Lvl02,
        Lvl03,
        Lvl04,
        Lvl05,
        LvlUnselected
    }

    public LevelSelection CurrentLiftSelection;

    public GameObject Lift;
    public GameObject MainChar;

    public Animator LiftAnim;

    void Start()
    {
        CurrentLevel = LiftLevel.Level_00;
        CurrentLiftState = LiftState.notMoving;
        CurrentLiftSelection = LevelSelection.LvlUnselected;

        LiftAnim = Lift.GetComponent<Animator>();
    }

    void Update()
    {
        float currentY = 0.0f;
        float newY = 3.0f;

        switch (CurrentLiftState)
        {
            case LiftState.movingUp:
                Lift.transform.position = new Vector3(0, Lift.transform.position.y  , 0);
                MainChar.transform.parent = Lift.transform;
                break;
            case LiftState.movingDown:
                Lift.transform.position = new Vector3(7.5f, Lift.transform.position.y - Mathf.Lerp(currentY, newY, Time.smoothDeltaTime), 0);
                MainChar.transform.parent = Lift.transform;
                break;
            case LiftState.notMoving:
                Lift.transform.position = new Vector3(7.5f, Lift.transform.position.y, 0);
                MainChar.transform.parent = null;
                break;
        }

        switch (CurrentLiftSelection)
        {
            case LevelSelection.Lvl00:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl02:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl03:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl04:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.Lvl05:
                StartCoroutine(GoToLevel());
                break;
            case LevelSelection.LvlUnselected:
                StartCoroutine(GoToLevel());
                break;
        }
    }

    IEnumerator GoToLevel()
    {
        // if pressed the same level 
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_00))
        {
            print("already at level G");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_02))
        {
            print("already at level 2");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_03))
        {
            print("already at level 3");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl04) && (CurrentLevel == LiftLevel.Level_04))
        {
            print("already at level 4");
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl05) && (CurrentLevel == LiftLevel.Level_05))
        {
            print("already at level 5");
        }

        //if At Level G 
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Close");
                print("reached Level 2");
            }
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 3");
            }
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl04) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_04)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 4");
            }
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl05) && (CurrentLevel == LiftLevel.Level_00))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_05)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 5");
            }
        }

        //if At Level 2
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level G");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 3");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl04) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_04)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 4");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl05) && (CurrentLevel == LiftLevel.Level_02))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_05)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 5");
            }

        }

        //if At Level 3
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level G");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 2");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl04) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_04)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 4");
            }
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl05) && (CurrentLevel == LiftLevel.Level_03))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingUp;
            if (CurrentLevel == LiftLevel.Level_05)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_03;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 5");
            }
        }

        //if At Level 4
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_04))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level G");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_04))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_01;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 2");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_04))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 3");
            }
        }
        if ((CurrentLiftSelection == LevelSelection.Lvl05) && (CurrentLevel == LiftLevel.Level_04))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_05)
            {
                CurrentLiftState = LiftState.notMoving;
                //CurrentLevel = LiftLevel.Level_02;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 5");
            }
        }

        //if At Level 4
        if ((CurrentLiftSelection == LevelSelection.Lvl00) && (CurrentLevel == LiftLevel.Level_05))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_00)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level G");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl02) && (CurrentLevel == LiftLevel.Level_05))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_02)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 2");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl03) && (CurrentLevel == LiftLevel.Level_05))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_03)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 3");
            }

        }
        if ((CurrentLiftSelection == LevelSelection.Lvl04) && (CurrentLevel == LiftLevel.Level_05))
        {
            LiftAnim.SetTrigger("Close");
            yield return new WaitForSeconds(1);
            //LiftAnim.Stop("LiftDoorClose");
            CurrentLiftState = LiftState.movingDown;
            if (CurrentLevel == LiftLevel.Level_04)
            {
                CurrentLiftState = LiftState.notMoving;
                // CurrentLevel = LiftLevel.Level_00;
                CurrentLiftSelection = LevelSelection.LvlUnselected;
                LiftAnim.SetTrigger("Open");
                print("reached Level 4");
            }
        }
    }
}
