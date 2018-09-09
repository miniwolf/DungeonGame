using System.Collections.Generic;
using Handlers;
using UnityEngine;

namespace Actions {
    public class ActionHandler : Handler {
        private readonly List<Action> actions = new List<Action>();

        public virtual void SetupComponents(GameObject obj) {
            foreach ( var action in actions ) {
                action.Setup(obj);
            }
        }

        public virtual void DoAction() {
            foreach ( var action in actions ) {
                action.Execute();
            }
        }

        public void AddAction(Action action) {
            actions.Add(action);
        }
    }
}