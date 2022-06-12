using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //alla gameobjects pou xreiazomaste
    public GameManager gm;

    //Particles
    public ParticleSystem deadParticle;
    public ParticleSystem hurtParticle;

    //Health
    public float startingHealth;
    [HideInInspector]
    public float health;
    //[HideInInspector]
    public bool canBeHit =true;
    //[HideInInspector]
    public float invisibleTimeCounter;
    public float invisibleTime;

    //move character
    private Rigidbody2D rb;
    public float moveSpeed;
    private float dirX;

    //animating
    private Animator anim;

    //Jump
    public float jumpHeight;
    private bool jumping = false;

    //Jump if isGrounded
    public Transform groundCheck;
    private bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //doubleJump
    public int extraJumpsValue;
    private int extraJumps;
    private bool doubleJumping = false;

    //wallKick
    public LayerMask whatIsWall;
    public Transform wallChek;
    public float wallCheckRadius;
    private bool isSliding;
    public float wallJump;
    public float wallKick;
    public float maxSlidingSpeed;
    private bool isWallkick = false;
    private float timeStartedWallKick;
    public float timeTakenDuringWallJump;

    //dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private bool isDashing;
    private float timeStartedDashing;
    public float timeTakenDuringDash;

    // flip Character
    private bool facingRight = true;
    private Vector3 localScale;

    //firing


    //Respawn
    [HideInInspector]
    public Vector3 respawnPosition;

    //Knockback
    [HideInInspector]
    public float knockbackCount;
    



    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        localScale = transform.localScale;
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Instantiate(deadParticle, transform.position, Quaternion.identity);
            gm.StartCoroutine("Destroy"); ;
            health = startingHealth;
            knockbackCount = 0;
        }
        else if (health>startingHealth)
        {
            health = startingHealth;
        }

        Debug.Log(health);
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        if (Input.GetButtonDown ("Jump"))
            if (isGrounded)
            {
                jump();
            }
        else if (!isGrounded && extraJumps >0)
            {
                doubleJump();
                extraJumps--;
            }

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        //Animation
        anim.SetFloat("moveSpeed",Mathf.Abs(dirX));
        if (rb.velocity.y > 0 && !isGrounded)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0 && !isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            anim.SetBool("isDoubleJumping", false);
        }

        if (rb.velocity.y == 0 || isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        //Animation

    }

    private void FixedUpdate()
    {
        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(dirX * Time.fixedDeltaTime, rb.velocity.y);
        }
        else if (knockbackCount >0)
        {
            knockbackCount -= Time.deltaTime;
        }

        if (invisibleTimeCounter <=0)
        {
            canBeHit = true;
        }
        else if (invisibleTimeCounter >0)
        {
            invisibleTimeCounter -= Time.deltaTime;
        }


        if (jumping)
        {
            rb.velocity = (Vector2.up * jumpHeight * Time.fixedDeltaTime);
            jumping = false;
        }
        if (doubleJumping)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJumping", true);
            rb.velocity = (Vector2.up * jumpHeight * 0.8f * Time.fixedDeltaTime);
            doubleJumping = false;

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);



    }
    
    void jump()
    {
        jumping = true;
    }

    void doubleJump()
    {
        doubleJumping = true;
    }

    void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
        {
            health -= 1;
            if (health >0)
            {
                gm.StartCoroutine("Destroy");
            }
        }

        if (collision.tag == "Checkpoint" && collision.transform.position.x > respawnPosition.x)
        {
            respawnPosition = collision.transform.position;
            Debug.Log("emfanizomai");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
