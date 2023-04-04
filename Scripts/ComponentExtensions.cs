using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This static class provides extension methods for the Unity Component class.
/// </summary>
public static class ComponentExtensions
{
    /// <summary>
    /// It takes a BindableVariable instance and binds it to a Unity Component. If the component is not already
    /// in the boundComponents list of the variable, the method calls the Bind method on the BindingSystem class,
    /// passing the variable and component as arguments. If the component is already in the list, the method uses
    /// a switch statement to determine the type of the component, and subscribes the appropriate event to the
    /// OnValueChanged event of the variable.
    /// </summary>
    /// <param name="component">The Component that will be bound to the BindableVariable.</param>
    /// <param name="variable">The BindableVariable that will be bound to the Component.</param>
    /// <typeparam name="T">The type of value of the BindableVariable.</typeparam>
    public static void Bind<T>(this Component component, BindableVariable<T> variable)
    {
        if (!variable.boundComponents.Contains(component))
        {
            DataBindingSystem.Bind(variable, component);
            return;
        }
            
        switch (component)
        {
            case InputField inputField:
            {
                inputField.onValueChanged.AddListener(value => variable.value = (T)(object)value);
                break;
            }
            case TMP_InputField tmpInputField:
            {
                tmpInputField.onValueChanged.AddListener(value => variable.value = (T)(object)value);
                break;
            }
        }
    }

    /// <summary>
    /// It takes a Unity Component instance and updates it to match the value. If the value of the variable is
    /// null, the method returns without making any changes. Otherwise, the method uses a switch statement to
    /// determine the type of the component, and sets the appropriate property or field to the string
    /// representation of the value.
    /// </summary>
    /// <param name="component">The Component that will be updated to match the value.</param>
    /// <param name="value">The value that will be set to the Component.</param>
    /// <typeparam name="T">The type of the value.</typeparam>
    public static void UpdateValue<T>(this Component component, T value)
    {
        if (value == null) return;
            
        switch (component)
        {
            case Text textComponent:
            {
                textComponent.text = value.ToString();
                break;
            }
            case TextMeshProUGUI textMeshProUGUI:
            {
                textMeshProUGUI.text = value.ToString();
                break;
            }
            case InputField inputField:
            {
                inputField.text = value.ToString();
                break;
            }
            case TMP_InputField tmpInputField:
            {
                tmpInputField.text = value.ToString();
                break;
            }
        }
    }
}