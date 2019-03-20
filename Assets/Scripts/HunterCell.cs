using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HunterCell : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float slowCoefficient = 2;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite oneConsumed;
    [SerializeField]
    private Sprite twoConsumed;
    [SerializeField]
    private int nextScene;
    [SerializeField]
    private AudioSource audioSource;

    private int obtainedFood = 0;
    private float directionX;
    private float directionY;
    private DeathCount deathCount;

    void Awake()
    {
        deathCount = (DeathCount)FindObjectOfType(typeof(DeathCount));
    }

    void FixedUpdate()
    {
        Move(); 

        if(obtainedFood == 5)
        {
            SceneManager.LoadScene(nextScene);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            audioSource.Play();
            if(obtainedFood == 1)
            {
                spriteRenderer.sprite = oneConsumed;
            }
            else if (obtainedFood == 3)
            {
                spriteRenderer.sprite = twoConsumed;
            }
            obtainedFood++;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("hazard"))
        {
            deathCount.SetDeath();
            this.gameObject.SetActive(false);
        }
    }
}
