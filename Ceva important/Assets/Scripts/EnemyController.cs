using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody myRB;
    public float movespeed;
    public PlayerController thePlayer;


	// Use this for initialization
	void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
	}


    void FixedUpdate()
    {
    myRB.velocity = (transform.forward*movespeed);    
    }

    // Update is called once per frame
    void Update ()
    {
        transform.LookAt(thePlayer.transform.position);	
	}
}
