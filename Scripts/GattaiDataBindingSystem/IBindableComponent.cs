namespace GattaiDataBindingSystem
{
    /// <summary>
    /// Defines the interface for a component that can be bound to a <see cref="IBindableVariable"/>.
    /// </summary>
    public interface IBindableComponent
    {
        /// <summary>
        /// Binds the specified <see cref="IBindableVariable"/> to this component.
        /// </summary>
        /// <param name="bindableVariable">The <see cref="IBindableVariable"/> to bind to this component.</param>
        public void Bind(IBindableVariable bindableVariable);
    }
}