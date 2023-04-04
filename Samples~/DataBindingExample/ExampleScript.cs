using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Bearich.ShamanStory
{
    /// <summary>
    /// This class provides an example of how to use the two-way data binding system to bind a BindableVariable
    /// to different types of UI components.
    /// </summary>
    public class ExampleScript : MonoBehaviour
    {
        public InputField inputField;
        public Text text;
        public TMP_InputField tmpInputField;
        public TextMeshProUGUI tmpText;
        public BindableVariable<string> myStringVariable;

        private void Start()
        {
            myStringVariable.Bind(inputField, tmpInputField, tmpText, text);
        }

        [ContextMenu("Set value")]
        public void SetValue()
        {
            myStringVariable.value = GUID.Generate().ToString();
        }
    }
}