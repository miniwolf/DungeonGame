
using Components;
using UnityEngine;

namespace Actions {
    public class ZoomAction : ScrollAction {
        private readonly ZoomSettings settings;

        public ZoomAction(ZoomSettings settings) {
            this.settings = settings;
        }

        public void Setup(GameObject gameObject) {
            settings.ZoomValue = -3;
        }

        public void Execute(float deltaZoomLevel) {
            settings.ZoomValue -= deltaZoomLevel * settings.ZoomSpeed;
            if (settings.ZoomValue > settings.ZoomMax) {
                settings.ZoomValue = settings.ZoomMax;
            } else if (settings.ZoomValue < settings.ZoomMin) {
                settings.ZoomValue = settings.ZoomMin;
            }
        }
    }
}