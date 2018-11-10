using Components;
using UnityEngine;

namespace Cameras
{
    public class CameraSystem : ActionableEntityImpl<CameraActions>,
        ZoomSettings,
        ChaseCameraSettings
    {
        void Update()
        {
            ExecuteAction(CameraActions.FollowPlayer);
        }

        public override string Tag { get; } = "PlayerCamera";

        public float zoomSpeed = 2;
        public float zoomMin = -10f;
        public float zoomMax = -2f;
        public float zoomValue;
        public Transform target;
        public Vector3 offset;
        private float rotationSpeed = 2;
        private float xMinAngle = -40;
        private float xMaxAngle = 80;

        public float ZoomSpeed { get => zoomSpeed; set => zoomSpeed = value; }
        public float ZoomMin { get => zoomMin; set => zoomMin = value; }
        public float ZoomMax { get => zoomMax; set => zoomMax = value; }
        public float ZoomValue { get => zoomValue; set => zoomValue = value; }
        public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
        public float XMinAngle { get => xMinAngle; set => xMinAngle = value; }
        public float XMaxAngle { get => xMaxAngle; set => xMaxAngle = value; }
        public Transform Target { get => target; set => target = value; }
        public Vector3 Offset { get => offset; set => offset = value; }
    }

    public enum CameraActions
    {
        FollowPlayer
    }
}