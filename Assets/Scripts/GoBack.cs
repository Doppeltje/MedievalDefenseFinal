using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{

    private Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }
    public void PreviousScene()
    {
        camera.GetComponent<PlayMusicOnAwake>().play = false;
        SceneManager.LoadScene("MainMenu");
    }
}
