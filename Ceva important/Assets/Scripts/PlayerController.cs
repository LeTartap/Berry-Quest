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
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float bulletTimeStamp;
    public Animator anim;
    public Animation animation;
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

        #region Bullet
        if (bulletTimeStamp <= Time.time)
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
                bulletTimeStamp = Time.time + 0.5f;
            }
        #endregion

        #region Animations

        #endregion
    }
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    
    void Fire()
    {
        //Create the Bullet from the Bullet Prefab
       var bullet = (GameObject)Instantiate(
           bulletPrefab,
           bulletSpawn.position,
           bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -10;
        
        // Destroy the bullet after 3 seconds
        Destroy(bullet, 3.0f);
    }
    
}
