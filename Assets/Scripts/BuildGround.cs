using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGround : MonoBehaviour
{

    public bool hasTower = false;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Tower"))
        {
            hasTower = true;
        }
    }
}
