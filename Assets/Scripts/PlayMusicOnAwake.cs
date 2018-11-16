using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnAwake : MonoBehaviour
{
    private AudioSource source;
    public AudioClip start;

    public bool play;
    bool toggle;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start ()
    {
        play = true;
        toggle = true;
	}

    private void Update()
    {
        if (play && toggle)
        {
            source.clip = start;
            source.Play();
            toggle = false;
        }

        if (!play && toggle)
        {
            source.Stop();
            toggle = false;
        }
    }
}
