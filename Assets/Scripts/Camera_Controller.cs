using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private GameObject player;
    private Vector2 velocity;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    
    public LayerMask collisionLayers;
    public float distanceLat;
    public float distanceSide;


    public bool is_wall_right() {
        Vector2 player_pos = transform.position;
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.right, distanceSide, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }
    public bool is_wall_left() {
        Vector2 player_pos = transform.position;
        Debug.DrawRay(player_pos, Vector2.left * distanceSide, Color.green);
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.left, distanceSide, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }

    public bool is_wall_up() {
        Vector2 player_pos = transform.position;
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.up, distanceLat, collisionLayers);     
        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }
    public bool is_wall_down() {
        Vector2 player_pos = transform.position;
        Debug.DrawRay(player_pos, Vector2.down * distanceLat, Color.green);
        RaycastHit2D Ground_Check = Physics2D.Raycast(player_pos, Vector2.down, distanceLat, collisionLayers);     

        if (Ground_Check.collider != null) {
            return true;
        } 
        return false;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        velocity = Vector2.zero;
    }


    void Update()
    {
        Debug.Log(is_wall_left());
        velocity = (player.transform.position + new Vector3(0,2,0) - transform.position)*10;
        Debug.Log(velocity.x);
        if (is_wall_right() && velocity.x > 0){
            velocity.x = 0;
        }
        if (is_wall_left() && velocity.x < 0){
            velocity.x = 0;
        }

        if (is_wall_up() && velocity.y > 0){
            velocity.y = 0;
        }
        if (is_wall_down() && velocity.y < 0){
            velocity.y = 0;
        }
        transform.Translate(velocity * Time.deltaTime);
    }
}
