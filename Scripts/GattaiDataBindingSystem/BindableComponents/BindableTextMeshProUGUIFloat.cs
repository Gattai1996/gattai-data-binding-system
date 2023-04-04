using GattaiDataBindingSystem.BindableVariables;
using TMPro;

namespace GattaiDataBindingSystem.BindableComponents
{
    /// <summary>
    /// This class represents a Unity component that can be bound to a <see cref="BindableFloat"/> variable.
    /// It derives from the <see cref="BindableComponent{TC, TV}"/> class, and overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method
    /// to update the text of the <see cref="TextMeshProUGUI"/> component when the value of the bound variable changes.
    /// </summary>
    public class BindableTextMeshProUGUIFloat : BindableComponent<TextMeshProUGUI, BindableFloat>
    {
        /// <summary>
        /// Overrides the <see cref="BindableComponent{TC, TV}.BoundVariable_OnValueChanged"/> method to update the text of the <see cref="TextMeshProUGUI"/> component
        /// with the value of the bound variable.
        /// </summary>
        protected override void BoundVariable_OnValueChanged()
        {
            Component.text = BoundVariable.Value.ToString("F2");
        }
    }
}