using Unity.Entities;

namespace SimCore.Time.Samples.SimulationTime
{
    /// <summary>
    /// UI Screens component data
    /// </summary>
    public struct UIScreens : IComponentData
    {
        /// <summary>
        /// The time screen
        /// </summary>
        public UnityObjectRef<TimeScreen> TimeScreen;
    }
}