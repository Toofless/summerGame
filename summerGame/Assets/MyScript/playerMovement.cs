using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody2D rb2d;
    float moveHorz = 0f;
    float moveVert = 0f;
    Animator anim;
    public float jumpPower = 150f;
    SpriteRenderer flip;
    public int jumpCount;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorz = Input.GetAxisRaw("Horizontal") * speed;

    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveHorz, moveVert);
        rb2d.AddForce(movement * speed);

        //Ensure that we move the same amount no matter how often it's called
        //controller.Move(moveHorz * Time.fixedDeltaTime, false, false);

        //Flips animation direction
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) || Input.GetKey("left")) || Input.GetKey("right"))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
            {
                flip.flipX = true;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
            {
                flip.flipX = false;
            }
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
        }

        else
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping || Input.GetKeyDown(KeyCode.W) && !isJumping || Input.GetKey("up") && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
            isJumping = true;
            //++jumpCount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            //jumpCount = jumpCount - 2;
        }
    }
}
