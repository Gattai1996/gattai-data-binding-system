using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public BindableVariable<string> variable;

    private void Start()
    {
        variable.Bind(text);
    }
}
