using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEFINISHED : MonoBehaviour
{
    public static bool GameIsWon = false;

    public GameObject cutsceneUI;

    void Update()
    {
        if (GameIsWon)
        {
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
            //Touches cube, activates cutscene
            cutsceneUI.SetActive(true);
            Debug.Log("CutsceneActivate");
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
