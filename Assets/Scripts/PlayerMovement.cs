﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    private Vector2 jumpForce = new Vector2(0, 300);
    Rigidbody2D rb;

    //The 4 colors name as string to compare with obstacles' tag
    private string[] colorsName;

    //The active color
    private string activeColor;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Set colors
        colorsName = new string[4];
        colorsName[0] = "cyan";
        colorsName[1] = "pink";
        colorsName[2] = "yellow";
        colorsName[3] = "purple";
    }

    void Update()
    {
        // Jump
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpForce);
        }
    }

    //Method for switching the Player's color
    void switchColor(int color)
    {
        activeColor = colorsName[color];
    }

    //Method to dectect Collision
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the detected trigger has an other color then the Player -> Game Over
        if(other.tag != activeColor)
        {
            Destroy(this.gameObject);
        }
    }
}