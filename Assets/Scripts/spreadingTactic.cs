using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreadingTactic : MonoBehaviour
{
    void Update(){
        if (!this.GetComponent<ParticleSystem>().IsAlive())
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (this.GetComponent<ParticleSystem>().IsAlive())
        {
            if (other.GetComponent<infectableObject>() != null)
            {
                other.GetComponent<infectableObject>().Infected();
            }
        }
    }
}
