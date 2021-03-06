﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";
    public string fire1 = "Fire1_P1";

    public float speed = 8f;
    public float verticalSpeed = 2f;

    public bool grounded = true;
    public float jumpPower = 300f;
    private bool hasJumped = false; 
    public Animator anim;

    [HideInInspector]
    public int direction = 1;
    public bool right = true;

    Vector3 movement;
    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GetComponent<PlayerStats>().dead)
            return;

        if (Input.GetButtonDown(fire1) && grounded == true)
        {
            hasJumped = true;
        }

        if (right)
        {
            if (movement.x < 0)
            {
                ChangeDirection(-1);
                right = false;
            }
        }
        else
        {
            if(movement.x > 0)
            {
                ChangeDirection(1);
                right = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (GetComponent<PlayerStats>().dead)
            return;

        float moveHorizontal = Input.GetAxis(horizontal);
        float moveVertical = Input.GetAxis(vertical);

        movement = new Vector3(moveHorizontal, 0, moveVertical);// * verticalSpeed);
        //TODO: either play walking anim or idle anim depending on what the movement speed is, watch the performence
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        transform.position += movement * speed * Time.deltaTime;

        if (hasJumped)
        {
            //TODO: play jump animation
            GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0) * jumpPower);
            grounded = false;
            hasJumped = false;
        }
    }

    void ChangeDirection(int direction)
    {
        this.direction = direction;
        transform.localScale = new Vector3(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter(Collision col)
    { 
        if(col.gameObject.tag == "Ground")
            grounded = true;
    }
}
