using UnityEngine;

namespace Actions
{
    /// <summary>
    /// The controller is responsible for response control
    /// </summary>
    public interface Action
    {
        /// <summary>
        /// Called from the Start in MonoBehaviour
        /// </summary>
        void Setup(GameObject gameObject);
    }

    public interface NonAction : Action
    {
        /// <summary>
        /// Command to be executed
        /// </summary>
        void Execute();
    }

    public interface MousePositionAction : Action
    {
        /// <param name="mouseX">x coordinate where the button was clicked</param>
        /// <param name="mouseY">y coordinate where the button was clicked</param>
        void Execute(float mouseX, float mouseY);
    }

    public interface ScrollAction : Action
    {
        /// <param name="deltaZoomLevel">Delta on the zoom level</param>
        void Execute(float deltaZoomLevel);
    }

    public interface MoveAction : Action
    {
        /// <summary>
        /// Will pass the position on to the action to affect something on the given position.
        /// </summary>
        /// <param name="pos">Position clicked.</param>
        void Execute(Vector3 pos);
    }

    public interface AxisAction : Action
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertical"></param>
        /// <param name="horizontal"></param>
        void Execute(float vertical, float horizontal);
    }

    public interface TriggerAction : Action
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        void Execute(Collider other);
    }
}