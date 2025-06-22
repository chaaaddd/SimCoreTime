using Unity.Burst;
using Unity.Entities;

namespace SimCore.Time
{
    /// <summary>
    /// System to clean up time event entities
    /// </summary>
    [UpdateAfter(typeof(SimulationTimeSystem))]
    [UpdateAfter(typeof(PauseSimulationTimeSystem))]
    internal partial struct SimulationTimeEventCleanupSystem : ISystem
    {
        /// <summary>
        /// Create the system
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PauseSimulationTimeEvent>();
        }

        /// <summary>
        /// System update
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var query = SystemAPI.QueryBuilder().WithAll<PauseSimulationTimeEvent>().Build();
            state.EntityManager.DestroyEntity(query);
        }

        /// <summary>
        /// Destroy the system
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}
