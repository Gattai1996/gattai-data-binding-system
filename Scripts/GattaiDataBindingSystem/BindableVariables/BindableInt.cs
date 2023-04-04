using UnityEngine;

namespace GattaiDataBindingSystem.BindableVariables
{
    /// <summary>
    /// This class represents a bindable variable that holds a int value. It derives from the <see cref="BindableVariable{T}"/> class,
    /// and defines no additional members.
    /// </summary>
    [CreateAssetMenu(menuName = "Bindable Variables/Int")]
    public class BindableInt : BindableVariable<int>
    {
        
    }
}