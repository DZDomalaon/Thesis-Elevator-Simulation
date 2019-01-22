   	using UnityEngine;
	using System.Collections;

	public class LiftButton : MonoBehaviour {
		public Transform doorToOpen;
		public Transform lift;
		
		Animator anim;
		// Use this for initialization
		void Start () {
			anim= doorToOpen.GetComponent<Animator>();
			
		}
		
		// Update is called once per frame
		void Update () {

		}
		void OnTriggerStay(Collider coll)
		{
			if(coll.gameObject.name.Equals("Player"))
			{
				if(Input.GetKey(KeyCode.Z))
				{
					OpenLift();

				}
			}
		}
		void OpenLift()
		{
			anim.Play("DoorOpen");

		}

		

	}
