using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed;

    public void Move()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * speed * Time.fixedDeltaTime);
        //rigidbody.linearVelocity = new Vector2(horizontal * speed, rigidbody.linearVelocityY);
    }
}
