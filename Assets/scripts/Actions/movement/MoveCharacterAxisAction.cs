
using Components;
using UnityEngine;

namespace Actions.movement {
    public class MoveCharacterAxisAction : AxisAction {
        private readonly MoveComponent moveComponent;
        private CharacterController characterController;

        public MoveCharacterAxisAction(MoveComponent moveComponent) {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject) {
            characterController = gameObject.GetComponent<CharacterController>();
        }

        public void Execute(float vertical, float horizontal) {
            var moveFB = vertical * moveComponent.MoveSpeed;
            var moveLR = horizontal * moveComponent.MoveSpeed;

            var offset = new Vector3(moveFB, 0, -moveLR);
            characterController.Move(offset * Time.deltaTime);
        }
    }
}