using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
[RequireComponent(typeof(Canvas))]

public class AlwaysFacingCamera : MonoBehaviour 
{
    public Camera _camera;
    public void Start()
    {
        if(_camera ==null)
        {
            _camera = Camera.main;
        }
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = _camera;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}