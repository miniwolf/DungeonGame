using UnityEngine;

namespace Actions {
    public class ZoomAction : ScrollAction {
        private Transform playerCam;
        private float zoom;

        public void Setup(GameObject gameObject) {
            zoom = -3;
            playerCam = gameObject.transform;
        }

        public void Execute(float deltaZoomLevel) {
            zoom += deltaZoomLevel;
            playerCam.transform.localPosition = new Vector3 (0, 0, zoom);
        }
    }
}