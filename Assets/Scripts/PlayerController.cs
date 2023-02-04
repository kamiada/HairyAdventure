using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5f;
    Rigidbody2D _rb;
    Vector2 _playerInputAxisX;
    Vector2 _playerInputAxisY;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    bool climb = false;
    float xDirection = 0f;
    float yDirection = 0f;
    bool facingRight;


    public Collider2D collider2d;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            climb = true;
            
        } else { climb = false; }
    }

    private void FixedUpdate()
    {
        MovementLeftRight();
        if (climb)
        {
            Climb();
        }
    }

    private void MovementLeftRight() {
        xDirection = Input.GetAxis("Horizontal");
        if (xDirection > 0f)
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
        }
        else if (xDirection < 0f)
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if (xDirection < 0 && facingRight)
        {
            Flipping();

        }
        if (xDirection > 0 && !facingRight)
        {
            Flipping();
        }
    }

    private void Climb()
    {
        yDirection = Input.GetAxis("Vertical");
        if (yDirection > 0f)
        {
            //_rb.velocity = new Vector2(Input.GetAxis("Vertical") * _speed, _rb.velocity.x);
            _rb.velocity = new Vector2(0, Mathf.Lerp(0, yDirection * _speed, 0.8f));
        }
        else if (yDirection < 0f)
        {
            //_rb.velocity = new Vector2(Input.GetAxis("Vertical") * _speed, _rb.velocity.x);
            _rb.velocity = new Vector2(0, Mathf.Lerp(0, yDirection * _speed, 0.8f));
        }
    }

    public void Flipping()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }


}
