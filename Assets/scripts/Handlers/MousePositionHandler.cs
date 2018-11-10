using System.Collections.Generic;
using Actions;
using UnityEngine;

namespace Handlers
{
    public class MousePositionHandler : Handler<MousePositionAction>
    {
        private readonly List<MousePositionAction>
            positionActions = new List<MousePositionAction>();

        public void AddAction(MousePositionAction action)
        {
            positionActions.Add(action);
        }

        public void SetupComponents(GameObject obj)
        {
            foreach (var positionAction in positionActions)
            {
                positionAction.Setup(obj);
            }
        }

        public void DoAction()
        {
            foreach (var positionAction in positionActions)
            {
                positionAction.Execute(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            }
        }
    }
}