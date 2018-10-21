
using Components;
using UnityEngine;

namespace Actions {
    public class ZoomAction : ScrollAction {
        private Transform playerCam;
        private float zoom;
        private readonly ZoomSettings settings;

        public ZoomAction(ZoomSettings settings) {
            this.settings = settings;
        }

        public void Setup(GameObject gameObject) {
            zoom = -3;
            playerCam = gameObject.transform;
        }

        public void Execute(float deltaZoomLevel) {
            zoom += deltaZoomLevel * settings.ZoomSpeed;
            zoom = Mathf.Clamp(zoom, settings.ZoomMax, settings.ZoomMin);
            playerCam.transform.localPosition = new Vector3 (0, 0, zoom);
        }
    }
}