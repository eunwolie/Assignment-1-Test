using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    Vector3 One;
    Vector3 Two;
    public float speed;
    Vector3 targetVelocity;
    Vector3 targetVelocity2;
    public float finalMag; 

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        One = GameObject.Find("one").transform.position;
        Vector3 dir = (One - transform.position).normalized * speed;
        finalMag = Mathf.Infinity;
        targetVelocity = dir;
        Two = GameObject.Find("two").transform.position;
        Vector3 dir2 = (Two - transform.position).normalized * speed;
        targetVelocity2 = dir2;
    }

    private void Update()
    {
        float mag = (One - transform.position).sqrMagnitude;
        if(mag > finalMag)
        {
            targetVelocity = Vector3.zero;
        }
        finalMag = mag;
    }

    void FixedUpdate()
    {
        rb.velocity = targetVelocity;
    }
}
