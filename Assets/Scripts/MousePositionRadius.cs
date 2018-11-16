using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionRadius : MonoBehaviour
{
    private GameObject bg;
    private ChangeCursor towerArray;
    private Parent_Tower pT;
    private FindClosest close;
    private BuildGround _bground;

    public AudioSource source;
    public AudioClip sound_die;
    public AudioClip sound_wall;

    float placeX;
    float placeY;
      
    private int towerIndex;

    public bool canBuildTower = false;
    bool occupied = false;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        bg = GameObject.FindGameObjectWithTag("BuildGround");
        towerArray = FindObjectOfType<ChangeCursor>();
        pT = FindObjectOfType<Parent_Tower>();
        close = GetComponent<FindClosest>();
        _bground = FindObjectOfType<BuildGround>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (bg.tag == "BuildGround" && !occupied)
        {
            canBuildTower = true;
        }
        else
        {
            return;
        }


        if (canBuildTower && pT.uiButtonActive)
        {
            if (!_bground.hasTower)
            {
                PlaceTower();
                canBuildTower = false;
                occupied = true;
                pT.uiButtonActive = false;
            }
        }  
    }

     void PlaceTower()
    {
        // get x and y from FindClosest script
        float x = close.x + 1;
        float y = close.y;
        towerIndex = towerArray.towerIndex;

        GameObject newTower = Instantiate(towerArray.BuildTowers[towerIndex]);

        // place new tower
        newTower.transform.position = new Vector2(x, y);

        PlaySoundEffect(sound_wall);
        // pay the cost
        pT.TowerCost();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        // play sound
        source.clip = clip;
        source.Play();
    } 
}
