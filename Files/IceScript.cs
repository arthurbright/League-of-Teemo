using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public GameObject ex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dart"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerControl>().stunn();
        }

        GameObject e = Instantiate(ex, transform.position, Quaternion.identity);
        Destroy(e, 2);
        Destroy(this.gameObject);


    }
}
