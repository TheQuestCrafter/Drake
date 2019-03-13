﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterCell : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float slowCoefficient = 2;

    private float directionX;
    private float directionY;

    void FixedUpdate()
    {
        Move(); 
    }

    private void Move()
    {
        //Moves player on input
        directionX = Input.GetAxis("Horizontal");
        Vector2 vector = new Vector2(moveSpeed, moveSpeed);
        if (!Input.GetKeyDown(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            vector.x = (vector.x / slowCoefficient);
            vector.x = vector.x * directionX;
        }

        directionY = Input.GetAxis("Vertical");
        if (!Input.GetKeyDown(KeyCode.W) || !Input.GetKey(KeyCode.S))
        {
            vector.y = (vector.y / slowCoefficient);
            vector.y = vector.y * directionY;
        }
        rb2d.velocity = (vector);
    }
}
