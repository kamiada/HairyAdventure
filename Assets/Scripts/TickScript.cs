using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickScript : MonoBehaviour
{
    public Animator tick_animator;
    void Start()
    {
        tick_animator = GetComponent<Animator>();
        StartCoroutine(CheckIfAnimIsPlaying());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            tick_animator.SetTrigger("playerAround");
        }
    }

    private IEnumerator CheckIfAnimIsPlaying()
    {
        if (tick_animator.GetCurrentAnimatorStateInfo(0).IsName("TickBlowUp"))
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Death");
        }

    }
}
