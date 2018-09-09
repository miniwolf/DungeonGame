using System;

namespace DefaultNamespace {
    public interface Entity {
        String Tag { get; }
        void SetupComponents();
        Actionable<T> Actionable<T>();
    }
}