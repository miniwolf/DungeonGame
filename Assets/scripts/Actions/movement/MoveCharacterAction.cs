using Components;
using Handlers;
using UnityEngine;

namespace Actions.movement {
    public class MoveCharacterAction : Action {
        private readonly MoveComponent moveComponent;
        private CharacterController characterController;
        private GameObject gameObject;

        public MoveCharacterAction(MoveComponent moveComponent) {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject) {
            this.gameObject = gameObject;
            characterController = gameObject.GetComponent<CharacterController>();
        }

        public void Execute() {
            var offset = moveComponent.Destination - gameObject.transform.position;
            if (!(offset.magnitude > 0.1f))
            {
                return;
            }

            offset = offset.normalized * moveComponent.MoveSpeed;
            characterController.Move(offset * Time.deltaTime);
        }
    }
}