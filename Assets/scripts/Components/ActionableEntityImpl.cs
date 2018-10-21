using System.Collections.Generic;
using Actions;
using Factories;
using Handlers;
using UnityEngine;

namespace Components {
    public abstract class ActionableEntityImpl<T> : MonoBehaviour, Actionable<T>, Entity {
        private readonly Dictionary<T, List<Handler>> actions = new Dictionary<T, List<Handler>>();

        protected void Awake() {
            Registry.Register(this);
        }

        public void AddAction<A>(T actionName, Handler<A> action) where A : Action {
            actions.TryGetValue(actionName, out var handlers);
            if (handlers == null) {
                handlers = new List<Handler>();
                actions.Add(actionName, handlers);
            }
            handlers.Add(action);
        }

        public void ExecuteAction(T actionName) {
            if (actions.ContainsKey(actionName)) {
                actions[actionName].ForEach(action => action.DoAction());
            } else {
                Debug.LogError("Cannot execute action " + actionName + " on " + this);
            }
        }

        public abstract string Tag { get; }

        public void SetupComponents() {
            foreach (var handlers in actions.Values) {
                handlers.ForEach(handler => handler.SetupComponents(gameObject));
            }
        }

        public Actionable<T1> Actionable<T1>() {
            return (Actionable<T1>) this;
        }
    }
}
