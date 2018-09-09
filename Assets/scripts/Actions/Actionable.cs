using Handlers;

namespace DefaultNamespace {
    public interface Actionable<in T> {
        /// <summary>
        /// Adds the action along with the handler that will be executed when the command pattern invoker is called.
        /// </summary>
        /// <param name="actionName">Action name.</param>
        /// <param name="action">Action handler.</param>
        void AddAction(T actionName, Handler action);

        /// <summary>
        /// Execute the specified handler bound to the actionanem.
        /// </summary>
        /// <param name="actionName">Action name.</param>
        void ExecuteAction(T actionName);
    }
}