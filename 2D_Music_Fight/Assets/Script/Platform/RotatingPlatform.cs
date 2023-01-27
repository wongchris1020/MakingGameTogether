using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float radius = 1f;

    private Vector3 center;
    private float angle;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        angle += rotationSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        transform.position = center + offset;
    }
}

