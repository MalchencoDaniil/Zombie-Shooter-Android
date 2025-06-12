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

    private float _horizontalInput = 0f;

    [ConditionalHide("currentType", InputType.Android)]
    public float _touchSensitivity = 0.01f;

    private void Update()
    {
        _horizontalInput = 0f;

        if (currentType == InputType.Android)
        {
            HandleTouchInput();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                float _touchDeltaX = _touch.deltaPosition.x;

                _horizontalInput = _touchDeltaX * _touchSensitivity;
            }
            else if (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled)
            {
                _horizontalInput = 0f;
            }
        }
    }

    public Vector2 MovementInput()
    {
        if (currentType == InputType.PC)
        {
            return InputManager._instance._inputActions.Player.Movement.ReadValue<Vector2>();
        }
        else
        {
            return new Vector2(_horizontalInput, 0);
        }
    }
}