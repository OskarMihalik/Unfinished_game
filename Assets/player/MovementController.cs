using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private GameObject playerAnimationObject;
    public Rigidbody2D rg;
    public float horizontalSpeed = 0f;
    public float jumpForce = 5f;
    public GroundCheckerController groundCheckController;
    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;
    public bool canMove = true;
    public float dashforce;
    private float dashTime;
    public float startDashTime;
    public bool canDash;

    private AudioManager audioManager;
    
    private int direction; // 1:left, 2:right, 0:nothing
    private Vector3 playerStartingPos;
    private TrailRenderer _trailRenderer;

    //private bool facing = false; // true: left, false: right
    
    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        dashTime = startDashTime;
        playerStartingPos = transform.position;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (canMove)
        {
            Dash(); //also Move() inside
            Jump();
            BetterJump();
            ActivateDeactivateTrailRenderer();
        }

    }
    
    public void MovePlayerAtStartOfLevel()
    {
        transform.position = playerStartingPos;
    }
    public void StopMoving()
    {
        canMove = false;
        rg.velocity = new Vector2(0f, 0f); 
        playerAnimationObject.SetActive(true);
    }

    public void ResumeMoving()
    {
        canMove = true;
        playerAnimationObject.SetActive(false);
    }

    private void Move(float moveX)
    {
        float moveBy = moveX * horizontalSpeed;
        rg.velocity = new Vector2(moveBy, rg.velocity.y);
        // change player facing direction
        if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

    }

    private void Jump()
    {
        if (Input.GetAxisRaw("Jump") > 0 && groundCheckController.isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);
            groundCheckController.isGrounded = false;
            audioManager.Play("Jump");
        }
    }
    
    private void BetterJump() {
        if (rg.velocity.y < 0) {
            rg.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rg.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rg.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    private void ActivateDeactivateTrailRenderer()
    {
        if (groundCheckController.isGrounded)
        {
            _trailRenderer.emitting = false;
        }
        else
        {
            _trailRenderer.emitting = true;
        }
    }
    private void Dash()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Move(x);
        if (canDash)
        {
            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (x < 0)
                    {
                        direction = 1;
                    }
                    else if (x > 0)
                    {
                        direction = 2;
                    }
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rg.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        rg.velocity = Vector2.left * dashforce;
                    }
                    else if (direction == 2)
                    {
                        rg.velocity = Vector2.right * dashforce;
                    }
                }
            }
        }

    }


}
