using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float bulletTimeStamp;
    public float bulletSpeed;
    public float rateOfFire;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        #region Bullet
        if (bulletTimeStamp <= Time.time)
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
                bulletTimeStamp = Time.time + rateOfFire;
            }
        #endregion 
    }
    void Fire()
    {
        //Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -bulletSpeed;


        // Destroy the bullet after 3 seconds
        Destroy(bullet, 5.0f);
    }
    
}
