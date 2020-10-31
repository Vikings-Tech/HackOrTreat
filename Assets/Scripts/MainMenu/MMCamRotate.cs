using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMCamRotate : MonoBehaviour
{
    public Vector3 center;
    public int radius;
    private Camera cam;
    public float speed;
    private float theta;
    public float camHeight;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        cam.transform.LookAt(center);
        // Vector3 pos = cam.transform.position;
        theta += speed;
        cam.transform.position =new Vector3((float) (radius*Math.Cos(theta)), camHeight,
            (float) (radius*Math.Sin(theta)));
    }
}
