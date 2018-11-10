using Components;
using UnityEngine;

namespace Actions
{
    public class StayOnTarget : NonAction
    {
        private readonly ChaseCameraSettings chaseCameraSettings;
        private readonly ZoomSettings zoomSettings;
        private Transform transform;

        public StayOnTarget(
            ChaseCameraSettings chaseCameraSettings,
            ZoomSettings zoomSettings)
        {
            this.chaseCameraSettings = chaseCameraSettings;
            this.zoomSettings = zoomSettings;
        }

        public void Setup(GameObject gameObject)
        {
            transform = gameObject.transform;
        }

        public void Execute()
        {
            var targetPos = chaseCameraSettings.Target.position + chaseCameraSettings.Offset;

            // TODO: Avoid view blocking?
            // If not blocked: (raycast from camera to target)
            transform.position = targetPos - transform.rotation * Vector3.forward * zoomSettings.ZoomValue;
            // else if blocked: then recalculate the zoomValue and use this
        }
    }
}