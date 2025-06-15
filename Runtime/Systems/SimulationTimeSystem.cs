using Unity.Burst;
using Unity.Entities;

namespace SimCore.Time
{
    /// <summary>
    /// Simulation time system
    /// </summary>
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    internal partial struct SimulationTimeSystem : ISystem
    {
        /// <summary>
        /// Setup the system
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SimulationTime>();
        }

        /// <summary>
        /// System update
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var time = SystemAPI.GetSingletonRW<SimulationTime>();

            if (time.ValueRO.IsPaused || time.ValueRO.TimeScale == 0f)
            {
                time.ValueRW.DeltaTime = 0f;
                return;
            }

            time.ValueRW.DeltaTime = SystemAPI.Time.DeltaTime * time.ValueRO.TimeScale;
            time.ValueRW.Tick += 1;
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