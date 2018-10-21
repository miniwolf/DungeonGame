using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers {
    public class ActionHandler : Handler<NonAction> {
        private readonly List<NonAction> actions = new List<NonAction>();

        public void SetupComponents(GameObject obj) {
            foreach (var action in actions) {
                action.Setup(obj);
            }
        }

        public void DoAction() {
            foreach (var action in actions) {
                action.Execute();
            }
        }

        public void AddAction(NonAction action) {
            actions.Add(action);
        }
    }
}