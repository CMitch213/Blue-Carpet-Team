using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Headers just list your publics and categorize them so you can edit easier in editor
    [Header("Movement")]
    public float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float crouchY;
    public float startY;

    [Header("Ground Check")]
    public float height;
    public LayerMask groundMask;
    public  bool isGrounded;
    public float drag;

    [Header("Jumping and Shit")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMulti;
    public bool canJump = true;

    [Header("Keybindings")]
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode sprintInput = KeyCode.LeftShift;
    public KeyCode pauseInput = KeyCode.Escape;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Everything Else")]
    public Transform orientation;
    public GameObject pauseMenu;
    public bool isPaused;

    float xInput, zInput;

    Vector3 moveDir;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startY = transform.localScale.y;
    }

    //Set Inputs for the Movement
    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal"); /*Left and Right*/
        zInput = Input.GetAxisRaw("Vertical");  /*Forwards and Backwards*/

        //Jump Input
        if (Input.GetKey(jumpInput) && canJump && isGrounded)
        {
            canJump = false;
            Jump();
            //Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKeyDown(sprintInput))
        {
            speed = sprintSpeed;
        }
        else if(Input.GetKeyUp(sprintInput)) //if (!Input.GetKeyDown(sprintInput))
        {
            speed = walkSpeed;
        }

        if (Input.GetKeyDown(pauseInput))
        {
            Pause();
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchY, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            speed = crouchSpeed;
        }
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startY, transform.localScale.z);
            speed = walkSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, groundMask);
        if (isGrounded)
        {
            rb.drag = drag;
        }
        else
        {
            rb.drag = 0.1f;
        }

        if(rb.velocity.z > speed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        }
        if (rb.velocity.z < (speed * -1))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, (speed * -1));
        }
        if (rb.velocity.x > speed)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.x < (speed * -1))
        {
            rb.velocity = new Vector3((speed * -1), rb.velocity.y, rb.velocity.z);
        }

        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //See which direction this hoe is moving in
        moveDir = orientation.forward * zInput + orientation.right * xInput;

        if (isGrounded)
        {
            rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        }

        if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * speed * 10f * airMulti, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        canJump = true;
    }
    private void ResetJump()
    {
        canJump = false;
    }

    void Pause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        else if (isPaused == false)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        }
    }
}
