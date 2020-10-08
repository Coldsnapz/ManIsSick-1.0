using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectableObject : MonoBehaviour
{
    private bool _isInfected = false;

    public bool IsInfected
    {
        get { return _isInfected; }
        set { _isInfected = value; }
    }

    public void Infected()
    {
        if (!_isInfected){
        this.GetComponent<ParticleSystem>().Play(); 
        Debug.Log(this.name + " is now infected!");
        _isInfected = true;
        }
    }

    public void Cure()
    {
        if (_isInfected){
        this.GetComponent<ParticleSystem>().Stop();
        Debug.Log(this.name + " is now cured!");
        _isInfected = false;
        }
    }
}
