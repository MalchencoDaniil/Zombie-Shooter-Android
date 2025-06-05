using UnityEngine;
using UnityEngine.UI;


public class InputHandler : MonoBehaviour
{
    public enum InputType
    {
        PC,
        Android
    }

    public InputType _currentType;

    private float _horizontalInput = 0f;

    private void Update()
    {
        _horizontalInput = 0f;

        if (_currentType == InputType.Android)
        {
            HandleTouchInput();
        }
    }

    private void HandleTouchInput()
    {

    }

    public Vector2 MovementInput()
    {
        if (_currentType == InputType.PC)
        {
            return InputManager._instance._inputActions.Player.Movement.ReadValue<Vector2>();
        }
        else
        {
            return new Vector2(_horizontalInput, 0);
        }
    }
}