using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Input Systen Setup
    _Input input;
    [Header("Set-Up")]
    public CharacterController Controller;
    public Animator anim;
    [Header("Player Stats")]
    public float Speed = 2.5f;
    public float SpriteSpeed = 5f;
    public float CrouchSpeed = 1.25f;
    public float Gravity = -9.81f;
    public float jumpHeight = 3f;
    [Header("Ground Collisions")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [Header("Hidden Variables")]
    [HideInInspector]
    public float x;
    [HideInInspector]
    public float z;
    bool jumped;
    [HideInInspector]
    public bool Spriting;
    [HideInInspector]
    public bool crouch;
    Vector3 velocity;
    [HideInInspector]
    public bool isGrounded;
    float gravity;
    Vector3 move;
    bool c;

    void Awake()
    {
        //input System
        input = new _Input();

        input.Player.Forward.performed += ctx => z += 1;
        input.Player.Forward.canceled += ctx => z += -1;
        input.Player.Back.performed += ctx => z += -1;
        input.Player.Back.canceled += ctx => z += 1;

        input.Player.Left.performed += ctx => x += -1;
        input.Player.Left.canceled += ctx => x += 1;
        input.Player.Right.performed += ctx => x += 1;
        input.Player.Right.canceled += ctx => x += -1;

        input.Player.Sprite.performed += ctx => Spriting = true;
        input.Player.Sprite.canceled += ctx => Spriting = false;

        input.Player.Jump.performed += ctx => jumped = true;
        input.Player.Jump.canceled += ctx => jumped = false;

        input.Player.Crouch.performed += ctx => crouch = !crouch;
    }

    void Update()
    {
        gravity = Gravity * 4;
        //Check if player is grounded or not?
        //Ceate a physical sphere under the player's legs
        //If sphere hit a collider with the right ground layer returns true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Set Slopelimit and reset falling velocity
        if (isGrounded && velocity.y < 0)
        {
            Controller.slopeLimit = 45.0f;
            velocity.y = -2f;
        }

        //apply calculations to move variable movement if player is grounded
        if (isGrounded)
        {
            if(x == 0 && z == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Sprite", false);
            }
            else
            {
                if(Spriting)
                {
                    anim.SetBool("Sprite", true);
                }
                else
                {
                    anim.SetBool("Walk", true);
                    anim.SetBool("Sprite", false);
                }
            }
            move = Vector3.Normalize(transform.right * x + transform.forward * z);
        }

        //if player's crouching, use to crouch speed instead of regular speed
        if (!crouch)
        {
            //if player's spriting, use to sprit speed instead of regular speed
            if (Spriting)
            {
                Controller.Move((move * SpriteSpeed) * Time.deltaTime);
            }
            else
            {
                Controller.Move((move * Speed) * Time.deltaTime);
            }
        }
        else
        {
            Controller.Move((move * CrouchSpeed) * Time.deltaTime);
        }

        //Change CharacterController height when crouch
        if (crouch)
        {
            c = true;
            Controller.height = 0.85f;
        }
        else
        {
            //If a collider is on top of the player don't allow player to uncrouch
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up, out hit, 1.35f) && c == true)
            {
                c = true;
                Controller.height = 0.85f;
            }
            else
            {
                c = false;
                Controller.height = 1.7f;
            }
        }

        //Set jump velocity
        if (jumped == true && isGrounded && c == false)
        {
            jumped = false;
            Controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if ((Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = -2f;
        }
        //Add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        //Apply Jump velocity
        Controller.Move(velocity * Time.deltaTime);
    }

    //Enable and disable Input System
    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }
}
