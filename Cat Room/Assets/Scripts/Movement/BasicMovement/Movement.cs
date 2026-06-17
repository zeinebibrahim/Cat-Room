using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 pDirection)
    {
        rigidbody.linearVelocity = pDirection * moveSpeed;
    }
}