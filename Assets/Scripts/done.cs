using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class done : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered The Trigger");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is Within Trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Exited The Trigger");
    }
}
