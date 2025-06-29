using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

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
            var timeConfig = SystemAPI.GetSingleton<SimulationTimeConfig>();

            foreach (var evt in SystemAPI.Query<RefRO<ModifySimulationTimeEvent>>())
            {
                // we're only going to support one event per interation
                switch (evt.ValueRO.Modification)
                {
                    case ModifySimulationTime.SpeedUp:
                        time.ValueRW.TimeScale += timeConfig.TimeModificationStepSize;
                        time.ValueRW.TimeScale = math.clamp(time.ValueRW.TimeScale, timeConfig.MinTimeSpeed, timeConfig.MaxTimeSpeed);
                        break;
                    case ModifySimulationTime.SlowDown:
                        time.ValueRW.TimeScale -= timeConfig.TimeModificationStepSize;
                        time.ValueRW.TimeScale = math.clamp(time.ValueRW.TimeScale, timeConfig.MinTimeSpeed, timeConfig.MaxTimeSpeed);
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