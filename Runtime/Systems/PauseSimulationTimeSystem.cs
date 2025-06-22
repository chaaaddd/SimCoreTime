using Unity.Burst;
using Unity.Entities;

namespace SimCore.Time
{
    internal partial struct PauseSimulationTimeSystem : ISystem
    {
        /// <summary>
        /// Setup the system
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PauseSimulationTimeEvent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var time = SystemAPI.GetSingletonRW<SimulationTime>();

            foreach (var evt in SystemAPI.Query<RefRO<PauseSimulationTimeEvent>>())
            {
                // we're only going to support one event per interation
                time.ValueRW.IsPaused = !time.ValueRO.IsPaused;
                break;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}