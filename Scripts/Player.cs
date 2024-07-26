using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 500;
    private float Move;
    private Rigidbody2D playerRB;

    public float breathCurrent;
    public float breathMax = 5f;
    public bool isInside, isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
        breathCurrent = breathMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state == GameState.inGame)
        {
            Move = Input.GetAxis("Horizontal");
            playerRB.velocity = new Vector2(Move * speed, playerRB.velocity.y);

            Flip();

            if (!isInside)
            {
                breathCurrent -= Time.deltaTime;
            }
            else
            {
                breathCurrent = breathMax;
            }

            if (breathCurrent <= 0) { Death(); }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerRB.AddForce(transform.up * jumpForce);
            }
        }
    }

    void Flip()
    {
        if (Move > 0 && this.gameObject.transform.localScale.x <= 0 || Move < 0 && this.gameObject.transform.localScale.x >= 0)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, 1, 1);
        }
    }

    public void Death()
    {
        GameManager.instance.livesLeft -= 1;
        GameManager.instance.RespawnPlayer();
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionStay2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
