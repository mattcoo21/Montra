using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    public GameObject destroyedVersion;

     void OnTriggerEnter(Collider player)

    {
        if (player.gameObject.name == "Gfx")
        {
            FindObjectOfType<AudioManager>().Play("WindowBreak");
            Debug.Log("hit detected");
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }


}
