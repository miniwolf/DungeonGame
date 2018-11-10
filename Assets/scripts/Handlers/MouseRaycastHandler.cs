using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers
{
    public class MouseRaycastHandler : Handler<MoveAction>
    {
        private readonly List<MoveAction> moveActions = new List<MoveAction>();

        private readonly Camera camera;

        private LayerMask layerMask; // = 1 << LayerConstants.GroundLayer;
        private RaycastHit hit;
        private Ray cameraToGround;

        public MouseRaycastHandler(Camera camera)
        {
            this.camera = camera;
        }

        public void SetupComponents(GameObject obj)
        {
            foreach (var action in moveActions)
            {
                action.Setup(obj);
            }
        }

        public void AddAction(MoveAction action)
        {
            moveActions.Add(action);
        }

        public void DoAction()
        {
            cameraToGround = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(cameraToGround, out hit, 500f))
            {
                return;
            }

            foreach (var action in moveActions)
            {
                action.Execute(hit.point);
            }
        }
    }
}