using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileDamage : MonoBehaviour
{
    public static bool PlayerIsDead = false;
    private float PlayerHealth = 1;

    public GameObject deadMenuUI;

    void Update()
    {
        if (PlayerIsDead == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1f;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Menu();
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "Gfx")
        {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");

            Debug.Log("Damage...");
            Damage();
        }
    }

    void Damage()
    {
        PlayerHealth = PlayerHealth - 1;

        if (PlayerHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            deadMenuUI.SetActive(true);
            PlayerIsDead = true;
            Time.timeScale = 0f;
        }
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }
}
