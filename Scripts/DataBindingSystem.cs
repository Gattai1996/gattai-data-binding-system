using UnityEngine;

/// <summary>
/// This static class provides a method for a simple two-way data binding system between variables
/// and UI components in Unity.
/// </summary>
public static class DataBindingSystem
{
    /// <summary>
    /// It takes a BindableVariable instance and one or more Components as arguments, and adds the components
    /// to the boundComponents list of the variable. The method also subscribes the variable's OnValueChanged
    /// event to the BindableVariableOnValueChanged method, and calls the Bind extension method on each component,
    /// passing the variable as an argument.
    /// </summary>
    /// <param name="variable">The BindableVariable to bind to the components.</param>
    /// <param name="components">The Components that the variable will be bound to.</param>
    /// <typeparam name="T">The type of value of the BindableVariable.</typeparam>
    public static void Bind<T>(BindableVariable<T> variable, params Component[] components)
    {
        foreach (var component in components)
        {
            variable.boundComponents.Add(component);
            variable.OnValueChanged += value => component.UpdateValue(value);
            component.Bind(variable);
        }
    }
}