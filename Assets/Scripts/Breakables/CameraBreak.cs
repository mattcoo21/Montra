using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBreak : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float health = 10f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("hit detected");
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}