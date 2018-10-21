using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers {
    public class MouseClickHandler : Handler<MoveAction> {
        private readonly List<MoveAction> actions = new List<MoveAction>();
        private readonly Camera camera;

        private LayerMask layerMask; // = 1 << LayerConstants.GroundLayer;
        private RaycastHit hit;
        private Ray cameraToGround;

        public MouseClickHandler(Camera camera) {
            this.camera = camera;
        }

        public void SetupComponents(GameObject obj) {
            foreach (var action in actions) {
                action.Setup(obj);
            }
        }

        public void AddAction(MoveAction action) {
            actions.Add(action);
        }

        public void DoAction() {
            if (!Input.GetMouseButtonDown(0)) {
                return;
            }

            cameraToGround = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(cameraToGround, out hit, 500f)) {
                return;
            }

            foreach (var action in actions) {
                action.Execute(hit.point);
            }
        }
    }
}