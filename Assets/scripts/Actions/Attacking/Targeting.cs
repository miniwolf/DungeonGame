using Components;
using UnityEngine;

namespace Actions.Attacking
{
    public class Targeting : NonAction
    {
        private readonly Camera main;
        private TargetComponent target;

        public Targeting(Camera main)
        {
            this.main = main;
        }

        public void Setup(GameObject gameObject)
        {
            target = gameObject.GetComponent<TargetComponent>();
        }

        public void Execute()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                target.Target = hit.collider.transform;
            }
        }
    }
}