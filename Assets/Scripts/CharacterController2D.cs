using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 20f;
    public float movementSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation to prevent unwanted rotation
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Handle player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveInput, 0f, 0f) * movementSpeed * Time.deltaTime;
        transform.position += movement;

        // Handle player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 0.1f; // Decreased raycast distance
        // Raycast to the floor objects only
        int mask = 1 << LayerMask.NameToLayer("Ground");

        // Raycast downwards
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, mask))
        {
            return true;
        }
        return false;
    }
}
