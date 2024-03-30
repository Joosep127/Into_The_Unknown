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
    private float explosionRadius;
    [SerializeField] private float addTorqueAmountInDegrees;
    [SerializeField] private CircleCollider2D circleCollider;


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();
        SetStraightVelocity();
        explosionRadius = circleCollider.radius;
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
                Debug.Log("Found component " + rigid.name);
                rigid.AddTorque(addTorqueAmountInDegrees * Mathf.Deg2Rad * rigid.inertia);
            }
        }

        Destroy(toRemove, .5f);
    }
}
