using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimCore.Time.Samples.SimulationTime
{
    internal partial struct UISystem : ISystem
    {
        private bool init;

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Time.SimulationTime>();

            init = true;
        }

        public void OnUpdate(ref SystemState state)
        {
            if (init)
            {
                var doc = GameObject.Find("UI").GetComponent<UIDocument>();

                var root = doc.rootVisualElement;

                var screensEntity = new UIScreens
                {
                    TimeScreen = TimeScreen.Instantiate(root),
                };

                var entity = state.EntityManager.CreateEntity();
                state.EntityManager.AddComponentData(entity, screensEntity);

                init = false;
            }

            var screens = SystemAPI.GetSingletonRW<UIScreens>();
            var simulationTime = SystemAPI.GetSingleton<Time.SimulationTime>();

            screens.ValueRO.TimeScreen.Value.UpdateTickLabel(simulationTime.Tick);
            screens.ValueRO.TimeScreen.Value.UpdateDeltaTimeLabel(simulationTime.DeltaTime);
            screens.ValueRO.TimeScreen.Value.UpdateTimeScaleLabel(simulationTime.TimeScale);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}