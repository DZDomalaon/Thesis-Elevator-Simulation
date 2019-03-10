using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System.IO.Ports;

public class Teleport : MonoBehaviour
{
    int[] buttons = new int[2];

    public Transform target;
    public static SerialPort sp = new SerialPort("COM7", 9600);


    void Start()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                for (int i = 0; i < buttons.Length ; i++)
                {
                    if(i == 1)
                    {

                    }
                    buttons[i] = sp.ReadByte();
                    Debug.Log("The number is " + buttons[i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "teleport")
        {
            this.transform.position = target.position;
        }
    }
}
