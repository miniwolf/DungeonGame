using Components;

namespace Cameras {
    public class CameraSystem : ActionableEntityImpl<CameraActions> {
        void Update() {
            ExecuteAction(CameraActions.FollowPlayer);
        }

        public override string Tag { get; } = "PlayerCamera";
    }

    public enum CameraActions {
        FollowPlayer
    }
}

