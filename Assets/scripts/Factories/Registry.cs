using System.Collections.Generic;
using Cameras;
using Character;
using Components;
using Factories;
using Handlers;
using UnityEngine;

namespace Factories
{
    public class Registry : MonoBehaviour
    {
        private static readonly List<Entity> EntityList = new List<Entity>();
        private Camera mainCamera;

        public static void Register(Entity entity)
        {
            EntityList.Add(entity);
        }

        private void Start()
        {
            mainCamera = Camera.allCameras[0]; // Why doesn't Camera.main work?
            EntityList.ForEach(InitializeComponent);
        }

        private void InitializeComponent(Entity entity)
        {
            switch (entity.Tag)
            {
                case "Character":
                    new CharacterFactory(
                        entity.Actionable<ControllableActions>(),
                        (MoveComponent) entity).Build();
                    break;
                case "PlayerCamera":
                    new PlayerCameraFactory(
                        entity.Actionable<CameraActions>(),
                        (ZoomSettings) entity,
                        (ChaseCameraSettings) entity).Build();
                    break;
            }

            entity.SetupComponents();
        }
    }
}