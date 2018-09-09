using Components;
using Handlers;
using UnityEngine;

namespace Actions.movement {
    public class SetDestination : MoveAction {
        private readonly MoveComponent moveComponent;

        public SetDestination(MoveComponent moveComponent) {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject) {
        }

        public void Execute() {
        }

        public void Execute(Vector3 pos) {
            moveComponent.Destination = pos;
        }
    }
}