using Actions;
using Cameras;
using Components;
using Handlers;

namespace Factories
{
    public class PlayerCameraFactory
    {
        private readonly Actionable<CameraActions> actionable;
        private readonly ZoomSettings zoomSettings;
        private readonly ChaseCameraSettings chaseCameraSettings;

        public PlayerCameraFactory(
            Actionable<CameraActions> actionable,
            ZoomSettings zoomSettings,
            ChaseCameraSettings chaseCameraSettings)
        {
            this.actionable = actionable;
            this.zoomSettings = zoomSettings;
            this.chaseCameraSettings = chaseCameraSettings;
        }

        public void Build()
        {
            actionable.AddAction(CameraActions.FollowPlayer, ZoomAction());
            actionable.AddAction(CameraActions.FollowPlayer, RotateAround());
            actionable.AddAction(CameraActions.FollowPlayer, StayOnPlayer());
        }

        private Handler<MousePositionAction> RotateAround()
        {
            var handler = new MousePositionHandler();
            handler.AddAction(new RotateAroundTarget(chaseCameraSettings));
            return handler;
        }

        private Handler<NonAction> StayOnPlayer()
        {
            var handler = new ActionHandler();
            handler.AddAction(
                new StayOnTarget(
                    chaseCameraSettings,
                    zoomSettings)
            );
            return handler;
        }

        private Handler<ScrollAction> ZoomAction()
        {
            var handler = new MouseScrollHandler();
            handler.AddAction(new ZoomAction(zoomSettings));
            return handler;
        }
    }
}