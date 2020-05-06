using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public float health = 10f;
    public GameObject explosionEffect;
    bool hasExploded = false;

   [SerializeField] private Transform player;
   [SerializeField] private float force;
   [SerializeField] private float rotationForce;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = player.position - rb.position;
            direction.Normalize();
            Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
            rb.angularVelocity = rotationAmount * rotationForce;
            rb.velocity = transform.forward * force;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "Gfx")
        {
            Explode();
        }

        if (col.gameObject.name != "THICC BOSS")
        {
            Explode();
        }
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {

        //Show Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("exploded");
        //Destroy  barrel
        Destroy(gameObject);

        GameObject explosionGO = Instantiate(explosionEffect);
        Destroy(explosionGO, 2f);

        FindObjectOfType<AudioManager>().Play("Explosion");
    }
}
