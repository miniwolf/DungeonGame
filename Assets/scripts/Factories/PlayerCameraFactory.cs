using Actions;
using Cameras;
using Components;
using Handlers;
using UnityEngine;

namespace Factories {
    public class PlayerCameraFactory {
        private readonly Actionable<CameraActions> actionable;
        private readonly ZoomSettings settings;
        private readonly Camera mainCamera;

        public PlayerCameraFactory(Actionable<CameraActions> actionable, ZoomSettings settings, Camera mainCamera) {
            this.actionable = actionable;
            this.settings = settings;
            this.mainCamera = mainCamera;
        }

        public void Build() {
            actionable.AddAction(CameraActions.FollowPlayer, ZoomAction());
        }

        private Handler<ScrollAction> ZoomAction() {
            var handler = new MouseScrollHandler();
            handler.AddAction(new ZoomAction(settings));
            return handler;
        }
    }
}