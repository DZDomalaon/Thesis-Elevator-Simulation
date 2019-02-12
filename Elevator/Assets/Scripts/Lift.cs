using UnityEngine;
using System.Collections;

public class Lift : MonoBehaviour {
	public bool isLiftMoving;
	public Transform Player;
	Vector3 movementOffset;
	int currentFloor;
	// Use this for initialization
	void Start () {
		currentFloor=1;
		isLiftMoving=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.parent==this.transform)
		{
			if(Input.GetKey(KeyCode.X))
			{   
					MoveLift();
			}
			if(isLiftMoving)
			{			
				transform.position+=movementOffset;
			}
		}
		 
	}
	void OnTriggerEnter(Collider coll)
	{Debug.Log("Collision occured");
		if (coll.gameObject.name.Equals("Floor1"))
		{
			Debug.Log("Floor1");
			currentFloor=1;  
			isLiftMoving=false;
		}
		if(coll.gameObject.name.Equals("Roof"))
		{
			Debug.Log("Floor2");
			currentFloor=2;
			isLiftMoving=false;
		}
		if(coll.gameObject.name.Equals("Player"))
		{

			Debug.Log("Player entered");
		}
	}
	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.name.Equals("Player"))
		{
			Debug.Log("Player stay");
			Player .parent= this.transform;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if(coll.gameObject.name.Equals("Player"))
		{
			Debug.Log("Player exit");  
			Player.parent=null;
		}
	}

	void MoveLift()
	{Debug.Log(" movelift");
		if (currentFloor==1)
		{	movementOffset= new Vector3(0.0f,0.1f,0.0f);
            this.transform.position += new Vector3(0.0f, 0.1f, 0.0f); 
            isLiftMoving =true;
		}
		if (currentFloor==2)
		{	movementOffset= new Vector3(0.0f,-0.1f,0.0f);		
			this.transform.position+=new Vector3(0.0f,-0.1f,0.0f);
			isLiftMoving=true;
		}
	}	
}
