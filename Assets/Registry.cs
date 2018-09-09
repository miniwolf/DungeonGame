using System.Collections.Generic;
using Components;
using Factories;
using Handlers;
using UnityEngine;

namespace DefaultNamespace {
    public class Registry : MonoBehaviour {
        private static readonly List<Entity> EntityList = new List<Entity>();

        public static void Register(Entity entity) {
            EntityList.Add(entity);
        }

        private void Start() {
            EntityList.ForEach(InitializeComponent);
        }

        private void InitializeComponent(Entity entity) {
            switch (entity.Tag) {
                case "Character":
                    new CharacterFactory(entity.Actionable<ControllableActions>(), (MoveComponent)entity).Build();
                    break;
            }

            entity.SetupComponents();
        }
    }

    public enum ControllableActions {
        Move
    }
}