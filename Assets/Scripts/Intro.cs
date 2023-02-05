using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Intro : MonoBehaviour
{
    public Sprite[] introduction_img_arr;
    //public Button next;
    //public Image introImage;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        //Button btn = next.GetComponent<Button>();
        //Image img = introImage.GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("Level1");
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (introduction_img_arr.Length < 0)
            {
                foreach (Sprite sprite in introduction_img_arr)
                {
                    Debug.Log("here");
                    spriteRenderer.sprite = sprite;
                }
            }
        }
    }
    //void TaskOnClick()
    //{
    //    if(introduction_img_arr.Length < 0) {
    //        foreach(Sprite sprite in introduction_img_arr)
    //        {
    //            spriteRenderer.sprite = sprite;
    //        }
    //    }

    //}
}
