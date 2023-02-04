using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

public class PlayerController : KinematicObject
{
    public float maxSpeed = 7;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    public Stamina stamina;
    public bool controlEnabled = true;
    public Collider2D collider2d;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (controlEnabled)
        {
            move.x = Input.GetAxis("Horizontal");
        }
        else
        {
            move.x = 0;
        }
        base.Update();
    }
}
