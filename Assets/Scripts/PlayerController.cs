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
    float xDirection = 0f;
    float yDirection = 0f;

    [SerializeField] StaminaBarScript _staminaBar;


    public Collider2D collider2d;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        CheckInput();
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
    }

    private void MovementLeftRight()
    {
        xDirection = Input.GetAxis("Horizontal");
        if (xDirection > 0f)
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
            //transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else if (xDirection < 0f && Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
            //transform.Translate(Vector2.left * _speed * Time.deltaTime);
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
            //transform.Translate(Vector2.up * _speed * Time.deltaTime);
            PlayerLoosesStamina(1);
            climb = true;
        }
        else if (yDirection < 0f)
        {
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
            //transform.Translate(Vector2.down * _speed * Time.deltaTime);
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
        //if (col.gameObject.tag == "Ground")
        //{
        //    isGrounded = true;
        //}

        if(col.gameObject.tag == "Tick")
        {
            Debug.Log("here");

        }
    }

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Climb");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Climb");
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("WalkRight");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("WalkLeft");
        }

    }
}
