using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 0;
    public TMP_Text scoreDisplay;
    private int score = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);

        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation += 1;
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            speed = 4;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            speed = -4;
        }
        else 
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation -= 1; 
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("worm"))
        {
            Destroy(collision.gameObject);
            score = score + 1;
            scoreDisplay.text = "Score: " + score;
        }
    }
}
