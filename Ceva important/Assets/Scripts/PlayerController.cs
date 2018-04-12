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
    public GunController theGun;
   // private Vector3 movement = Vector3.zero;

    //public Animator anim;

    void Start()
    {
        //Cursor.visible = false;
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

        //Movement
        
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
        movement.Normalize();
        //transform.rotation = Quaternion.LookRotation(movement);
                
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        controller.Move(moveVector * Time.deltaTime);
        
        //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        //Fire the gun
        if(Input.GetMouseButton(0))
        {
            theGun.isFiring = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }


    }
}