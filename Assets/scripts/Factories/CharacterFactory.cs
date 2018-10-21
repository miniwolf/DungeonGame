using Actions;
using Actions.movement;
using Character;
using Components;
using Handlers;
using UnityEngine;

namespace Factories {
    internal class CharacterFactory {
        private readonly Actionable<ControllableActions> actionable;
        private readonly MoveComponent moveComponent;
        private readonly Camera camera;

        public CharacterFactory(Actionable<ControllableActions> actionable,
            MoveComponent moveComponent) {
            this.actionable = actionable;
            this.moveComponent = moveComponent;
            camera = Camera.allCameras[0]; // Why doesn't Camera.main work?
        }

        public void Build() {
            actionable.AddAction(ControllableActions.Move, CreateClickMoveAction());
            actionable.AddAction(ControllableActions.Move, CreateMovement());
        }

        private Handler<NonAction> CreateMovement() {
            var handler = new ActionHandler();
            handler.AddAction(new MoveCharacterAction(moveComponent));
            return handler;
        }

        private Handler<MoveAction> CreateClickMoveAction() {
            var handler = new MouseClickHandler(camera);
            handler.AddAction(new SetDestination(moveComponent));
            return handler;
        }
    }
}