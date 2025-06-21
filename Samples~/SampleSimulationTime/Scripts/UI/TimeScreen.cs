using Unity.Entities;
using UnityEngine.UIElements;
using UnityEngine;

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

            screen.rootElement.style.display = DisplayStyle.Flex;

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
    }
}