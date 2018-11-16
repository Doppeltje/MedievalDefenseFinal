using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower01_Button : MonoBehaviour
{
    private Animator anim;

    private Button twr01;
    private bool onEnable01 = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        twr01 = FindObjectOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateButton();
    }

    private void AnimateButton()
    {

        if (twr01.interactable)
        {
            anim.SetBool("onEnable01", onEnable01);
        }
    }
}
