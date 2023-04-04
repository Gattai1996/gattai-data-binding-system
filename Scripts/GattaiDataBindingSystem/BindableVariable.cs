using System;
using System.Collections.Generic;
using UnityEngine;

namespace GattaiDataBindingSystem
{
    /// <summary>
    /// This generic class represents a bindable variable that can be bound to one or more Unity UI Components.
    /// The class contains a boundComponents list that holds references to all the components that are currently
    /// bound to the variable, and an OnValueChanged event that is raised whenever the value of the variable changes.
    /// The class also provides a constructor that takes one or more Components as arguments and calls the Bind method
    /// to bind them to the variable, and a Bind method that can be used to bind additional components to the variable.
    /// </summary>
    /// <typeparam name="T">The type of the value that this bindable variable contains.</typeparam>
    public abstract class BindableVariable<T> : ScriptableObject, IBindableVariable
    {
        /// <summary>
        /// A list with all Components that are currently bound to this bindable variable.
        /// </summary>
        [SerializeField] private List<Component> boundComponents;

        [SerializeField] private T value;

        /// <summary>
        /// Represents the value of the variable, and raises the OnValueChanged event whenever its value changes.
        /// </summary>
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke();
            }
        }

        /// <summary>
        /// It's raised whenever the value of the variable changes. It takes a T parameter that represents the
        /// value of the variable.
        /// </summary>
        public event Action OnValueChanged;

        protected void OnDisable()
        {
            boundComponents.Clear();
        }

        /// <summary>
        /// Binds this BindableVariable to one or more Components that implement the IBindableComponent interface.
        /// </summary>
        /// <param name="components">One or more Components to bind the BindableVariable to.</param>
        /// <remarks>
        /// The BindableVariable will be bound to each Component that is passed as a parameter. If a Component is already bound to
        /// the BindableVariable, it will not be bound again. If a Component does not implement the IBindableComponent interface,
        /// an error message will be logged to the console and the BindableVariable will not be bound to the Component.
        /// </remarks>
        public virtual void Bind(params Component[] components)
        {
            foreach (var component in components)
            {
                if (boundComponents.Contains(component))
                {
                    return;
                }

                if (!component.TryGetComponent(out IBindableComponent bindableComponent))
                {
                    Debug.LogError($"It's not possible to bind the variable '{name}' to the component " +
                                   $"'{component.gameObject}' gameObject has no bindable component attached to it.");
                    return;
                }
                
                boundComponents.Add(component);
                bindableComponent.Bind(this);
            }
        }
    }
}