using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VariablesDeclaration     
    public float verticalVelocity = 10.0f;
    public float gravity = 20.0f;
    public float jumpForce = 5.0f;
    public float moveSpeed = 6.0f;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    public Animator anim;
    #endregion

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }
    void LateUpdate()
    {
        #region Movement + FaceFollowCursor
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        Quaternion rot = transform.rotation;
        Vector3 v = rot.ToEulerAngles();
        UpdateAnimation(moveInput, v);
        #endregion
    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    #region Animations    
    void UpdateAnimation(Vector3 dir, Vector3 rotation)
    {
        if (dir.x == 0f && dir.z == 0f)
        {
            //Idle Animation
            anim.SetBool("Movement", false);
        }
        else
        {
            anim.SetBool("Movement", true);
        }
        if (rotation.y >= -57 && rotation.y <= 57)//North
        {
            anim.SetFloat("North", 1f);
            anim.SetFloat("Est", 0f);
            anim.SetFloat("South", 0f);
            anim.SetFloat("West", 0f);
            anim.SetFloat("DirX", dir.x);
            anim.SetFloat("DirZ", dir.z);
        }
        else if (rotation.y >= 57 && rotation.y <= 123)//Est
        {
            anim.SetFloat("North", 0f);
            anim.SetFloat("Est", 1f);
            anim.SetFloat("South", 0f);
            anim.SetFloat("West", 0f);
            anim.SetFloat("DirX", dir.x);
            anim.SetFloat("DirZ", dir.z);
        }
        else if (rotation.y >= -123 && rotation.y <= 123)//South
        {
            anim.SetFloat("North", 0f);
            anim.SetFloat("Est", 0f);
            anim.SetFloat("South", 1f);
            anim.SetFloat("West", 0f);
            anim.SetFloat("DirX", dir.x);
            anim.SetFloat("DirZ", dir.z);
        }
        else //West
        {
            anim.SetFloat("North", 0f);
            anim.SetFloat("Est", 0f);
            anim.SetFloat("South", 0f);
            anim.SetFloat("West", 1f);
            anim.SetFloat("DirX", dir.x);
            anim.SetFloat("DirZ", dir.z);
        }

    }
    #endregion
}
