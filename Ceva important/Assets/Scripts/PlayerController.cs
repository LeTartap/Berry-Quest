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
        #endregion

        #region Animations

        #endregion
    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    
    
    
}
