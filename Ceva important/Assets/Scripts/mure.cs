using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mure : MonoBehaviour {

    public murecounter script;
    public GameObject tufanud;

    bool destroyed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
       if(!destroyed)
        if (other.name == "Player")
        {
            script = other.GetComponent<murecounter>();
            script.countmure++;
                destroyed = true;
                Instantiate(tufanud,transform.position,transform.rotation);
                Destroy(this.gameObject);
        }

    }

}
