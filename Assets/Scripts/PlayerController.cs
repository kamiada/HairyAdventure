using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3.0f;
    Rigidbody2D _rb;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    bool climb = false;
    bool right = false;
    bool left = false;
    float xDirection = 0f;
    float yDirection = 0f;
    bool isGrounded = true;

    [SerializeField] StaminaBarScript _staminaBar;


    public Collider2D collider2d;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            climb = true;

        }
        else { climb = false; }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        MovementLeftRight();
        if (climb)
        {
            _rb.gravityScale = 0;
            Climb();
        }
        else
        {
            _rb.gravityScale = 2;
        }
        animator.SetBool("climb", climb);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("left", left);
        animator.SetBool("right", right);
    }

    private void MovementLeftRight()
    {
        xDirection = Input.GetAxis("Horizontal");
        if (xDirection > 0f)
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
            right = false;
            left = true;

        }
        else if (xDirection < 0f)
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
            left = false;
            right = true;
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }

    }

    private void Climb()
    {
        yDirection = Input.GetAxis("Vertical");
        if (yDirection > 0f)
        {
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
            PlayerLoosesStamina(1);
            climb = true;
        }
        else if (yDirection < 0f)
        {
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
            PlayerLoosesStamina(1);
            climb = true;

        }

    }


    private void PlayerLoosesStamina(int loss) {
        GameManager._gameManager._playerStamina.LoseStamina(loss);
        _staminaBar.SetStamina(GameManager._gameManager._playerStamina.CurrentStamina);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
