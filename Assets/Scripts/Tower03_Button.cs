using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower03_Button : MonoBehaviour
{
    private Animator anim;

    private Button twr03;
    private bool onEnable03 = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        twr03 = FindObjectOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateButton03();
    }

    private void AnimateButton03()
    {

        if (twr03.interactable)
        {
            anim.SetBool("onEnable03", onEnable03);
        }
    }
}
