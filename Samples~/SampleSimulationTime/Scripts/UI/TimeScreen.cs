using Unity.Entities;
using UnityEngine.UIElements;
using UnityEngine;
using Unity.Entities.UniversalDelegates;
using Unity.VisualScripting;

namespace SimCore.Time.Samples.SimulationTime
{
    /// <summary>
    /// Time Screen class
    /// </summary>
    public class TimeScreen : ScriptableObject
    {
        /// <summary>
        /// The root visual element
        /// </summary>
        private VisualElement rootElement { get; set; }

        /// <summary>
        /// The ticks label
        /// </summary>
        private Label ticksLabel;
        /// <summary>
        /// The delta time label
        /// </summary>
        private Label deltaTimeLabel;
        /// <summary>
        /// The time scale label
        /// </summary>
        private Label timeScaleLabel;
        /// <summary>
        /// The pause time button
        /// </summary>
        private Button pauseTimeButton;
        /// <summary>
        /// Speed up time button
        /// </summary>
        private Button speedUpTimeButton;
        /// <summary>
        /// Slow down time button
        /// </summary>
        private Button slowDownTimeButton;

        /// <summary>
        /// Instantiate a time screen
        /// </summary>
        /// <param name="parent">The parent visual element</param>
        /// <returns>The time screen</returns>
        public static TimeScreen Instantiate(VisualElement parent)
        {
            var screen = ScriptableObject.CreateInstance<TimeScreen>();
            screen.rootElement = parent;

            screen.ticksLabel = screen.rootElement.Q<Label>("ticks-label");
            screen.deltaTimeLabel = screen.rootElement.Q<Label>("delta-time-label");
            screen.timeScaleLabel = screen.rootElement.Q<Label>("time-scale-label");
            screen.pauseTimeButton = screen.rootElement.Q<Button>("pause-time-button");
            screen.speedUpTimeButton = screen.rootElement.Q<Button>("speed-up-time-button");
            screen.slowDownTimeButton = screen.rootElement.Q<Button>("slow-down-time-button");

            screen.rootElement.style.display = DisplayStyle.Flex;

            screen.pauseTimeButton.clicked += screen.OnPauseTimeButtonClicked;
            screen.speedUpTimeButton.clicked += screen.OnSpeedUpTimeButtonClicked;
            screen.slowDownTimeButton.clicked += screen.OnSlowDownTimeButtonClicked;

            return screen;
        }

        /// <summary>
        /// Update the ticks label
        /// </summary>
        /// <param name="tick">The current number of ticks</param>
        public void UpdateTickLabel(ulong tick)
        {
            ticksLabel.text = $"Tick: {tick}";
        }

        /// <summary>
        /// Update the delta time label
        /// </summary>
        /// <param name="deltaTime">The current delta time</param>
        public void UpdateDeltaTimeLabel(float deltaTime)
        {
            deltaTimeLabel.text = $"Delta Time: {deltaTime}";
        }

        /// <summary>
        /// Update the delta time label
        /// </summary>
        /// <param name="timeScale">The current time scale</param>
        public void UpdateTimeScaleLabel(float timeScale)
        {
            timeScaleLabel.text = $"Time Scale: {timeScale}";
        }

        /// <summary>
        /// Pause time button callback
        /// </summary>
        private void OnPauseTimeButtonClicked()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var entity = entityManager.CreateEntity();
            entityManager.AddComponentData<ModifySimulationTimeEvent>(entity, new ModifySimulationTimeEvent
            {
                Modification = ModifySimulationTime.Pause,
            });
            entityManager.AddComponent<SimulationTimeEvent>(entity);
        }

        /// <summary>
        /// Speed up time button callback
        /// </summary>
        private void OnSpeedUpTimeButtonClicked()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var entity = entityManager.CreateEntity();
            entityManager.AddComponentData<ModifySimulationTimeEvent>(entity, new ModifySimulationTimeEvent
            {
                Modification = ModifySimulationTime.SpeedUp,
            });
            entityManager.AddComponent<SimulationTimeEvent>(entity);
        }
        
        /// <summary>
        /// Pause time button callback
        /// </summary>
        private void OnSlowDownTimeButtonClicked()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var entity = entityManager.CreateEntity();
            entityManager.AddComponentData<ModifySimulationTimeEvent>(entity, new ModifySimulationTimeEvent
            {
                Modification = ModifySimulationTime.SlowDown,
            });
            entityManager.AddComponent<SimulationTimeEvent>(entity);
        }
    }
}