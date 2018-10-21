using System;
using Actions;

namespace Components {
    public interface Entity {
        String Tag { get; }
        void SetupComponents();
        Actionable<T> Actionable<T>();
    }
}