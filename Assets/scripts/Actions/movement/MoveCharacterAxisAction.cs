using Components;
using UnityEngine;

namespace Actions.movement
{
    public class MoveCharacterAxisAction : AxisAction
    {
        private readonly MoveComponent moveComponent;
        private CharacterController characterController;
        private Transform transform;

        public MoveCharacterAxisAction(MoveComponent moveComponent)
        {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject)
        {
            characterController = gameObject.GetComponent<CharacterController>();
            transform = gameObject.transform;
        }

        public void Execute(float vertical, float horizontal)
        {
            var forward = transform.forward.normalized;
            var right = new Vector3(forward.z, 0, -forward.x).normalized;

            var moveFB = vertical * moveComponent.MoveSpeed;
            var moveLR = horizontal * moveComponent.MoveSpeed;

            var move = (moveLR * right + moveFB * forward).normalized;

            characterController.Move(move * Time.deltaTime);
        }
    }
}