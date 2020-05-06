using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muythicc : MonoBehaviour
{
    public GameObject missile1;
    public GameObject missile2;
    public GameObject missile3;
    public GameObject missile4;

    public GameObject cutsceneUI;
    public GameObject win;
    public bool CutsceneActivated;

    private float randomNumber = 0f;

    public float health = 2750f;


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
            win.SetActive(true);
        }
    }

    void Die()
    {
        randomNumber = 2f;
        FindObjectOfType<AudioManager>().Play("Noooo");
        missile1.SetActive(false);
        missile2.SetActive(false);
        missile3.SetActive(false);
        missile4.SetActive(false);
    }

    void Deactivate()
    {
        CutsceneActivated = false;
        cutsceneUI.SetActive(false);
        Debug.Log("CutsceneDeactivate");
        Time.timeScale = 1f;

        Destroy(gameObject);
    }

    void Activate()
    {
        cutsceneUI.SetActive(true);
        CutsceneActivated = true;
        Debug.Log("CutsceneActivate");
        Time.timeScale = 0f;
    }
}
