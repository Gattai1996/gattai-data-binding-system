using TMPro;
using UnityEngine;

namespace GattaiDataBindingSystem
{
    /// <summary>
    /// This class represents a Unity component that can be bound to a <see cref="BindableString"/> variable.
    /// It derives from the <see cref="BindableComponent{TC, TV}"/> class, and overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method
    /// to update the text of the <see cref="TextMeshProUGUI"/> component when the value of the bound variable changes.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BindableTextMeshProUGUI : BindableComponent<TextMeshProUGUI, BindableString>
    {
        /// <summary>
        /// Overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method to update the text of the <see cref="TextMeshProUGUI"/> component
        /// with the value of the bound variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.SetText(BoundVariable.Value);
        }
    }
}