using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody myRB;
    public float movespeed;
    public PlayerController thePlayer;
    public float distance;//daca e mica inamicul intra de tot in player;

	// Use this for initialization
	void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
	}


    void FixedUpdate()
    {
        myRB.velocity = (transform.forward*movespeed);    
        if(
            (Mathf.Sqrt(Mathf.Pow(transform.position.x-thePlayer.transform.position.x,2)
            +
            Mathf.Pow(transform.position.y - thePlayer.transform.position.y,2)
                        ))>distance
          )
        {
            transform.Translate(Vector3.forward * Time.deltaTime *movespeed);
        }
      

        transform.LookAt(thePlayer.transform.position);
        Quaternion q;
        q = transform.rotation;
        q.x = 0;
        q.z = 0;
        transform.SetPositionAndRotation(transform.position, q);
    }

    // Update is called once per frame
    void Update ()
    {
       
        
	}
}
