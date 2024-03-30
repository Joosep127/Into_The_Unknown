using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 velocity;
    private BoxCollider2D boxCollider;
    public bool grounded;
    public bool wall_r;
    public bool wall_l;

    public float groundDeceleration;
    public float airAcceleration;
    public float walkAcceleration;
    public float jumpHeight = 20f;
    public float movementSpeed = 5f;
    public float distanceDown = 0.6f;
    public float distanceRight = 0.6f;
    public float distanceLeft = 0.6f;
    public LayerMask collisionLayers;

    public bool DisableGrounded;
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
        if (Ground_Check.collider != null && !DisableGrounded) {
            return true;
        } 
        return false;
    }

    public bool is_wall_right() {
        Vector2 player_pos = transform.position;
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.right, distanceRight, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }
    public bool is_wall_left() {
        Vector2 player_pos = transform.position;
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.left, distanceLeft, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }


    private void Update()
    {
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        wall_r = is_wall_right();
        wall_l = is_wall_left();

        transform.Translate(velocity * Time.deltaTime);
        float moveInput = Input.GetAxisRaw("Horizontal");


        
        if ((moveInput > 0 && !wall_r) || (moveInput < 0 && !wall_l)){
            velocity.x = Mathf.MoveTowards(velocity.x, movementSpeed * moveInput, acceleration * Time.deltaTime);
        }
        else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        if (!((velocity.x > 0 && !wall_r) || (velocity.x < 0 && !wall_l))) {
            velocity.x = 0;
        }
        
        if(Input.GetKeyDown(KeyCode.X))
        {
            Health.Instance.Damage(.1f);
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
    }    
}
