using UnityEngine;

namespace Components
{
    public interface ChaseCameraSettings
    {
        Transform Target { get; set; }
        Vector3 Offset { get; set; }
        float RotationSpeed { get; set; }
        float XMinAngle { get; set; }
        float XMaxAngle { get; set; }
    }
}