using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 velocity;
    private BoxCollider2D boxCollider;
    public bool grounded;
    public bool wall;

    public float groundDeceleration;
    public float airAcceleration;
    public float walkAcceleration;
    public float jumpHeight = 20f;
    public float movementSpeed = 5f;
    public float distanceDown = 0.6f;
    public LayerMask collisionLayers;
    private Rigidbody2D rb;
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        velocity = Vector2.zero;
    }

    public bool is_ground() {
        Vector2 player_pos = transform.position;
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.down, distanceDown, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }
    private void Update()
    {
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        transform.Translate(velocity * Time.deltaTime);
        float moveInput = Input.GetAxisRaw("Horizontal");
velocity.x = Mathf.MoveTowards(velocity.x, movementSpeed * moveInput, walkAcceleration * Time.deltaTime);

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementSpeed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }


        grounded = is_ground();

        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = Vector2.up * jumpHeight;
                }
        }
        else {
            velocity.y += Physics2D.gravity.y * Time.deltaTime;
        }
    }

    
}
