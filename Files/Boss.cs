using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 16;
    private float timer = 0;
    public float cooldown;
    public GameObject ex;
    public int probability;

    public GameObject wallPos;
    public GameObject icePos;

    public GameObject wall;
    public GameObject ice;

    private bool active = false;
    public int speed;
    public GameObject player;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 155.3)
        {
            active = true;
        }

        if (active)
        {
            if (health <= 0)
            {
                Die();
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Move();
                timer = cooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Dart"))
        {
            health -= 1;
        }
    }

    public void Move()
    {
        System.Random r = new System.Random();
        int n = r.Next(0, probability);
        if (n == 0)
        {
            GameObject w = Instantiate(wall, wallPos.transform.position, Quaternion.identity);
            Destroy(w, 5);
        }
        else
        {
            GameObject i = Instantiate(ice, icePos.transform.position, Quaternion.identity);
            i.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            i.GetComponent<Rigidbody2D>().AddTorque(500);
            
        }
    }

    public void Die()
    {
        player.GetComponent<PlayerControl>().complete = true;
        GameObject e = Instantiate(ex, transform.position, Quaternion.identity);
        e.transform.localScale *= 4;
        GetComponent<AudioSource>().Play();
        Destroy(e, 5);

        Destroy(this.gameObject);
    }
}
