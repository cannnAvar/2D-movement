using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    public float speed = 5;
    public float jumpSpeed = 7;

    private bool facingRight = true;

    float xInput;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    private bool isGround;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform foot;
    [SerializeField] private float footRadius = 0.3f;

    void Update()
    {
        //GroundCheck
        isGround = Physics2D.OverlapCircle(foot.position, footRadius, ground);
        
        //Input
        xInput = Input.GetAxisRaw("Horizontal");
        
        //Jump
        if (Input.GetKeyDown(jumpKey) && isGround)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        //Turning Face
        if (facingRight == false && xInput > 0)
            Flip();
        
        else if (facingRight == true && xInput < 0)
            Flip();
       
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler; 
    }
}
