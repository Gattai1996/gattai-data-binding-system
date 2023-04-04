using UnityEngine;

namespace GattaiDataBindingSystem
{
    /// <summary>
    /// This abstract class represents a Unity Component that can be bound to a bindable variable.
    /// The class contains two fields that hold references to the bindable variable and the component that is being bound,
    /// and a Bind method that binds the component to the variable.
    /// The class also provides a Start method that automatically binds the component to the variable when the script starts,
    /// and an OnDestroy method that unbinds the component from the variable when the script is destroyed.
    /// </summary>
    /// <typeparam name="TC">The type of the component that this class is bound to.</typeparam>
    /// <typeparam name="TV">The type of the bindable variable that this class is bound to.</typeparam>
    public abstract class BindableComponent<TC, TV> : MonoBehaviour, IBindableComponent where TC : Component where TV : IBindableVariable
    {
        /// <summary>
        /// A reference to the component that this class is bound to.
        /// </summary>
        [SerializeField] private TC component;
        
        /// <summary>
        /// A reference to the bindable variable that this class is bound to.
        /// </summary>
        [SerializeField] private TV variable;

        /// <summary>
        /// Gets or sets the component that this class is bound to.
        /// </summary>
        protected TC Component
        {
            get => component;
            private set => component = value;
        }

        /// <summary>
        /// Gets or sets the bindable variable that this class is bound to.
        /// </summary>
        protected TV BoundVariable
        {
            get => variable;
            private set => variable = value;
        }

        /// <summary>
        /// Automatically binds the component to the variable when the script starts.
        /// </summary>
        protected virtual void Start()
        {
            Component ??= GetComponent<TC>();
            if (BoundVariable == null) return;
            Bind(BoundVariable);
        }

        /// <summary>
        /// Unbinds the component from the variable when the script is destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            BoundVariable.OnValueChanged -= BoundVariable_OnValueChanged;
        }

        /// <summary>
        /// This method is called when the script is loaded or a value is changed in the Inspector (Called in the editor only).
        /// It automatically adds a component of type TC to the game object if it's not already present.
        /// </summary>
        protected virtual void OnValidate()
        {
            if (TryGetComponent<TC>(out var bindableComponent))
            {
                Component ??= bindableComponent;
                return;
            }
        
            Debug.LogError($"The BindableVariable must have a component of type {typeof(TC)} attached to it." +
                           "Adding it automatically.");
        
            Component = gameObject.AddComponent<TC>();
        }

        /// <summary>
        /// Binds the component to the bindable variable.
        /// </summary>
        /// <param name="bindableVariable">The bindable variable to bind the component to.</param>
        public virtual void Bind(IBindableVariable bindableVariable)
        {
            BoundVariable = (TV)bindableVariable;
            
            BoundVariable.OnValueChanged += BoundVariable_OnValueChanged;
            BoundVariable_OnValueChanged();
            
            if (this is ITwoWayDataBinding twoWayDataBinding)
            {
                twoWayDataBinding.BindComponent();
            }
            
            BoundVariable.Bind(this);
        }

        /// <summary>
        /// This method is called whenever the value of the bound variable changes.
        /// </summary>
        protected abstract void BoundVariable_OnValueChanged();
    }
}