using UnityEngine;
using System.Collections;

public class MainCamScript : MonoBehaviour {
	bool dispMsg;
	// Use this for initialization
	void Start () {
		dispMsg=true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		if(dispMsg)
		{ GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600));
			GUI.Box(new Rect(400,200,300,120)," ");
			GUI.TextArea(new Rect(400,200,300,30), "-To Open the lift go near red button and press \"Z\"");
			GUI.TextArea(new Rect(400,230,300,30), "-To move the lift go inside the lift and press \"X\"");
			GUI.TextArea(new Rect(400,260,300,30), "-Use Arrow keys to move the character");
			if(GUI.Button(new Rect(450,290,200,30),"OK"))
			{
				dispMsg=false;
			}        
			GUI.EndGroup();
		}
		GUI.TextArea(new Rect(800, 100, 180, 20), "Camera2 Second Floor");
		GUI.TextArea(new Rect(800, 280, 180, 20), "Camera1 First Floor");	
		
	}
}
