using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement => GetComponent<Movement>();
    KeyboardInput keyboardInput => GetComponent<KeyboardInput>();

    private void Update()
    {
        movement.Move(keyboardInput.GetInput());
    }
}
