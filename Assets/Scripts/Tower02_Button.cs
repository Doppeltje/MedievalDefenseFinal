using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower02_Button: MonoBehaviour
{
    private Animator anim;

    private Button twr02;
    private bool onEnable02 = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        twr02 = FindObjectOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateButton02();
    }

    private void AnimateButton02()
    {

        if (twr02.interactable)
        {
            anim.SetBool("onEnable02", onEnable02);
        }
    }
}
