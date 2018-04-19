using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growmure : MonoBehaviour {

    public float mintime=0;
    public float maxtime = 0;
    public GameObject tufa;
    float time;
    bool tufanuddestroyed = false;

	// Use this for initialization
	void Start ()
    {
        time = Random.Range(mintime, maxtime);
        time += Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Time.time > time)
        {

            if (!tufanuddestroyed)
            {
                Instantiate(tufa,transform.position,transform.rotation);

                Destroy(this.gameObject);
            }
            tufanuddestroyed = true;
        }

        
	}
}
