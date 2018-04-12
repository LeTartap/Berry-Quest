using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firepoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Instantiate(bullet, firepoint.position, firepoint.rotation);
                BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
}
