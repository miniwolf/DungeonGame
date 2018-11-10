using Components;
using UnityEngine;

namespace Actions
{
    public class RotateAroundTarget : MousePositionAction
    {
        private readonly ChaseCameraSettings chaseCameraSettings;
        private Vector3 rotation;
        private int mouseButton = 1; // Right button
        private Transform gameObjectTransform;

        public RotateAroundTarget(ChaseCameraSettings chaseCameraSettings)
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
            rotation.x = Mathf.Clamp(rotation.x, chaseCameraSettings.XMinAngle, chaseCameraSettings.XMaxAngle);
            gameObjectTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        }
    }
}