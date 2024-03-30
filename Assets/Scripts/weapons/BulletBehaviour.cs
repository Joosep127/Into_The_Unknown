using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private Object impactEffect;
    private Animator animator;



    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        animator.Play("Explosion");

        SetDestroyTime();
        SetStraightVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            Debug.Log("Explosion!!");
            // Particles
            // SFX
            // Screenshake
            // Explosion
            animator.Play("Explosion");
            //animator.;
            Object toRemove = Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(toRemove, .5f);
            Destroy(gameObject);
        }
    }
    private void SetStraightVelocity ()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void SetDestroyTime ()
    {
        //animator.Play("Explosion");

        Destroy(gameObject, destroyTime);
    }

    private void OnDestroy()
    {
        animator.Play("Explosion");
    }
}
