using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{
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
        #if UNITY_ANDROID
        activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

        jo = new AndroidJavaObject("com.etiennefrank.lightsensorlib.LightSensorLib");
        jo.Call("init", activityContext);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrating)
        {
            DeltaYAngle();
            calibrating = false;
        }
        ApplyGyroRotation();
        ApplyRotation();
        
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

    public float getLux()
    {
    #if UNITY_ANDROID
        return jo.Call<float>("getLux");
    #endif
    }
}
