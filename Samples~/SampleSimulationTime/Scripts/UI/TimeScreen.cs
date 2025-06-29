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
        /// The pause time button
        /// </summary>
        private Button pauseTimeButton;

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
            screen.pauseTimeButton = screen.rootElement.Q<Button>("pause-time-button");

            screen.rootElement.style.display = DisplayStyle.Flex;

            screen.pauseTimeButton.clicked += screen.OnPauseTimeButtonClicked;

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
        /// Pause time button callback
        /// </summary>
        private void OnPauseTimeButtonClicked()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var entity = entityManager.CreateEntity();
            entityManager.AddComponent<ModifySimulationTimeEvent>(entity, new ModifySimulationTimeEvent
            {
                Modification = ModifySimulationTime.Pause,
            });
            entityManager.AddComponent<SimulationTimeEvent>(entity);
        }
    }
}