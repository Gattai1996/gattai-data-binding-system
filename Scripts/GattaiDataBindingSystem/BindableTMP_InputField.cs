using TMPro;
using UnityEngine;

namespace GattaiDataBindingSystem
{
    /// <summary>
    /// Represents a Unity UI TMP_InputField component that can be bound to a <see cref="BindableString"/> variable.
    /// </summary>
    [RequireComponent(typeof(TMP_InputField))]
    public class BindableTMP_InputField : BindableComponent<TMP_InputField, BindableString>, ITwoWayDataBinding
    {
        /// <summary>
        /// Sets the text of the TMP_InputField to the value of the bound <see cref="BindableString"/> variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.text = BoundVariable.Value;
        }

        /// <summary>
        /// Binds the TMP_InputField's onValueChanged event to update the value of the bound <see cref="BindableString"/> variable.
        /// </summary>
        public void BindComponent()
        {
            Component.onValueChanged.AddListener(value => BoundVariable.Value = value);
        }
    }
}