using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Animator animator;

    private bool isShoot = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2") && !Input.GetKey(KeyCode.E))
        {
            isShoot = !isShoot;
            animator.SetBool("Shoot", isShoot);
        }

        if (Input.GetButtonUp("Fire2") && !Input.GetKey(KeyCode.E))
        {
            isShoot = !isShoot;
            animator.SetBool("Shoot", isShoot);
        }

    }
}