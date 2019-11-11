﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    public float jumpforce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(movespeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpforce);
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }
}