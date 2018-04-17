using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCamera : MonoBehaviour {

    float height;
    public float speed;
    public float maxrise;
    public bool colliding = false;
    public Rigidbody rb;
    bool added;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        height = transform.position.y;
        maxrise += height;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
           

        if(transform.position.y<height)
        {
            Vector3 a = transform.position;
            a.y = height;
            transform.position = a;
        }
        else
        {   
            rb.AddForce(0, -speed * Time.deltaTime, 0); 
        }

        if (transform.position.y > maxrise)
        {
            Vector3 a = transform.position;
            a.y = maxrise;
            transform.position = a;
        }



    }


    private void OnTriggerStay()
    {
        //if (added)
       // {
            rb.AddForce(0, 2 * speed * Time.deltaTime, 0);
        Debug.Log("lol");
        //}

        // Vector3 vect= transform.position;
        // vect.y += speed * Time.deltaTime;
        // transform.SetPositionAndRotation(vect, transform.rotation);
    }

}
