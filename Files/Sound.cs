using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip a;
    public AudioClip b;
    public AudioClip c;
    void Start()
    {
        Random r = new Random();
        int n = r.Next(0, 3);
        if (n == 0)
        {
            GetComponent<AudioSource>().clip = a;
        }
        else if (n == 1)
        {
            GetComponent<AudioSource>().clip = b;
        }
        else
        {
            GetComponent<AudioSource>().clip = c;
        }

        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
