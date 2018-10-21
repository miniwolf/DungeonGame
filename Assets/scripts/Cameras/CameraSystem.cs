using System;
using Components;

namespace Cameras {
    public class CameraSystem : ActionableEntityImpl<CameraActions>, ZoomSettings {
        void Update() {
            ExecuteAction(CameraActions.FollowPlayer);
        }

        public override string Tag { get; } = "PlayerCamera";

        public float zoomSpeed = 2;
        public float zoomMin = -10f;
        public float zoomMax = -2f;
        public float ZoomSpeed {
            get => zoomSpeed;
            set => zoomSpeed = value;
        }

        public float ZoomMin {
            get => zoomMin;
            set => zoomMin = value;
        }

        public float ZoomMax {
            get => zoomMax;
            set => zoomMax = value;
        }
    }

    public enum CameraActions {
        FollowPlayer
    }
}

