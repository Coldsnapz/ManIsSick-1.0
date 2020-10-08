using UnityEngine;
using System.Collections;
namespace Invector.vCharacterController.v2_5D
{
    using vShooter;
    [vClassHeader("Shooter 2.5D Input")]
    public class v2_5DShooterInput : vShooterMeleeInput
    {
        [vEditorToolbar("2D Aiming")]
        public bool lookToCursorOnAiming = true;

        private v2_5DController _controller;
        RaycastHit hitTarget;
        public v2_5DController controller
        {
            get
            {
                if (cc && cc is v2_5DController && _controller == null) _controller = cc as v2_5DController;
                return _controller;
            }
        }

      
        protected override bool IsAimAlignWithForward()
        {
            return true;
        }

        protected override void UpdateAimPosition()
        {
            if (!_isAiming || !controller) return;

            if (lookToCursorOnAiming) UpdateAimPositionFromCursor();
            else UpdateAimPositionFromForward();
          
        }

        protected virtual void UpdateAimPositionFromCursor()
        {
            Vector3 localPos = controller.localCursorPosition;
            if (Physics.Raycast(cameraMain.transform.position, (controller.worldCursorPosition - cameraMain.transform.position).normalized, out hitTarget, 100f, shooterManager.damageLayer))
                localPos = transform.InverseTransformPoint(hitTarget.point);

            localPos.y = 0;
            Vector3 wordPos = transform.TransformPoint(localPos);
            Vector3 lookDirection = (wordPos - aimAngleReference.transform.position);
            lookDirection = lookDirection.normalized * (lookDirection.magnitude < 2f ? 2f : lookDirection.magnitude);

            wordPos = transform.TransformPoint(localPos);
            aimPosition = aimAngleReference.transform.position + lookDirection;
            headTrack.SetTemporaryLookPoint(wordPos, 0.1f);
        }

        protected virtual void UpdateAimPositionFromForward()
        {
            aimPosition = aimAngleReference.gameObject.transform.position + transform.forward * 100f;
        }
        protected override void UpdateAimHud()
        {
            if (!shooterManager || !controlAimCanvas) return;
            if (CurrentActiveWeapon == null) return;
            controlAimCanvas.SetAimCanvasID(CurrentActiveWeapon.scopeID);           
            if (_isAiming) controlAimCanvas.SetWordPosition(controller.worldCursorPosition, aimConditions);           
            else  controlAimCanvas.SetAimToCenter(true);
          
        }
        
        protected override Vector3 targetArmAligmentDirection
        {
            get
            {
                return transform.forward;
            }
        }

        public override void ScopeViewInput()
        {
            ///Ignore ScopeView
        }
    }
}