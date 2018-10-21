using Actions;
using Cameras;
using Handlers;
using UnityEngine;

namespace Factories {
    public class PlayerCameraFactory {
        private readonly Actionable<CameraActions> actionable;
        private readonly Camera mainCamera;

        public PlayerCameraFactory(Actionable<CameraActions> actionable, Camera mainCamera) {
            this.actionable = actionable;
            this.mainCamera = mainCamera;
        }

        public void Build() {
            actionable.AddAction(CameraActions.FollowPlayer, ZoomAction());
        }

        private Handler<ScrollAction> ZoomAction() {
            var handler = new MouseScrollHandler();
            handler.AddAction(new ZoomAction());
            return handler;
        }
    }
}