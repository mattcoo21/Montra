using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    public Animator animator;

    private bool isShoot = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !Input.GetKey(KeyCode.Q))
        {
            isShoot = !isShoot;
            animator.SetBool("Shoot2", isShoot);
        }

        if (Input.GetButtonUp("Fire1") && !Input.GetKey(KeyCode.Q))
        {
            isShoot = !isShoot;
            animator.SetBool("Shoot2", isShoot);
        }

    }
}
