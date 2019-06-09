using Actions;
using Actions.Attacking;
using Actions.movement;
using Character;
using Components;
using Handlers;
using UnityEngine;

namespace Factories
{
    internal class CharacterFactory
    {
        private readonly Actionable<ControllableActions> actionable;
        private readonly MoveComponent moveComponent;
        private readonly Camera camera;

        public CharacterFactory(Actionable<ControllableActions> actionable,
            MoveComponent moveComponent)
        {
            this.actionable = actionable;
            this.moveComponent = moveComponent;
            camera = Camera.allCameras[0]; // Why doesn't Camera.main work?
        }

        public void Build()
        {
            actionable.AddAction(ControllableActions.MouseMove, CreateClickMoveAction());
            actionable.AddAction(ControllableActions.MouseMove, CreateMovement());

            actionable.AddAction(ControllableActions.KeyboardMove, CreateKeyboardMoveAction());
            actionable.AddAction(ControllableActions.Target, CreateTargetAction());
            actionable.AddAction(ControllableActions.Attack, CreateAttackAction());
        }

        private static Handler<NonAction> CreateAttackAction()
        {
            var handler = new ActionHandler();
            handler.AddAction(new StartAttacking());
            return handler;
        }

        private Handler<NonAction> CreateTargetAction()
        {
            var handler = new ActionHandler();
            handler.AddAction(new Targeting(camera));
            return handler;
        }

        private Handler<AxisAction> CreateKeyboardMoveAction()
        {
            var handler = new AxisHandler();
            handler.AddAction(new MoveCharacterAxisAction(moveComponent));
            return handler;
        }

        private Handler<NonAction> CreateMovement()
        {
            var handler = new ActionHandler();
            handler.AddAction(new MoveCharacterNonAction(moveComponent));
            return handler;
        }

        private Handler<MoveAction> CreateClickMoveAction()
        {
            var handler = new MouseRaycastHandler(camera);
            handler.AddAction(new SetDestinationOnMoveComponent(moveComponent));
            return handler;
        }
    }
}