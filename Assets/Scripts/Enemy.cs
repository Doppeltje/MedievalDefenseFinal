using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public ScoreScript _score;
    private WoodScript _wood;
    private StoneScript _stone;
    private World _world;
    private SoundManager _sm;

    public GameObject enemy;
    public Animator anim;
    private Lock_On _lockOn;
    IsTargeted _targeted;

    private Vector2 curPos;
    private Vector2 lastPos;

    private bool moving = false;
    private bool hurt = false;
    [SerializeField]
    public int health;
    private int damage = 4;
    private int curHealth;
    public bool isAlive = true;


    // Use this for initialization
    void Start()
    {
        _sm = FindObjectOfType<SoundManager>();
        _world = FindObjectOfType<World>();
        _score = FindObjectOfType<ScoreScript>();
        curHealth = health;
        _lockOn = FindObjectOfType<Lock_On>();
        _targeted = FindObjectOfType<IsTargeted>();
        _wood = FindObjectOfType<WoodScript>();
        _stone = FindObjectOfType<StoneScript>();

        if (_score.scoreValue > 10)
        {
            health = (health * 2);
            if (_score.scoreValue > 20)
            {
                health = (health + 40);
                if (_score.scoreValue > 50)
                {
                    health = (health * 2);
                }
            }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
               //check if object is moving
        curPos = enemy.transform.position;
        if (curPos == lastPos)
        {
            anim.SetBool("Moving", moving);
        }
        else
        {
            anim.SetBool("Moving", !moving);
        }
        //set last position to current position
        lastPos = curPos;

        // check if enemy dies
        if (health <= 0)
        {
            _world.EnemyDieSound();
            AddScore();
            isAlive = false;

            // destroy the unit
            Destroy(gameObject);
        } 
    }

    void AddScore()
    {
        // play sound
        _sm.PlaySound(SoundManager.Sounds.die);

        // add score on kill
        _score.scoreValue += 1;
        _wood.woodValue += 1;

        if (_score.scoreValue > 30)
        {
            _stone.stoneValue += 2;
        }

        if (_score.scoreValue > 10)
        {
            health += 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "arrow(Clone)")
        {
            health -= damage;
            anim.SetBool("Hurt", hurt);
            curHealth = health;
        }
        if (col.gameObject.name == "Fireball(Clone)")
        {
            health -= damage * 3;
            anim.SetBool("Hurt", hurt);
            curHealth = health;
        }
        if (col.gameObject.name == "Rock(Clone)")
        {
            health -= damage * 2;
            anim.SetBool("Hurt", hurt);
            curHealth = health;
        }
    }
}
