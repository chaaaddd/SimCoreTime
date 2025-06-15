using Unity.Entities;

namespace SimCore.Time
{
    /// <summary>
    /// Simulation time data
    /// </summary>
    public struct SimulationTime : IComponentData
    {
        /// <summary>
        /// The time delta time
        /// </summary>
        public float DeltaTime;
        /// <summary>
        /// The current time scale
        /// </summary>
        public float TimeScale;
        /// <summary>
        /// The current time tick
        /// </summary>
        public ulong Tick;
        /// <summary>
        /// If time is paused
        /// </summary>
        public bool IsPaused;
    }
}