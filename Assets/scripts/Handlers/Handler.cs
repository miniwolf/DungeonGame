using UnityEngine;

namespace Handlers {
    public interface Handler {
        /// <summary>
        /// Setups the components. Called from the script that has a list of handlers
        /// </summary>
        /// <param name="obj">Gameobject that will execute the handler</param>
        void SetupComponents(GameObject obj);

        /// <summary>
        /// Execute the actions in the container in order they have been added
        /// </summary>
        void DoAction();
    }

    public interface Handler<in A> : Handler {
        /// <summary>
        /// Adds an action to the handler. This action will be execute in order by the internal handler
        /// </summary>
        /// <param name="action">Action to be added.</param>
        void AddAction(A action); // TODO: Only implementations are used, good point.
    }
}