using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THICCBOSS : MonoBehaviour
{
    public float lookRadius = 100f;

    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
