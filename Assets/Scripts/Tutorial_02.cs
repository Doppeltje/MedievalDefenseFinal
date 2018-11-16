using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_02 : MonoBehaviour
{
    public bool destroy = false;

    private void Update()
    {
        if (destroy)
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
