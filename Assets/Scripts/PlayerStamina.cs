using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStamina
{
    int _currentStamina;

    public int CurrentStamina {
       get
        {
            return _currentStamina;
        }
        set {
            _currentStamina = value;
        }

    }

    public PlayerStamina (int stamina)
    {
        _currentStamina = stamina;
    }

    public void LoseStamina (int damage)
    {
        if( _currentStamina > 0) {
            _currentStamina -= damage;
        }
        //if( _currentStamina == 0 || _currentStamina < 0) {
        //    LoadScene("GameOver");
        //}
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
