﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController2D : MonoBehaviour
{
    public Text lifeText;
    public Text scoreText;
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer SpriteRenderer;
    bool isGrounded;
     [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    [SerializeField]
private float runSpeed = 2f;
[SerializeField]
private float jumpSpeed = 5f;
private int score;
private int life;
public Text loseText;
public float waitTime;
    private float JumpForce;
public float knockback;
public float knockbackLength;
public float knockbackCount;
public bool knockFromRight;

    void Start()
    {
       animator  = GetComponent<Animator>();
       rb2d = GetComponent<Rigidbody2D>();
       SpriteRenderer = GetComponent<SpriteRenderer>();
       scoreText.text = "Score: " + score.ToString ();
       lifeText.text = "Life: " + life.ToString ();
       life = 3;
       SetLivesText();
       loseText.text = "";
    }

   

    public void FixedUpdate()
   {
       if((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
      
       {
           isGrounded = true;

       }
       else
       {
           isGrounded = false;
           animator.Play("Mega Jump");
           
       }

       if(Input.GetKey("d") || Input.GetKey("right"))
       {
           rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
           if (isGrounded)
           animator.Play("Mega Run"); 
           

           SpriteRenderer.flipX = false;
       }
       else if(Input.GetKey("a") || Input.GetKey("left"))
       {
           if(knockbackCount <=0){
           rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
           } else {
               if(knockFromRight)
               rb2d.velocity = new Vector2(-knockback, knockback);
               if(knockFromRight)
               rb2d.velocity = new Vector2(knockback, knockback);
               knockbackCount -= Time.deltaTime;
           }
           if (isGrounded)
            animator.Play("Mega Run");

            SpriteRenderer.flipX = true;
       }

       else
       {
           if (isGrounded)
           animator.Play("mega");

           rb2d.velocity = new Vector2(0, rb2d.velocity.y);

          
       }

       if(Input.GetKey("space") && isGrounded)
       {
           rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Mega Jump");
       }
        




     
   }
 void OnTriggerEnter2D(Collider2D other) 
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {

        //... then set the other object we just collided with to inactive.
        other.gameObject.SetActive(false);
        score = score + 1;
        SetScoreText ();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            SetLivesText ();
        }
        
    }
    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 4)
        {
            Destroy(gameObject);
       Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Scubo2");
        }
    }

   void SetLivesText ()
    {
        lifeText.text = "Lives: " + life.ToString();
        if (life <= 0)
        {
           loseText.text = "You Lose!";
            
            Destroy(gameObject);
       Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Scubo1");  ;
    
     }
        }

   
    public void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
        Application.Quit();
    }
}
    }


