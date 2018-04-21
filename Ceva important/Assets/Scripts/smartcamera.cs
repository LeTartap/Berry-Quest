using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCamera : MonoBehaviour {

    //private float height;
    public float speed;
    public bool coliding = false;

	// Use this for initialization
	void Start ()
    {
        //height = transform.position.y;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

  
    private void OnTriggerEnter ()
    {
        coliding = true;
        Vector3 vect= transform.position;
        vect.y += speed * Time.deltaTime;
        transform.position = vect;
    }

}
