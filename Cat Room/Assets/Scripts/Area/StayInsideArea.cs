using UnityEngine;

public class StayInsideArea : MonoBehaviour
{
    [SerializeField] private Transform areaCenter;
    [SerializeField] private Vector2 areaSize = new Vector2(5f, 5f);

    private void LateUpdate()
    {
        if (areaCenter == null) return;

        Vector3 pos = transform.position;

        float halfX = areaSize.x * 0.5f;
        float halfY = areaSize.y * 0.5f;

        pos.x = Mathf.Clamp(pos.x, areaCenter.position.x - halfX, areaCenter.position.x + halfX);
        pos.y = Mathf.Clamp(pos.y, areaCenter.position.y - halfY, areaCenter.position.y + halfY);

        transform.position = pos;
    }
}
