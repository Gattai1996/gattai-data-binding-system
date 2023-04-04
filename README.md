# Gattai Data Binding System
Gattai Data Binding System is a Unity package that provides a simple and flexible way to bind data to UI elements in your Unity project.

## Features
- Support for various Unity UI components, including Text, TextMeshProUGUI, InputField, and TMP_InputField.
- Bindable variables that can be used to store and update data.
- Automatic data updating to all bound components whenever a bindable variable changes.
- A simple and intuitive API that makes it easy to bind data to UI elements.

## Installation

### Using OpenUPM
Gattai Data Binding System can be installed using the OpenUPM package manager. First, install the OpenUPM CLI by following the instructions in the OpenUPM documentation. Then, navigate to your Unity project folder in a terminal or command prompt and run the following command:

``openupm add com.brunogattai.gattaidatabindingsystem``

### Using Unity Package Manager

Open your Unity project.
- Open the Package Manager window by selecting Window > Package Manager.
- Click the + button in the upper left corner of the window and select Add package from git URL.
- Enter the following URL and click Add: https://github.com/gattai1996/gattai-data-binding-system.git

## Usage

To use the Gattai Data Binding System in your project, follow these steps:

- Create a bindable variable of the appropriate type for the data you want to bind.
- Call the Bind method on the variable, passing in the UI components you want to bind to.
- Whenever the value of the variable changes, all bound UI components will automatically update to reflect the new value.

Here's an example of how to use Gattai Data Binding System to bind a string value to a TextMeshProUGUI component:

```
using TMPro;
using UnityEngine;
using GattaiDataBindingSystem;

public class ExampleScript : MonoBehaviour
{
public TMP_Text textComponent;
public BindableVariable<string> stringVariable;

    private void Start()
    {
        stringVariable.Bind(textComponent);
    }

    [ContextMenu("Set value")] // Use this option in the context menu to see the TMP_Text changing.
    public void SetValue()
    {
        stringVariable.value = "Hello, world!";
    }
}
```

> ℹ <br> **NOTE:** Download the sample "Data Binding Example" through Package Manager for more examples.

## Documentation

For more detailed documentation on how to use Gattai Data Binding System, please see the Documentation.pdf file.

## License

Gattai Data Binding System is licensed under the **[MIT License](https://pt.wikipedia.org/wiki/Licen%C3%A7a_MIT)**.