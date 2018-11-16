using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialNextButton : MonoBehaviour
{
    private Tutorial_02 _02;
    public GameObject nextText; //  inspector
    bool secondClick = false;
    bool firstClick = true;

	// Use this for initialization
	void Start () {
        _02 = FindObjectOfType<Tutorial_02>();
        Debug.Log("Button script is initialized");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickFunction()
    {
        if (secondClick)
        {
            SecondClick();
        }

        if (firstClick)
        {
            FirstClick();  
        }
    }

    void FirstClick()
    {
        _02.destroy = true;
        SpawnNewText();
        firstClick = false;
        secondClick = true;
    }

    void SecondClick()
    {
        SceneManager.LoadScene("Level_00");
    }

    
    private void SpawnNewText()
    {
        float x = 0.7f;
        float y = -2.4f;
        GameObject three = Instantiate(nextText);
        three.transform.position = new Vector2(x, y);
    }
}
