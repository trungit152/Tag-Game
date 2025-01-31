using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float horizontal;
    private Rigidbody2D rb;
    PhotonView view;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = rb.GetComponent<PhotonView>();
    }

    void Update()
    {
        IsGround();
        JumpPressed();
        MovePressed();
    }
 
    private void JumpPressed()
    {
        if(view.IsMine)
        {
            if (Input.GetButtonDown("Jump") && IsGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

    }
    private void MovePressed()
    {
        if (view.IsMine)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

    }
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
