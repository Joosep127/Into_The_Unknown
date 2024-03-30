using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float addTorqueAmountInDegrees;
    [SerializeField] private float explosionForce = 10f;
    [SerializeField] public GameObject player;

    private Rigidbody2D rb;
    private Rigidbody2D rb2;

    public float sidemod;
    public float upmod;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb2 = player.GetComponent<Rigidbody2D>();

        SetDestroyTime();
        SetStraightVelocity();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            // Particles
            // SFX
            // Screenshake
            // Explosion knockback
            Destroy(gameObject);
        }
    }
    private void SetStraightVelocity ()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void SetDestroyTime ()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnDestroy()
    {
        Explode();
    }

    private void Explode ()
    {
        GameObject toRemove = Instantiate(impactEffect, transform.position, transform.rotation);
        toRemove.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody2D rigid = colliders[i].GetComponent<Rigidbody2D>();
            if (rigid != null)
            {

                AddExplosionForce(explosionForce, transform.position, explosionRadius);

                //rigid.AddTorque(addTorqueAmountInDegrees * Mathf.Deg2Rad * rigid.inertia);
            }
        }

        Destroy(toRemove, .5f);
    }

    public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {

        var explosionDir = player.transform.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0) {
            explosionDir /= explosionDistance;
        }
        else
        {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
        }
        explosionDir *= -1;
        // //explosionDir.Normalize();
        // rb2 = player.GetComponent<Rigidbody2D>();
        // rb2.AddForce(Mathf.Lerp(0, explosionForce, (1.5f - explosionDistance)) * explosionDir, mode);
        PlayerController playerScript = player.GetComponent<PlayerController>();
        
        //playerScript.DisableGrounded = true;
        //playerScript.grounded = false;
        rb2.velocity = Vector2.up * explosionDir.y * explosionForce * -1 / 10 * upmod;
        playerScript.velocity = explosionForce * (1 - explosionDistance) * Vector2.right * explosionDir.x * sidemod;
        //playerScript.DisableGrounded = false;
    }


}
