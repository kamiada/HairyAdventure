using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager _gameManager { get; private set; }

    public PlayerStamina _playerStamina = new PlayerStamina(100);
    void Awake()
    {
        if (_gameManager != null && _gameManager != this) {
            Destroy(this);
        }   else { _gameManager = this; }
    }
}
