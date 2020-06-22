using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    public float speed;
    public float jumpSpeed;
    private Vector3 scale;
    private float scaleMag;
    public bool airborne = false;
    private bool stunned = false;

    public GameObject stunText;

    public GameObject sound;
    public float maxVel;

    public float dartSpeed;

    public GameObject dartPos;

    public GameObject dart;

    private float timer = 0;
    private Vector3 movement = new Vector3();

    public int gems = 0;

    private float time = 0;

    public Text timeCount;
    public Text gemCount;

    public bool complete = false;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scaleMag = transform.localScale.y;
        scale = new Vector3(scaleMag, scaleMag, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!complete)
        {
            time += Time.deltaTime;
        }

       
       
        timeCount.text = string.Format("{0:0.00}", time);
        gemCount.text = "Gems: " + gems;
        
        

        //horizontal movement
        movement = rb.velocity;
        movement.x = speed * Input.GetAxis("Horizontal");
        
        //jumping
        if (Input.GetKeyDown(KeyCode.W) && !airborne && stunned == false)
        {
            movement.y = jumpSpeed;
            GetComponent<AudioSource>().Play();

        }
        anim.SetBool("Airborne", airborne);
        if (airborne)
        {
            if (!anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Shoot"))
            {
                anim.Play("Jump");
            }
            
        }

        if (stunned)
        {
            movement.x = 0;
            stunText.SetActive(true);
        }
        else
        {
            stunText.SetActive(false);
        }



        rb.velocity = movement;

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Moving", false);
        }
        else if(stunned == false)
        {
            anim.SetBool("Moving", true);
            if (!airborne)
            {
                if (!anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Shoot"))
                {
                    anim.Play("walk");
                }
            }
           
        }




        //turning
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }

        if (facingRight)
        {
            scale.x = scaleMag;
        }
        else
        {
            scale.x = -scaleMag;
        }

        if (stunned)
        {
            scale.x = scaleMag;
        }
        transform.localScale = scale;


        //shooting
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer <= 0 && !stunned)
        {
            shoot();
            timer = 1f;
           
        }

        if (rb.velocity.magnitude > maxVel)
        {
            rb.velocity = rb.velocity.normalized * maxVel;
        }
        
    }


    public void shoot()
    {
        Instantiate(sound);
        GameObject d = Instantiate(dart, dartPos.transform.position, Quaternion.identity);
        anim.Play("Shoot");
        if (facingRight)
        {
            d.GetComponent<Rigidbody2D>().velocity = Vector2.left * -dartSpeed;
            d.transform.localScale = -d.transform.localScale;
        }
        else
        {
            d.GetComponent<Rigidbody2D>().velocity = Vector2.left * dartSpeed;
        }
        
    }

    public void stunn()
    {
        StartCoroutine(stun());
    }
    public IEnumerator stun()
    {
        stunned = true;
        yield return new WaitForSeconds(1.5f);
        stunned = false;
    }
}
