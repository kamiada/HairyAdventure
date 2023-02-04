using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3.0f;
    Rigidbody2D _rb;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    bool climb = false;
    float xDirection = 0f;
    float yDirection = 0f;
    bool facingRight;
    Sprite ClimbingSprite;

    [SerializeField] StaminaBarScript _staminaBar;


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
        Debug.Log(GameManager._gameManager._playerStamina.CurrentStamina);

    }

    private void MovementLeftRight()
    {
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
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
            PlayerLoosesStamina(1);
        }
        else if (yDirection < 0f)
        {
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
        }

    }

    public void Flipping()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }


    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Down");
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("Right");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Left");
        }

    }
    private void PlayerLoosesStamina(int loss) {
        GameManager._gameManager._playerStamina.LoseStamina(loss);
        _staminaBar.SetStamina(GameManager._gameManager._playerStamina.CurrentStamina);
    }


}
