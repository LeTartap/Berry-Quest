using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    public int damageToGive;
    // Use this for initialization
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
        }
    }
}
