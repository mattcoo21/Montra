using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBreak : MonoBehaviour
{
    public GameObject destroyedVersion;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "Gfx")
        {
            Debug.Log("hit detected");
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("DoorBreak");
            Destroy(gameObject);


        }
    }
}
