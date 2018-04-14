using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VariablesDeclaration
    CharacterController controller;    
    public float verticalVelocity;
    public float gravity;
    public float jumpForce;
    public float moveSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float bulletTimeStamp;
    #endregion
    #region FaceFollowCursorDeclaration
    private Vector3 worldpos;
    private float mouseX;
    private float mouseY;
    private float cameraDif;
    public Camera pivot;
    #endregion

    void Start()
    {
        pivot.enabled = false;
        cameraDif = pivot.transform.position.y - transform.position.y;
    }
    void LateUpdate()
    {
        controller = GetComponent<CharacterController>();

        #region Jumping
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        #endregion

        #region Movement
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
        movement.Normalize();

        controller.Move(movement * moveSpeed * Time.deltaTime);
        controller.Move(moveVector * Time.deltaTime);
        #endregion

        #region FaceFollowCursor
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        worldpos = pivot.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));
        Vector3 turretLookDirection = new Vector3(worldpos.x, transform.position.y, worldpos.z);
        transform.LookAt(turretLookDirection);
        #endregion

        #region Bullet
        if (bulletTimeStamp <= Time.time)
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
                bulletTimeStamp = Time.time + 0.5f;
            }
        #endregion
    }
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -10;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
