using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float jumpForce;
    bool grounded = true;
    public float fallMultiplier = 2;
    public float moveSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((int)rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * fallMultiplier * Physics2D.gravity.y * Time.deltaTime;
        }
        JumpControl();
        MovementControl();
    }

    void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce * Time.fixedDeltaTime);
        }
    }

    void MovementControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundHandler>() != null)
        {
            grounded = true;
        }

        if (collision.gameObject.GetComponent<ObstacleHandler>() != null)
        {
            SceneHandler.instance.ReloadCurrentScene();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundHandler>() != null)
        {
            grounded = false;
        }
    }
}
