using System.Collections.Generic;
using Handlers;
using UnityEngine;

namespace Actions {
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