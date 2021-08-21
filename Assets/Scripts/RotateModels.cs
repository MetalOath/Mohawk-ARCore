using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModels : MonoBehaviour
{
    public Vector3 Axis;
    public float Speed;
    void Update()
    {
        transform.Rotate(Axis, Speed);
    }
}
