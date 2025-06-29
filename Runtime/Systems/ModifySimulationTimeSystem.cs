using Unity.Burst;
using Unity.Entities;

namespace SimCore.Time
{
    internal partial struct ModifySimulationTimeSystem : ISystem
    {
        /// <summary>
        /// Setup the system
        /// </summary>
        /// <param name="state">The system state</param>
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ModifySimulationTimeEvent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var time = SystemAPI.GetSingletonRW<SimulationTime>();

            foreach (var evt in SystemAPI.Query<RefRO<ModifySimulationTimeEvent>>())
            {
                // we're only going to support one event per interation
                switch (evt.ValueRO.Modification)
                {
                    case ModifySimulationTime.SpeedUp:
                        break;
                    case ModifySimulationTime.SlowDown:
                        break;
                    case ModifySimulationTime.Pause:
                        time.ValueRW.IsPaused = !time.ValueRO.IsPaused;
                        break;
                    default:
                        UnityEngine.Debug.LogWarning($"Invalid simulation modification: {evt.ValueRO.Modification}");
                        break;
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}