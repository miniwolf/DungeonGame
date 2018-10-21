using UnityEngine;

namespace Actions {
    /// <summary>
    /// The controller is responsible for response control
    /// </summary>
    public interface Action {
        /// <summary>
        /// Called from the Start in MonoBehaviour
        /// </summary>
        void Setup(GameObject gameObject);
    }

    public interface NonAction : Action {
        /// <summary>
        /// Command to be executed
        /// </summary>
        void Execute();
    }

    public interface ScrollAction : Action {
        /// <summary>
        /// Will pass the position on to the action to affect something on the given position.
        /// </summary>
        /// <param name="deltaZoomLevel">Level zoomed already</param>
        void Execute(float deltaZoomLevel);
    }

    public interface MoveAction : Action {
        /// <summary>
        /// Will pass the position on to the action to affect something on the given position.
        /// </summary>
        /// <param name="pos">Position clicked.</param>
        void Execute(Vector3 pos);
    }
}