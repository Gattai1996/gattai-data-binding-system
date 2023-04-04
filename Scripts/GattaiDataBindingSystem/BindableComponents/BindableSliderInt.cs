using UnityEngine;
using UnityEngine.UI;
using GattaiDataBindingSystem.BindableVariables;

namespace GattaiDataBindingSystem.BindableComponents
{
    /// <summary>
    /// This class represents a Unity UI Slider component that can be bound to a <see cref="BindableInt"/> variable.
    /// It derives from the <see cref="BindableComponent{TC, TV}"/> class, and overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method
    /// to update the value of the bound variable when the slider's value changes.
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class BindableSliderInt : BindableComponent<Slider, BindableInt>, ITwoWayDataBinding
    {
        /// <summary>
        /// Binds the Slider's valueChanged event to update the value of the bound <see cref="BindableInt"/> variable.
        /// </summary>
        public void BindComponent()
        {
            Component.onValueChanged.AddListener(value => BoundVariable.Value = (int)value);
        }

        /// <summary>
        /// Overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method to update the value of the slider
        /// with the value of the bound variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.value = BoundVariable.Value;
        }
    }
}