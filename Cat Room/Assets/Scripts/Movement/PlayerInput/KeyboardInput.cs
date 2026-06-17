using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Vector2 GetInput()
    {
        return InputManager.Instance.inputActions.FindAction("Move").ReadValue<Vector2>();
    }
}
