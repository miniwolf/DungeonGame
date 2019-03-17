using Components;
using UnityEngine;

namespace Actions.Triggers
{
    public class ChaseTrigger : TriggerAction
    {
        private readonly MoveComponent moveComponent;

        public ChaseTrigger(MoveComponent moveComponent)
        {
            this.moveComponent = moveComponent;
        }

        public void Setup(GameObject gameObject) { }

        public void Execute(Collider other)
        {
            moveComponent.Destination = other.gameObject.transform.position;
        }
    }
}