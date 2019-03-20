using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyScript : MonoBehaviour
{

    private System.Random random;
    private System.Random random1;
    private int direction;
    private Vector2 vector;

    [SerializeField]
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        random1 = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        direction = random.Next(0, 3);
        Move();
    }

    private void Move()
    {
        switch (direction)
        {
            case 0:
                vector.Set(1, 0);
                break;
            case 1:
                vector.Set(-1, 0);
                break;
            case 2:
                vector.Set(0, 1);
                break;
            case 3:
                vector.Set(0, -1);
                break;
        }
        rb2d.velocity = vector * random1.Next(-2, 2);
    }
}
