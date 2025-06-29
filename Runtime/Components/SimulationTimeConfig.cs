using Unity.Entities;

namespace SimCore.Time
{
    /// <summary>
    /// Simulation Time Config
    /// </summary>
    public struct SimulationTimeConfig : IComponentData
    {
        /// <summary>
        /// The step size to use for time modification
        /// </summary>
        public float TimeModificationStepSize;
        /// <summary>
        /// The minimum time speed
        /// </summary>
        public float MinTimeSpeed;
        /// <summary>
        /// The max time speed
        /// </summary>
        public float MaxTimeSpeed;
    }
}
