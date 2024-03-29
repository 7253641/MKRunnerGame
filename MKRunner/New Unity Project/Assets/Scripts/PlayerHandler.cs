﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float jumpForce;
    public float fallMultiplier = 2;
    public float moveSpeed = 1.5f;
    [HideInInspector]
    public int PlayerScore;
    public GameObject DeathFX;
    public int leftBound;
    public int rightBound;
    public Joystick joystick;
    public bool isOnMobileControl;
    [HideInInspector]
    public int currentHighestScore;

    float horizontalMovement;
    float MeterTravelled;
    SoundFXManager sound;
    Animator animator;
    bool grounded = true;
    Rigidbody2D rb2d;
    int jumpCount = 2;
    Touch touchInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SaveAndLoad.LoadPlayer() != null)
        {
            currentHighestScore = SaveAndLoad.LoadPlayer().currentHightestScore;
        }
        else
        {
            currentHighestScore = 0;
        }
        sound = FindObjectOfType<SoundFXManager>();
        PlayerScore = 0;
        rb2d = GetComponent<Rigidbody2D>();
        FindObjectOfType<SoundFXManager>().Play("Bike");
        animator = GetComponent<Animator>();
        print(currentHighestScore);
        GameHandler.instance.UpdateHighestScoreText(currentHighestScore);
    }

    private void Update()
    {
        MeterTravelled += Time.deltaTime * moveSpeed;
        horizontalMovement = Input.GetAxis("Horizontal");
        JumpControl();
        GameHandler.instance.SetMeter((int)MeterTravelled);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((int)rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * fallMultiplier * Physics2D.gravity.y * Time.fixedDeltaTime;
        }
        MovementControl();
    }

    void JumpControl()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MovementControl()
    {
        if (transform.position.x < rightBound && transform.position.x > leftBound)
        {
            if (isOnMobileControl == false)
            {
                rb2d.velocity = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(joystick.Horizontal * moveSpeed * Time.deltaTime, rb2d.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundHandler>() != null)
        {
            grounded = true;
        }

        if (collision.gameObject.GetComponent<ObstacleHandler>() != null ||
            collision.gameObject.tag == "Finish")
        {
            GameHandler.instance.ShowGameOverState();
            GameHandler.instance.finalMeter = (int)MeterTravelled;
            GameHandler.instance.finalScore = PlayerScore;
            GameHandler.instance.SetFinalMeter((int)MeterTravelled);
            GameHandler.instance.SetFinalScore(PlayerScore);
            GameHandler.instance.isGameOver = true;
            
            sound.Stop("Bike");
            sound.Play("PlayerDead");
            sound.Play("PlayerDead2");
            Instantiate(DeathFX, transform.position, transform.rotation);
            
            if (PlayerScore > currentHighestScore)
            {
                currentHighestScore = PlayerScore;
                SavePlayer();
            }
            Destroy(gameObject);

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundHandler>() != null)
        {
            grounded = false;
        }
    }

    public void Jump()
    {
        if (grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    public void SavePlayer()
    {
        SaveAndLoad.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        currentHighestScore = SaveAndLoad.LoadPlayer().currentHightestScore;
    }
}
