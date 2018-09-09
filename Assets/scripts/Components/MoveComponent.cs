using UnityEngine;

namespace Components {
    public interface MoveComponent {
        float MoveSpeed { get; set; }
        Vector3 Destination { get; set; }
    }
}