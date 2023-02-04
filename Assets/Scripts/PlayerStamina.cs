using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina
{
    int _currentStamina;
    int _maxStamina;

    public int CurrentStamind {
       get
        {
            return _currentStamina;
        }
        set {
            _currentStamina = value;
        }

    }

    public int MaxStamina {
        get
        {
            return _maxStamina;
        }
        set
        {
            _maxStamina = value;
        }
    }

}
