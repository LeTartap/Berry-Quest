using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    public float speed = 6.0F;
    public float gravity = 25.0F;
    public float gravityScale;
    public float verticalVelocity;
    private float jumpForce = 10.0F;
    //private Vector3 movement = Vector3.zero;//tbd

    public Animator anim;

    public GameObject bullet;


    private Vector3 worldpos;
    private float mouseX;
    private float mouseY;
    private float cameraDif;
    public Camera camera;

    public GameObject fpc;

    void Start()
    {
        //Cursor.visible = false;
        camera.enabled = false;
        cameraDif = camera.transform.position.y - fpc.transform.position.y;
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //Jump
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime *gravityScale;
            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;          
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime *gravityScale;
        }

        mouseX = Input.mousePosition.x;

        mouseY = Input.mousePosition.y;

        worldpos = camera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));

        Vector3 turretLookDirection = new Vector3(worldpos.x, fpc.transform.position.y, worldpos.z);

        fpc.transform.LookAt(turretLookDirection);

        //Movement

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
        movement.Normalize();
        //transform.rotation = Quaternion.LookRotation(movement);
                
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        controller.Move(moveVector * Time.deltaTime);

        

        // projectile
        if (Input.GetButtonDown("Fire1"))
        {
            bullet.transform.position=Vector3.Lerp(bullet.transform.position, new Vector3())
        }



        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        anim.SetBool("isGrounded", (controller.isGrounded));
        
    }
}