using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float slowCoefficient = 2;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Text text;

    private int obtainedFood = 0;
    private float directionX;
    private float directionY;

    void FixedUpdate()
    {
        Move();
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = ($"Morsels Eaten: {obtainedFood}");
    }

    private void Move()
    {
        //Moves player on input
        directionX = Input.GetAxis("Horizontal");
        Vector2 vector = new Vector2(moveSpeed, moveSpeed);
        if (!Input.GetKeyDown(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            /*vector.x = (vector.x / slowCoefficient);
            vector.x = vector.x * directionX;*/

            if(directionX <= 0)
            {
                rb2d.rotation -= (directionX * moveSpeed);
            }
            else if (directionX >= 0)
            {
                rb2d.rotation -= (directionX * moveSpeed);
            }
            else if (directionX == 0)
            {
                rb2d.rotation = 0;
            }
        }

        directionY = Input.GetAxis("Vertical");
        if (!Input.GetKeyDown(KeyCode.W) || !Input.GetKey(KeyCode.S))
        {
            vector = (vector / slowCoefficient);
            vector = this.transform.up * directionY * moveSpeed;
        }
        rb2d.velocity = (vector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            if (Input.GetKeyDown("Jump"))
            {
                audioSource.Play();
                obtainedFood++;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
