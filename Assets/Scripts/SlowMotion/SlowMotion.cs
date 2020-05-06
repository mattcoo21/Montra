using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public static bool IsSlowed = false;

    public GameObject SlowMoUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Slow();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            Normal();
        }

    }

    void Normal()
    {
        Time.timeScale = 1;
        IsSlowed = false;
        SlowMoUI.SetActive(false);
    }

    void Slow()
    {
        FindObjectOfType<AudioManager>().Play("Slow");
        Time.timeScale = 0.3f;
        IsSlowed = true;
        SlowMoUI.SetActive(true);
    }

}
