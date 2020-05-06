using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public static bool PlayerWon = false;

    public GameObject winMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PlayerWon == true)
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
            Debug.Log("Won...");
            Won();
        }
    }

    void Won()
    {
        winMenuUI.SetActive(true);
        PlayerWon = true;
        Time.timeScale = 0f;
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }
}
