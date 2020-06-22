using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject fx;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerControl>().gems += 1;
            GameObject f = Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(f, 3);
            Destroy(this.gameObject);
            
        }
    }
}
