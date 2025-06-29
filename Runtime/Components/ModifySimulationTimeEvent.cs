using Unity.Entities;

namespace SimCore.Time
{
    /// <summary>
    /// Modify simulation time types
    /// </summary>
    public enum ModifySimulationTime
    {
        /// <summary>
        /// Speed up time
        /// </summary>
        SpeedUp,
        /// <summary>
        /// Slow down time
        /// </summary>
        SlowDown,
        /// <summary>
        /// Pause time
        /// </summary>
        Pause
    }

    /// <summary>
    /// Modify simulation time event
    /// </summary>
    public struct ModifySimulationTimeEvent : IComponentData
    {
        /// <summary>
        /// The modification to use
        /// </summary>
        public ModifySimulationTime Modification;
    }
}