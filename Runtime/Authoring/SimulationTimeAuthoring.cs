using Unity.Entities;
using UnityEngine;

namespace SimCore.Time.Authoring
{
    /// <summary>
    /// Simulation Time Authoring
    /// </summary>
    internal class SimulationTimeAuthoring : MonoBehaviour
    {
        /// <summary>
        /// The simuation time scale
        /// </summary>
        public float TimeScale = 1.0f;
        /// <summary>
        /// If time should start as paused
        /// </summary>
        public bool StartPaused = false;
        /// <summary>
        /// The time step to use
        /// </summary>
        public float TimeStep = 1.0f;
        /// <summary>
        /// The minimum time scale
        /// </summary>
        public float MinTimeScale = 0.0f;
        /// <summary>
        /// The maximum time scale
        /// </summary>
        public float MaxTimeScale = 5.0f;
    }

    /// <summary>
    /// Simulation Time Baker
    /// </summary>
    internal class SimulationTimeAuthoringBaker : Baker<SimulationTimeAuthoring>
    {
        /// <summary>
        /// Bake the component
        /// </summary>
        /// <param name="authoring">The authoring component</param>
        public override void Bake(SimulationTimeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new SimulationTime
            {
                TimeScale = authoring.TimeScale,
                IsPaused = authoring.StartPaused,
                DeltaTime = 0.0f,
                Tick = 0
            });

            AddComponent(entity, new SimulationTimeConfig
            {
                TimeModificationStepSize = authoring.TimeStep,
                MinTimeSpeed = authoring.MinTimeScale,
                MaxTimeSpeed = authoring.MaxTimeScale
            });
        }
    }
}
