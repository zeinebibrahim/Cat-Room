using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : UnitySingleton<InputManager>

{

    [SerializeField] public InputActionAsset inputActions;

    void OnEnable() => inputActions?.Enable();

    void OnDisable() => inputActions?.Disable();

}