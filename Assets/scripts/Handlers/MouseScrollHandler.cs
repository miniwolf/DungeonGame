using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers {
    internal class MouseScrollHandler : Handler<ScrollAction> {
        private readonly List<ScrollAction> actions = new List<ScrollAction>();

        public void SetupComponents(GameObject obj) {
            foreach (var action in actions) {
                action.Setup(obj);
            }
        }

        public void AddAction(ScrollAction action) {
            actions.Add(action);
        }

        public void DoAction() {
            foreach (var action in actions) {
                action.Execute(Input.GetAxis("Mouse ScrollWheel"));
            }
        }
    }
}