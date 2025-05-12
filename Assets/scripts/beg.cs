using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class beg : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;


 
    


    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Debug.Log(moveInput);

        if (moveInput == 0)
        {
            anim.SetBool("begitnet", false);
        }
        else
        {
            anim.SetBool("begitnet", true);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = Vector2.up * jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+1 * jumpForce);
            anim.SetTrigger("take off");
            return;
        }

        if (isGrounded == true)
        {
            anim.SetBool("prigaetnet", false);
        }
        else
        {
            anim.SetBool("prigaetnet", true);
        }
    }
    
    
}
    
