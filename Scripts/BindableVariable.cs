using System;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

/// <summary>
/// This generic class represents a bindable variable that can be bound to one or more Unity UI Components.
/// The class contains a boundComponents list that holds references to all the components that are currently
/// bound to the variable, and an OnValueChanged event that is raised whenever the value of the variable changes.
/// The class also provides a constructor that takes one or more Components as arguments and calls the Bind method
/// to bind them to the variable, and a Bind method that can be used to bind additional components to the variable.
/// </summary>
/// <typeparam name="T">The type of the value that this bindable variable contains.</typeparam>
[Serializable]
public class BindableVariable<T>
{
    /// <summary>
    /// A list with all Components that are currently bound to this bindable variable.
    /// </summary>
    public List<Component> boundComponents = new();

    private T _value;

    /// <summary>
    /// Represents the value of the variable, and raises the OnValueChanged event whenever its value changes.
    /// </summary>
#if ODIN_INSPECTOR
        [ShowInInspector, DisplayAsString]
#endif
    public T value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }

    /// <summary>
    /// It's raised whenever the value of the variable changes. It takes a T parameter that represents the
    /// value of the variable.
    /// </summary>
    public event Action<T> OnValueChanged;

    public BindableVariable()
    {
        boundComponents.Clear();
    }

    public BindableVariable(params Component[] components)
    {
        Bind(components);
    }

    public void Bind(params Component[] components)
    {
        DataBindingSystem.Bind(this, components);
    }
}