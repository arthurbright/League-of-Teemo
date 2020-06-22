using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public float speed;
    private Vector3 dif;
    private Vector3 goal;
    void Start()
    {
        dif = cam.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 goal = Vector3.Lerp(cam.transform.position, transform.position + dif, speed);
        
        cam.transform.position = goal;
    }
}
