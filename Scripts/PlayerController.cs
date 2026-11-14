using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private float speedMultiplier = 1f;
    private float minX = -8f;
    private float maxX = 8f;
    private float minY = -4f;
    private float maxY = 4f;
    public CameraPostProcessing cameraEffects;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints =  RigidbodyConstraints2D.FreezeRotation ;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
      verticalInput = Input.GetAxisRaw("Vertical");
    } 
     void FixedUpdate()
    {
        Vector2 movement = new Vector2(
            horizontalInput,
            verticalInput
        ).normalized;

        Vector2 newPosition = rb.position +
        movement * moveSpeed * speedMultiplier * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        rb.MovePosition(newPosition);

}

  public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }
    //This allows another script to increase or reset the bunny's speed.
}