using GattaiDataBindingSystem.BindableVariables;
using UnityEngine;
using UnityEngine.UI;

namespace GattaiDataBindingSystem.BindableComponents
{
    /// <summary>
    /// Represents a Unity UI Slider component that can be bound to a <see cref="BindableFloat"/> variable.
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class BindableSliderFloat : BindableComponent<Slider, BindableFloat>, ITwoWayDataBinding
    {
        /// <summary>
        /// Binds the Slider's valueChanged event to update the value of the bound <see cref="BindableFloat"/> variable.
        /// </summary>
        public void BindComponent()
        {
            Component.onValueChanged.AddListener(value => BoundVariable.Value = value);
        }

        /// <summary>
        /// Sets the value of the Slider to the value of the bound <see cref="BindableFloat"/> variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.value = BoundVariable.Value;
        }
    }
}