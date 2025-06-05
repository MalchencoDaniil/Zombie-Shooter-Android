using UnityEngine;
using UnityEngine.UI;


public class InputHandler : MonoBehaviour
{
    public enum InputType
    {
        PC,
        Android
    }

    public InputType currentType;

    [ConditionalHide("currentType", InputType.Android)]
    public Button _leftControlButtonUI;

    [ConditionalHide("currentType", InputType.Android)]
    public Button _rightControlButtonUI;
}