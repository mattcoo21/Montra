using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    public static bool PlayerIsDead = false;

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
            Debug.Log("Dead...");
            Die();
        }
    }

    void Die()
    {
        deadMenuUI.SetActive(true);
        PlayerIsDead = true;
        Time.timeScale = 0f;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }
}
