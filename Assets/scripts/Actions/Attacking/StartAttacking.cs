using Components;
using UnityEngine;

namespace Actions.Attacking
{
    public class StartAttacking : NonAction
    {
        private AttackComponent attack;
        private TargetComponent target;

        public void Setup(GameObject gameObject)
        {
            attack = gameObject.GetComponent<AttackComponent>();
            target = gameObject.GetComponent<TargetComponent>();
        }

        public void Execute()
        {
            attack.Target = target.Target;
        }
    }
}