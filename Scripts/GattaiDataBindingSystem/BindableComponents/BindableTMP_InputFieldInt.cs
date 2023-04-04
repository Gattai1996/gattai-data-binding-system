using GattaiDataBindingSystem.BindableVariables;
using TMPro;
using UnityEngine;

namespace GattaiDataBindingSystem.BindableComponents
{
    /// <summary>
    /// Represents a Unity UI TMP_InputField component that can be bound to a <see cref="BindableInt"/> variable.
    /// </summary>
    [RequireComponent(typeof(TMP_InputField))]
    public class BindableTMP_InputFieldInt : BindableComponent<TMP_InputField, BindableInt>, ITwoWayDataBinding
    {
        /// <summary>
        /// Sets the text of the TMP_InputField to the value of the bound <see cref="BindableInt"/> variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.text = BoundVariable.Value.ToString();
        }

        /// <summary>
        /// Binds the TMP_InputField's onValueChanged event to update the value of the bound <see cref="BindableInt"/> variable.
        /// </summary>
        public void BindComponent()
        {
            Component.onValueChanged.AddListener(value =>
            {
                if (int.TryParse(value, out var parsedValue))
                {
                    BoundVariable.Value = parsedValue;
                }
            });
        }
    }
}