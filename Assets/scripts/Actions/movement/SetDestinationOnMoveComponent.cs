using Components;
using Handlers;
using UnityEngine;

namespace Actions.movement
{
    public class SetDestinationOnMoveComponent : MoveAction
    {
        private readonly MoveComponent moveComponent;

        public SetDestinationOnMoveComponent(MoveComponent moveComponent)
        {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject) { }

        public void Execute(Vector3 pos)
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            moveComponent.Destination = pos;
        }
    }
}