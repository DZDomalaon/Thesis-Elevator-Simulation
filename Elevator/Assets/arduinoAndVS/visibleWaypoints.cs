using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibleWaypoints : MonoBehaviour {

    public List<Transform> target = new List<Transform>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        if (target.Count > 0)
        {
            Gizmos.color = Color.green;

            foreach (Transform t in target)
            {
                Gizmos.DrawSphere(t.position, 1f);
            }
            Gizmos.color = Color.red;
        }

        for (int a = 0; a < target.Count - 1; a++)
        {
            Gizmos.DrawLine(target[a].position, target[a + 1].position);
        }
    }
}
