using Components;
using UnityEngine;

namespace Character {
    public class Character : ActionableEntityImpl<ControllableActions>, MoveComponent {

        public override string Tag => "Character";

        public float moveSpeed = 1f;
        public float MoveSpeed {
            get => moveSpeed;
            set => moveSpeed = value;
        }
        public Vector3 Destination { get; set; }

        private void FixedUpdate() {
            ExecuteAction(ControllableActions.Move);
        }
    }

    public enum ControllableActions {
        Move
    }
}