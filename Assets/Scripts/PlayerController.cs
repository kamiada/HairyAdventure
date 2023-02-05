using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3.0f;
    Rigidbody2D _rb;
    public Animator animator;
    bool climbCheck = false;
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
            climbCheck = true;

        }
        else { climbCheck = false; }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("Level1");
        }

        if (GameManager._gameManager._playerStamina.CurrentStamina == 0 || GameManager._gameManager._playerStamina.CurrentStamina < 0) {
            SceneManager.LoadScene("Death");
        }
    }

    private void FixedUpdate()
    {
        MovementLeftRight();
        if (climbCheck)
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
        }
        else if (xDirection < 0f && Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(xDirection * _speed, _rb.velocity.y);
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
            climbCheck = true;
        }
        else if (yDirection < 0f)
        {
            _rb.velocity = new Vector2(0, yDirection * _speed * Time.deltaTime);
            PlayerLoosesStamina(1);
            climbCheck = true;

        }

    }


    private void PlayerLoosesStamina(int loss) {
        GameManager._gameManager._playerStamina.LoseStamina(loss);
        _staminaBar.SetStamina(GameManager._gameManager._playerStamina.CurrentStamina);
    }

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
        else if (GameManager._gameManager._playerStamina.CurrentStamina == 0 || GameManager._gameManager._playerStamina.CurrentStamina < 0)
        {
            animator.SetTrigger("Fall");
        }

    }
}
