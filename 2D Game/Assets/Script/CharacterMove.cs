﻿using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    // Player movement variables
    public int MoveSpeed;
    public float JumpHeight;
    private bool doublelayer;

    // Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    // Use this for initialization
    void Start () {
        
    }

    void FixedUpdate () {
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        }

    // Update is called once per frame
    void Update () {

        // This code makes the character jump
        if(Input.GetKeyDown (KeyCode.Space)&& grounded){
            Jump();
        }

        // This code makes the character move from side to side using the A&D keys
        if(Input.GetKey (KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if(Input.GetKey (KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }

    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }
}