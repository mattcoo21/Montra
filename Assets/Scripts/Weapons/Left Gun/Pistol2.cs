using UnityEngine;
using System.Collections;

public class Pistol2 : MonoBehaviour
{

    public Animator animator;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 40f;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;

    private bool isOut = false;
    private bool isAway = false;
    private bool isInspecting = false;
    private bool isCrouching = false;
    private bool isPaused = false;

    private bool shoot = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot = false;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            shoot = true;
        }

        if (isOut == true && !Input.GetKey(KeyCode.Q))
        {
            shoot = true;
        }



        //Switching Gun
        if (Input.GetKeyDown(KeyCode.X))
        {
            shoot = true;
            GunOut();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            GunAway();
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //Inspect
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inspect();
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            Inspect();
        }

        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Crouch();
        }

        //Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    //Pause
    void Pause()
    {
        isPaused = !isPaused;
    }

    //Crouch
    void Crouch()
    {
        isCrouching = !isCrouching;
        animator.SetBool("Crouch", isCrouching);
    }


    //Inspect
    void Inspect()
    {
        isInspecting = !isInspecting;
        animator.SetBool("Inspect", isInspecting);
    }


    //WhipitOut
    void GunOut()
    {
        isOut = !isOut;
        animator.SetBool("Out", isOut);
    }

    void GunAway()
    {
        isAway = !isAway;
        animator.SetBool("Away", !isAway);
    }

    //Shoot
    void Shoot()
    {
        if (isPaused == false)
        {
            if (isOut == true)
            {
                if (shoot == true)
                {
                    FindObjectOfType<AudioManager>().Play("Gun");
                    muzzleflash.Play();

                    RaycastHit hit;
                    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                    {
                        Debug.Log(hit.transform.name);

                        //Enemies
                        Target target = hit.transform.GetComponent<Target>();
                        if (target != null)
                        {
                            target.TakeDamage(damage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }

                        //Windows
                        WindowBreak2 target2 = hit.transform.GetComponent<WindowBreak2>();
                        if (target2 != null)
                        {
                            target2.TakeDamage(damage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }

                        //Cameras
                        CameraBreak target3 = hit.transform.GetComponent<CameraBreak>();
                        if (target3 != null)
                        {
                            target3.TakeDamage(damage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }

                        //Vents
                        VentBreak target4 = hit.transform.GetComponent<VentBreak>();
                        if (target4 != null)
                        {
                            target4.TakeDamage(damage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }

                        //Explosive Barrels
                        HomingProjectile target5 = hit.transform.GetComponent<HomingProjectile>();

                        if (target5 != null)
                        {
                            target5.TakeDamage(damage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }


                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, 2f);
                    }
                }
            }
        }
    }

}
