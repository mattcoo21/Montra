using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject wall;
    public GameObject upgrade;
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
                Destroy(upgrade);
                Destroy(wall);

            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "upgrade")
        {
            Debug.Log("Upgrade...");
            Upgrades();
        }
    }

    void Upgrades()
    {
        FindObjectOfType<AudioManager>().Play("Upgrade");
        Time.timeScale = 0f;
        CutsceneActivated = true;
        cutsceneUI.SetActive(true);
    }
}
