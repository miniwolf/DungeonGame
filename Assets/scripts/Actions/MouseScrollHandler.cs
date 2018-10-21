using System.Collections.Generic;
using Handlers;
using UnityEngine;

namespace Actions {
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