using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers {
    public class AxisHandler : Handler<AxisAction> {
        private readonly List<AxisAction> actions = new List<AxisAction>();

        public void AddAction(AxisAction action) {
            actions.Add(action);
        }

        public void SetupComponents(GameObject obj) {
            foreach (var action in actions) {
                action.Setup(obj);
            }
        }

        public void DoAction() {
            foreach (var action in actions) {
                action.Execute(Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));
            }
        }
    }
}