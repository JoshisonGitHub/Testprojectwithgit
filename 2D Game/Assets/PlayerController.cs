using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TODO: Implement coyote time on jumping
    //TODO: Break Update() into dedicated functions to simplify legibility
    //TODO: Implement momentum (probably create methods to verify adherence to laws of physics)

    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    private bool facingRight = true;
    public Transform playertransform;

    //jumping
    
    public float jumpheight;
    public float sprintjump;
    private float originaljumpheight;
    private int extraJump;
    public int extraJumpValue;
    private float orignalgravity;
    public float maxgravity;

    //left right movements
    private float speed;
    public float walkspeed;
    public float runspeed;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float moveInput;

    //wall sliding 
    private bool istouchingfront;
    public Transform frontcheck;
    private bool wallsliding;
    public float wallslidingspeed;

    //wall jumping
    private bool walljumping;
    public float ywallforce;
    public float xwallforce;
    public float walljumptime;

    //leniency windows
    public float wallclingdecay;

    void Start()
    {
        originaljumpheight = jumpheight;
        orignalgravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //regular movement
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.W) && extraJump > 0 || Input.GetKeyDown(KeyCode.Space) && extraJump > 0 || Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpheight;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true || Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true || Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpheight;
        }
        
        //increases gravity when holding s (makes the player fall faster)
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale += (float)0.5;
        }
        else{
            rb.gravityScale = orignalgravity;
        }

        //increases jumpheight, speed, wall jump height when holding shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            jumpheight = sprintjump;
            speed = runspeed;
            //increase walljumpheight
        }
        else
        {
            jumpheight = originaljumpheight;
            speed = walkspeed;
            //increase walljumpheight
        }
        
        //limits gravity to maxgravity
        if(rb.gravityScale >= maxgravity)
        {
            rb.gravityScale = maxgravity;
        }

        //wallsliding
        istouchingfront = Physics2D.OverlapCircle(frontcheck.position, checkRadius, whatIsGround);
        if(istouchingfront && !isGrounded && moveInput != 0)
        {
            wallsliding = true;
        }
        else
        {
            Invoke("Setwallslidetofalse", wallclingdecay);
        }

        if (wallsliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallslidingspeed, float.MaxValue));
        }

        //walljumping
        if(Input.GetKeyDown(KeyCode.W) && wallsliding || Input.GetKeyDown(KeyCode.Space) && wallsliding || Input.GetKeyDown(KeyCode.UpArrow) && wallsliding)
        {
            walljumping = true;
            Invoke("SetWalljumptofalse", walljumptime);
        }

        if (walljumping)
        {
            rb.velocity = new Vector2(xwallforce * -moveInput, ywallforce);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scalar = playertransform.localScale;
        Scalar.x *= -1;
        playertransform.localScale = Scalar;
    }

    //wrapped invocation methods
    void SetWalljumptofalse()
    {
        walljumping = false;
    }

    void Setwallslidetofalse()
    {
        wallsliding = false;
    }
}
