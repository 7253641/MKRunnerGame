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
    float horizontalMovement;
    [HideInInspector]
    public int PlayerScore;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        JumpControl();
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
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void MovementControl()
    {
        rb2d.velocity = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, rb2d.velocity.y);
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
