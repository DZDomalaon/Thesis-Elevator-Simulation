﻿using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class isFull : MonoBehaviour {

    public static SerialPort sp = new SerialPort("COM7", 9600);
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {        
        if(sp != null)
        {
            if (sp.IsOpen)
            {
                if (sp.ReadByte() == 12)
                {

                }
            }
        }        
    }
}
