using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TinyBoss : MonoBehaviour
{
    public GameObject cutsceneUI;
    public bool CutsceneActivated;

    public float randomNumber = 0f;

    public float health = 500f;

    public GameObject goalWall;

    void Update()
    {
        if (randomNumber == 2f)
        {
            Activate();
            randomNumber = 3f;
        }

        if (randomNumber == 3f)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Deactivate();
            }
        }
    }

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
        randomNumber = 2f;
        FindObjectOfType<AudioManager>().Play("Noooo");
    }

    void Deactivate ()
    {
        CutsceneActivated = false;
        cutsceneUI.SetActive(false);
        Debug.Log("CutsceneDeactivate");
        Time.timeScale = 1f;

        Destroy(gameObject);
        Destroy(goalWall);
    }

    void Activate()
    {
        cutsceneUI.SetActive(true);
        CutsceneActivated = true;
        Debug.Log("CutsceneActivate");
        Time.timeScale = 0f;
    }
}

