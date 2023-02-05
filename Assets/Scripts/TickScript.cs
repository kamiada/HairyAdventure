using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickScript : MonoBehaviour
{
    [SerializeField] StaminaBarScript _staminaBar;

    public Animator tick_animator;
    void Start()
    {
        tick_animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            tick_animator.SetTrigger("playerAround");
            GameManager._gameManager._playerStamina.LoseStamina(20);
            _staminaBar.SetStamina(GameManager._gameManager._playerStamina.CurrentStamina);

        }
    }

}
