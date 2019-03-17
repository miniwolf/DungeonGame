using Components;
using UnityEngine;

namespace Actions
{
    public class RotateAroundWithTarget : MousePositionAction
    {
        private readonly ChaseCameraSettings chaseCameraSettings;
        private Vector3 rotation;
        private Vector3 targetRotation;
        private int mouseButton = 1; // Right button
        private Transform gameObjectTransform;

        public RotateAroundWithTarget(ChaseCameraSettings chaseCameraSettings)
        {
            this.chaseCameraSettings = chaseCameraSettings;
        }

        public void Setup(GameObject gameObject)
        {
            rotation = gameObject.transform.eulerAngles;
            gameObjectTransform = gameObject.transform;
        }

        public void Execute(float mouseX, float mouseY)
        {
            if (!Input.GetMouseButton(mouseButton))
            {
                return;
            }

            rotation.y += mouseX * chaseCameraSettings.RotationSpeed;
            rotation.x -= mouseY * chaseCameraSettings.RotationSpeed;
            rotation.x = Mathf.Clamp(rotation.x,
                chaseCameraSettings.XMinAngle,
                chaseCameraSettings.XMaxAngle);

            gameObjectTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);

            targetRotation.y = rotation.y;
            chaseCameraSettings.Target.transform.rotation =
                Quaternion.Euler(targetRotation.x, targetRotation.y, 0);
        }
    }
}