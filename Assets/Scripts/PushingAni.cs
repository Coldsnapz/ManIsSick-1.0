using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using Invector.vCharacterController;

public class PushingAni : MonoBehaviour
{  
    GameObject _player;
    Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        animator = _player.GetComponent<Animator>();
        if (other.tag =="Player") 
        {
        animator.SetFloat("isPushing", 1);
        animator.SetFloat("MoveSet_ID", 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player") 
        {
        vThirdPersonController controller = _player.GetComponent<vThirdPersonController>();
        controller.isCrouching = false;
        animator.SetFloat("isPushing", 0);
        animator.SetFloat("MoveSet_ID", 0);
        }
    }
}
