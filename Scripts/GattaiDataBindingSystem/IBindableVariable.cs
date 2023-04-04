using System;
using UnityEngine;

namespace GattaiDataBindingSystem
{
    /// <summary>
    /// Defines the interface for a variable that can be bound to one or more <see cref="IBindableComponent"/>s.
    /// </summary>
    public interface IBindableVariable
    {
        /// <summary>
        /// Occurs when the value of the <see cref="IBindableVariable"/> has changed.
        /// </summary>
        event Action OnValueChanged;
        
        /// <summary>
        /// Binds the specified <see cref="Component"/>s to this variable.
        /// </summary>
        /// <param name="components">The <see cref="Component"/>s to bind to this variable.</param>
        void Bind(params Component[] components);
    }
}