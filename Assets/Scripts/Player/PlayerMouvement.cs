using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMouvement : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;
    public float speed = 400;
    public Rigidbody2D playerRB;

    public Animator animator;

    public bool isFacinfRight = true;

    public float JumpForce=5;

    bool isGrounded ;

    public Transform groundCheck;

    public LayerMask groundLayer;

    int numberOfJumps = 0;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        
        
        controls.Land.jump.performed += ctx =>
        {
            Jump();
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(direction));

        if (isFacinfRight && direction < 0 || !isFacinfRight && direction > 0)
        {
            Flip();
        }

        
    }

    void Flip()
    {
        isFacinfRight = !isFacinfRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        
    }
    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps=0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, JumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if(numberOfJumps==1)
            {
                numberOfJumps++;
                playerRB.velocity = new Vector2(playerRB.velocity.x, JumpForce);
                AudioManager.instance.Play("SecondJump");
            }
        }
        
    }


}
