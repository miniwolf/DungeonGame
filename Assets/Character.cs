using Components;
using UnityEngine;

namespace DefaultNamespace {
    public class Character : ActionableEntityImpl<ControllableActions>, MoveComponent {

        public override string Tag => "Character";

        public float MoveSpeed { get; set; } = 1f;
        public Vector3 Destination { get; set; }

        private void FixedUpdate() {
            ExecuteAction(ControllableActions.Move);
        }
    }
}