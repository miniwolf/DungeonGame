using Components;
using UnityEngine;

namespace Character {
    public class Character : ActionableEntityImpl<ControllableActions>, MoveComponent {

        public override string Tag => "Character";

        public bool toggleMove;
        public float moveSpeed = 1f;
        public float MoveSpeed {
            get => moveSpeed;
            set => moveSpeed = value;
        }
        public Vector3 Destination { get; set; }

        private void FixedUpdate() {
            if (toggleMove) {
                ExecuteAction(ControllableActions.KeyboardMove);
            } else {
                ExecuteAction(ControllableActions.MouseMove);
            }
        }
    }

    public enum ControllableActions {
        KeyboardMove, MouseMove
    }
}