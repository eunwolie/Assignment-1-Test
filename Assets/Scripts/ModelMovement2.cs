using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement2 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 one;
    Vector3 two;
    Vector3 three;
    Vector3 target;
    bool oneReached;
    bool twoReached;
 


    private bool calibrating = true;
    private Gyroscope gyro;

    private float initialYAngle;
    private float calibratedYAngle;
    private float appliedYAngle;

    Vector3 deviceEulerAngles;
    Vector3 transformEulerAngles;
    private AndroidJavaObject activityContext = null;
    private AndroidJavaObject jo = null;
    AndroidJavaClass activityClass = null;

    // Start is called before the first frame update

    void Start()
    {
        Application.targetFrameRate = 60;
        initialYAngle = transform.eulerAngles.y;
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody>();
        one = GameObject.Find("one").transform.position;
        Debug.Log("I'm one" + one);
        two = GameObject.Find("two").transform.position;
        Debug.Log("I'm two" + two);
        three = GameObject.Find("three").transform.position;
        Debug.Log("I'm three" + three);
        //Vector3 directionalVector1 = (one - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //animation bit
        if (((one.x - transform.position.x) > 0.1) && oneReached == false)
          {
              Debug.Log("I'm here" + transform.position);
              target = one;
                
          } else if (((two.x - transform.position.x) > 0.1) && twoReached == false)
          {
                oneReached = true;
                Debug.Log("I'm there" + transform.position);
                target = two;
          } else {
            oneReached = true;
            twoReached = true;
            Debug.Log("I'm wee" + transform.position);
            target = three;
        }

        if (calibrating)
        {
            DeltaYAngle();
            calibrating = false;
        }
        ApplyGyroRotation();
        ApplyRotation();


    }

    private void FixedUpdate()
    {
        rb.velocity = ((target - transform.position).normalized * speed);
    }

    public void DeltaYAngle()
    {
        calibratedYAngle = appliedYAngle - initialYAngle;
    }

    void ApplyGyroRotation()
    {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self);
        transform.Rotate(90f, 180f, 0f, Space.World);
        appliedYAngle = transform.eulerAngles.y;
    }

    void ApplyRotation()
    {
        transform.Rotate(0f, -calibratedYAngle, 0f, Space.World);
    }


}
