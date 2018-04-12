using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour {

    private Vector3 worldpos;
    private float mouseX;
    private float mouseY;
    private float cameraDif;
    public Camera camera;

    public GameObject fpc;

    // Use this for initialization
    void Start () {
        camera.enabled = false;
        cameraDif = camera.transform.position.y - fpc.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        mouseX = Input.mousePosition.x;

        mouseY = Input.mousePosition.y;

        worldpos = camera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));

        Vector3 turretLookDirection = new Vector3(worldpos.x, fpc.transform.position.y, worldpos.z);

        fpc.transform.LookAt(turretLookDirection);

    }
}
