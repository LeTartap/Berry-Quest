using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDealDamage : MonoBehaviour {
    public int damageToGive;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
}
