using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject missile1;
    public GameObject missile2;
    public GameObject missile3;
    public GameObject missile4;
    public GameObject wall;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "Gfx")
        {
            //Touches cube, activates cutscene
            missile1.SetActive(true);
            missile2.SetActive(true);
            missile3.SetActive(true);
            missile4.SetActive(true);
            boss.SetActive(true);
            wall.SetActive(true);
            Debug.Log("Spawn Boss...");
            FindObjectOfType<AudioManager>().Play("EvilLaugh");
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }
}
