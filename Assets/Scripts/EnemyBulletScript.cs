using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    public float timer;

    public AudioClip clickSound;

    private AudioSource audioSource;

    //public PlayerHealth pHealth;

    //public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        audioSource = gameObject.AddComponent<AudioSource>();

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(clickSound);
        Debug.Log("Preparing to Destroy on collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Destroy on collision");
            Health.Instance.Damage(20);
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(clickSound);
        Debug.Log("Preparing to Destroy on Trigger");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Destroy on Trigger");
            Health.Instance.Damage(20);
            Destroy(gameObject);
        }

    }
}
