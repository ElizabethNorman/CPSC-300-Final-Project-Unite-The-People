/** This massive script is what allows Ivan to be controlled by the player. 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvanController : MonoBehaviour
{
    private const float WALK_ACCEL = .8F;
    private const float MAX_VX = 10F;
    private const float MAX_VY = 1F;
    private const float JUMP_POWER = 6;
    private const float DASH_POWER = 100;
    Rigidbody2D m_Rigidbody;

    //made this public so it is editable in the unity program
    //this allows for easier testing 
    public float m_Speed = 10.0f;

    //bool isRunning = false;

    public Animator animator;

    float horizontalMove = 0f;

    public SpriteRenderer sprite;

    //public Weapon gun;

    public Transform gun;

    public Transform leftGun;
    public Transform rightGun;


    private bool isJumping;
    private bool goLeft;
    private bool goRight;

    private SpriteRenderer gunSprite;

    private int jumpCount; //ensure user can only jump once

    public VariableCount varCount;

    public AudioSource sound;

    void Start()
    {

        gunSprite = gun.GetComponent<SpriteRenderer>();
        //Fetch the Rigidbody2D component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        isJumping = false;
        //Set the speed of the GameObject 
        //m_Speed = 10.0f;
        jumpCount = 0;

    }

    //FIXEDUPDATE is based on frame rate, actual animation changes should be here
    void FixedUpdate()
    {
        Vector3 vel = m_Rigidbody.velocity;

        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;

            jumpCount++;
        }

        //this is for jumping
        while (isJumping == true && jumpCount < 10)
        {

            Debug.Log("is jumping" + isJumping + jumpCount);

            m_Rigidbody.velocity = new Vector3(vel.x, JUMP_POWER, 0);
            vel = m_Rigidbody.velocity;
            //isJumping = false;
            //animator switches to jump animation
            //the exit for animation can be found in the collider method below
            animator.SetBool("isJumping", true);
            jumpCount = 0;
            isJumping = false;

        }

        //go left
        if (goLeft == true)
        {
            if (vel.x > -MAX_VX)
            {
                // Only accelerate if we are not at max vx
                m_Rigidbody.velocity = new Vector3(vel.x - WALK_ACCEL, vel.y, 0);
                goLeft = false;

            }

        }

        //go right
        if (goRight == true)
        {
            if (vel.x < MAX_VX)
            {

                // Only accelerate if we are not at max vx
                m_Rigidbody.velocity = new Vector3(vel.x + WALK_ACCEL, vel.y, 0);


                goRight = false;
            }

        }



        //CheckDash();
        ApplyDrag();
        // ClampVelocity();
    }

    //Update should take in keyboard input
    void Update()
    {
       
        //the run animation is decided on if the player is holding down an arrow key or not. 
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.A))
        {
            goLeft = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            goRight = true;
        }

        if (horizontalMove >= 0.01f)
        {
            gun.transform.position = rightGun.position;
            gunSprite.flipX = false;
            sprite.flipX = false;

        }
        else if (horizontalMove <= -0.01f)
        {
            gunSprite.flipX = true;
            gun.transform.position = leftGun.position;
            sprite.flipX = true;
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (varCount.returnGun() && !varCount.returnPause())
            {
                sound.Play();
            }
           
        }
       // CheckDash();
    }

    private bool LastPressedL = false;
    private bool LastPressedR = false;
    private int LTrgTicks = 0;
    private int RTrgTicks = 0;
    private int DashCooldown = 0;

    void OnCollisionEnter2D(Collision2D other)
    {

        //Because all movement is decided on within the update method, it updates too fast to reasonably handle the jump animation
        //Here, after we jump, this checks to see if the floor has been collided with to return to a non-jumping animation
        if (other.gameObject.CompareTag("tile") || other.gameObject.CompareTag("Platform"))
        {

            animator.SetBool("isJumping", false);
            isJumping = false;
            jumpCount = 0;
        }
    }

    void CheckDash()
    {

        DashCooldown--;
        if (DashCooldown > 0)
        {
            return;
        }

        bool left = Input.GetKey(KeyCode.A);
        LTrgTicks--;
        if (left && !LastPressedL)
        {
            //L triggered
            if (LTrgTicks > 0)
            {
                //dashing time
                m_Rigidbody.velocity = new Vector3(-DASH_POWER, m_Rigidbody.velocity.y, 0);
                LTrgTicks = 0;
                DashCooldown = 600;
            }
            else
            {
                //Allow x ticks to trigger L again.
                LTrgTicks = 300;
            }
        }

        LastPressedL = left;

        bool right = Input.GetKey(KeyCode.D);
        RTrgTicks--;
        if (right && !LastPressedR)
        {
            //R triggered
            if (RTrgTicks > 0)
            {
                //dashing time
                m_Rigidbody.velocity = new Vector3(DASH_POWER, m_Rigidbody.velocity.y, 0);
                RTrgTicks = 0;
                DashCooldown = 600;
            }
            else
            {
                //Allow x ticks to trigger R again.
                RTrgTicks = 300;
            }
        }

        LastPressedR = right;
    }

    void ApplyDrag()
    {
        float drag = 0.995F;
        if (Math.Abs(m_Rigidbody.velocity.x) > MAX_VX)
        {
            // Apply more drag if above speed cap
            drag = 0.40F;
        }
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x * drag, m_Rigidbody.velocity.y, 0);
    }

    public void stopJump()
    {

        jumpCount = 0;
        isJumping = false;
        Debug.Log("this has been hit, " + jumpCount);
    }


    // NOTE: NOT USED ATM
    void ClampVelocity()
    {
        if (m_Rigidbody.velocity.x > MAX_VX)
        {
            m_Rigidbody.velocity = new Vector3(MAX_VX, m_Rigidbody.velocity.y, 0);
        }

        if (m_Rigidbody.velocity.x < -MAX_VX)
        {
            m_Rigidbody.velocity = new Vector3(-MAX_VX, m_Rigidbody.velocity.y, 0);
        }

        if (m_Rigidbody.velocity.y > MAX_VY)
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, MAX_VY, 0);
        }

        if (m_Rigidbody.velocity.y < -MAX_VY)
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, -MAX_VY, 0);
        }
    }
}