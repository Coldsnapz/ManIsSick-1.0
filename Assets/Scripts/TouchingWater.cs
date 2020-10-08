using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

namespace Invector.vCharacterController
{
    public class TouchingWater : MonoBehaviour
    {
        [SerializeField] vThirdPersonMotor playerController;
        [SerializeField] float _inWaterSpeed = 0.75f;

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag("WaterTrigger"))
            {playerController.SpeedFactor = _inWaterSpeed;}
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("WaterTrigger"))
            {playerController.SpeedFactor = 1f;}
        }
    }
}
