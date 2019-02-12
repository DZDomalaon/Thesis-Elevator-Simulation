using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectFloor : MonoBehaviour
{
    public void TransformPosition(Transform target)
    {
        GameObject.Find("Player").transform.position = target.position;
    }
}
