using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartScript : MonoBehaviour
{

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gromp"))
        {
            GameObject e = Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(e, 2);
            Destroy(other.gameObject);
        }
        else
        {
            GameObject ex = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(ex, 2);
        }
        

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Ice")))
        {
            GameObject ex = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(ex, 2);
            Destroy(this.gameObject);
        }
    }
}
