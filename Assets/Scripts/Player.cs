using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private float _moveInput;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _feetPost;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _watIsGround;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool _isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   private void Update()
    {
        _isGrounded= Physics2D.OverlapCircle(_feetPost.position, _checkRadius, _watIsGround);

        if(_isGrounded && Input.GetKey(KeyCode.Space))
            rb.velocity = Vector2.up * _jump;
    }

    private void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_moveInput * _speed, rb.velocity.y);

        if (_moveInput < 0 && facingRight) Flip();
        else if(_moveInput > 0 && !facingRight) Flip();
        
        /*if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse);
            _isGrounded = false;
        }

        if (_moveInput != 0)
        {
            _anim.SetBool("isRunning", true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _anim.SetTrigger("isAttacking");
        }*/
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
