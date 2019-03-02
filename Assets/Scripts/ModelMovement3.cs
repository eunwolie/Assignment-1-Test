using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement3 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 one;
    Vector3 target;
    bool oneReached;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        one = GameObject.Find("one").transform.position;
        Debug.Log("I'm one" + one);
    }

    // Update is called once per frame
    void Update()
    {
        if (((one - transform.position).magnitude > 0.2) && oneReached == false)
        {
            //Debug.Log("I'm here" + transform.position);
            target = one;

        } else
        {
            oneReached = true; 
        }
    }

    private void FixedUpdate()
    {
        if (oneReached == false)
        {
            rb.velocity = ((target - transform.position).normalized * speed);
        } else
        {
            rb.velocity = ((transform.forward).normalized * speed);
        }

    }
}
