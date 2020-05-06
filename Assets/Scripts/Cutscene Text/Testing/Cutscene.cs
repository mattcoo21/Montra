using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject cutsceneUI;
    public bool CutsceneActivated;

    // Update is called once per frame
    void Update()
    {
        if (CutsceneActivated == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CutsceneActivated = false;
                cutsceneUI.SetActive(false);
                Debug.Log("CutsceneDeactivate");
                Time.timeScale = 1f;
                Destroy(gameObject);

            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "Gfx")
        {
            //Touches cube, activates cutscene
            cutsceneUI.SetActive(true);
            CutsceneActivated = true;
            Debug.Log("CutsceneActivate");
            Time.timeScale = 0f;
        }
    }
}
