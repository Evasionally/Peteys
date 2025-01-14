using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Assingables
    public Transform playerCam;

    //Other
    private Rigidbody rb;

    //Rotation and look
    private float xRotation;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;
    public float rotationSpeed = 5f;
    
    //Movement
    public float moveSpeed = 4500;
    public float maxSpeed = 20;
    public bool grounded;
    public LayerMask whatIsGround;
    
    public float counterMovement = 0.175f;
    private float threshold = 0.01f;
    public float maxSlopeAngle = 35f;

    //Jumping
    private bool readyToJump = true;
    private float jumpCooldown = 0.25f;
    public float jumpForce = 550f;
    
    //Input
    float x, y;
    bool jumping, sprinting, crouching;
    
    //Sliding
    private Vector3 normalVector = Vector3.up;
    private Vector3 wallNormalVector;

    public bool frictionless;


    //Edit by Andy - Shelf Tilting script for Petey's collisions on a shelf
    ShelfTilting shelfTiltingScript;
    SinkSinking sinkSinkingScript;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Edit by Andy - find the Shelf Tilting Script
        shelfTiltingScript = FindObjectOfType<ShelfTilting>();
        sinkSinkingScript = FindObjectOfType<SinkSinking>();
    }

    private void FixedUpdate() {
        MyInput();
        Movement();
        if (!Input.GetMouseButton(1)) Look();
    }

    /// <summary>
    /// Find user input. 
    /// </summary>
    private void MyInput() {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButton("Jump");
    }

    private void Movement() {
        //Extra gravity
        rb.AddForce(Vector3.down * Time.deltaTime * 10);
        
        //Find actual velocity relative to where player is looking
        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        //Counteract sliding and sloppy movement
        if (!frictionless)
        {
            CounterMovement(x, y, mag);
        }
        
        //If holding jump && ready to jump, then jump
        if (readyToJump && jumping) Jump();

        //Set max speed
        float maxSpeed = this.maxSpeed;

        //If speed is larger than maxspeed, cancel out the input so you don't go over max speed
        if (x > 0 && xMag > maxSpeed) x = 0;
        if (x < 0 && xMag < -maxSpeed) x = 0;
        if (y > 0 && yMag > maxSpeed) y = 0;
        if (y < 0 && yMag < -maxSpeed) y = 0;

        //Some multipliers
        float multiplier = 1f, multiplierV = 1f;
        
        // Movement in air
        if (!grounded) {
            multiplier = 0.85f;
            multiplierV = 0.85f;
        }

        //Apply forces to move player
        Vector3 forward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z);
        Vector3 right = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z);

        Vector3 forwardForce = ScaleTo(forward, playerCam.forward.magnitude) * y * moveSpeed * Time.deltaTime * multiplier * multiplierV;
        Vector3 rightForce = ScaleTo(right, playerCam.right.magnitude) * x * moveSpeed * Time.deltaTime * multiplier;
        
        rb.AddForce(forwardForce);
        rb.AddForce(rightForce);
    }

    /// <summary>
    /// Scales a vector by a given value.
    /// </summary>
    /// <param name="toExtend">Vector to be scaled.</param>
    /// <param name="amount">The amount to scale by.</param>
    /// <returns>A newly scaled vector.</returns>
    private Vector3 ScaleTo(Vector3 toExtend, float amount)
    {
        toExtend.Normalize();
        return new Vector3(toExtend.x * amount, toExtend.y * amount, toExtend.z * amount);
    }

    private void Jump() {
        if (grounded && readyToJump) {
            readyToJump = false;

            //Add jump forces
            rb.AddForce(Vector2.up * jumpForce * 1.5f);
            rb.AddForce(normalVector * jumpForce * 0.5f);
            
            //If jumping while falling, reset y velocity.
            Vector3 vel = rb.velocity;
            if (rb.velocity.y < 0.5f)
                rb.velocity = new Vector3(vel.x, 0, vel.z);
            else if (rb.velocity.y > 0) 
                rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    public void StopMomentum()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    
    private void ResetJump() {
        readyToJump = true;
    }
    
    private float desiredX;
    private void Look()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = (float)Math.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void CounterMovement(float x, float y, Vector2 mag) {
        if (!grounded || jumping) return;

        //Counter movement
        if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0)) {
            rb.AddForce(moveSpeed * playerCam.transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0)) {
            rb.AddForce(moveSpeed * playerCam.transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }
        
        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed) {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }

    /// <summary>
    /// Find the velocity relative to where the player is looking
    /// Useful for vectors calculations regarding movement and limiting movement
    /// </summary>
    /// <returns></returns>
    public Vector2 FindVelRelativeToLook() {
        float lookAngle = playerCam.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);
        
        return new Vector2(xMag, yMag);
    }

    private bool IsFloor(Vector3 v) {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < maxSlopeAngle;
    }

    private bool cancellingGrounded;
    
    /// <summary>
    /// Handle ground detection
    /// </summary>
    private void OnCollisionStay(Collision other) {
        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
        if (whatIsGround != (whatIsGround | (1 << layer))) return;

        //Iterate through every collision in a physics update
        for (int i = 0; i < other.contactCount; i++) {
            Vector3 normal = other.contacts[i].normal;
            //FLOOR
            if (IsFloor(normal)) {
                grounded = true;
                cancellingGrounded = false;
                normalVector = normal;
                CancelInvoke(nameof(StopGrounded));
            }
        }

        //Invoke ground/wall cancel, since we can't check normals with CollisionExit
        float delay = 3f;
        if (!cancellingGrounded) {
            cancellingGrounded = true;
            Invoke(nameof(StopGrounded), Time.deltaTime * delay);
        }
    }

    private void StopGrounded() {
        grounded = false;
    }


    //Edit by Andy - collision things for when Petey steps on a tilting shelf, hot stove, etc
    private void OnCollisionEnter(Collision collision)
    {
        //If Petey steps on the tilting shelf
        if(collision.gameObject.tag == "tiltingShelf")
        {
            Debug.Log("Petey is on the shelf");
            
            collision.gameObject.GetComponent<ShelfTilting>().PeteyOnShelf();
        }

        //If Petey hops on top of a PETEY button
        if(collision.gameObject.tag == "ButtonSticker")
        {
            //Send what letter that button represents to the proper script
            collision.gameObject.GetComponent<ButtonLetter>().ButtonClicked();
        }     

        if(collision.gameObject.tag == "SpeedBoost")
        {
            moveSpeed = 9000;
            maxSpeed = 45;
        }   
    }
    private void OnCollisionExit(Collision collision)
    {
        //If Petey steps off the tilting shelf
        if(collision.gameObject.tag == "tiltingShelf")
        {
            //Send what letter that button represents to the proper script
            collision.gameObject.GetComponent<ShelfTilting>().PeteyOnShelf();
        }

        if(collision.gameObject.tag == "SpeedBoost")
        {
            moveSpeed = 3750;
            maxSpeed = 16;
        }   
    }
    
}