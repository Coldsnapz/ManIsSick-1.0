using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingKillZone : MonoBehaviour
{
    public Transform _teleportTo;
    Rigidbody _RigidBody;
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="KillZone") 
        {
            if (gameObject.tag != "Player"){
                _RigidBody.isKinematic = true;
            }
            transform.position = _teleportTo.transform.position;
            transform.rotation = _teleportTo.transform.rotation;
            if (gameObject.tag != "Player"){
                _RigidBody.isKinematic = false;
            }
            _RigidBody.AddForce(new Vector3(0,500,0), ForceMode.Impulse);
            //Debug.Log("I work correctly");
        }
    }

    public Transform TeleportTo
    {
        get {return _teleportTo; }
        set {_teleportTo = value; }
    }
}
