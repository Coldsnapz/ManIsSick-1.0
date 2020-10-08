using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTopResistance : MonoBehaviour
{
    public Rigidbody _Rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player") 
        {
        _Rigidbody.isKinematic = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player") 
        {
        _Rigidbody.isKinematic = false;
        }
    }
}
