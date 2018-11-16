using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sounds
        {
            wall,
            die,
            arrow
        }

    public AudioClip[] sound_die;
    public AudioClip[] sound_arrow;
    public AudioClip[] sound_wall;

    private Enemy _enemy;

    public Sounds sound;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        _enemy = FindObjectOfType<Enemy>();
    }

    private void Update()
    {

    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.wall: // contains 1
                //int w = Random.Range(0, sound_wall.Length - 1);
                source.clip = sound_wall[0];
                source.Play();
                break;
            case Sounds.die: // contains 3
                int d = Random.Range(0, sound_die.Length);
                source.clip = sound_die[d];
                source.Play();
                break;
            case Sounds.arrow: // contains 2
                int a = Random.Range(0, sound_arrow.Length); //Random.Range(0, 1)??
                source.clip = sound_arrow[a];
                source.Play();
                Debug.Log(sound_arrow[a]);
                break;
        }
    }

    public Sounds RandomSound(Sounds[] soundArray)
    {
        Debug.Log(soundArray.Length);
        int i = Random.Range(0, soundArray.Length - 1);
        return soundArray[i];
    }

}
