using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform ArrowTrailPrefab; //inspector

    private Vector2 direction;
    private Vector2 direction2;

    //private AudioSource source;
    private SoundManager _sm;


    Transform firePoint;
    Lock_On _lockOn;


	// Use this for initialization
	void Awake ()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not found. Check inspector.");
        }
        _lockOn = FindObjectOfType<Lock_On>();
	}

    private void Start()
    {
        //source = GetComponent<AudioSource>();
        _sm = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update ()
    {
		if (fireRate == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Shoot();
            }
            else
            {
                return;
            }
        }
    }

    public void Shoot()
    {
        float enemyX = _lockOn.targetX;
        float enemyY = _lockOn.targetY;

        //float angle;
        float angle2;
        //Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
        //                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 enemyPosition = new Vector3(enemyX, enemyY, 0);
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, 0);

        enemyPosition.x = enemyPosition.x - firePointPosition.x;
        enemyPosition.y = enemyPosition.y - firePointPosition.y;

        angle2 = Mathf.Atan2(enemyPosition.y, enemyPosition.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, angle2);

        direction2 = enemyPosition - firePointPosition;

        RaycastHit2D hit2 = Physics2D.Raycast(firePointPosition, direction2, 100, whatToHit);
        Effect2();



        if (hit2.collider != null)
        {
            return;
        }
    }


    void Effect2()
    {
        Instantiate(ArrowTrailPrefab, firePoint.position, firePoint.rotation);
        Debug.Log(SoundManager.Sounds.arrow);
        _sm.PlaySound(SoundManager.Sounds.arrow);
    }
}
