using UnityEngine;

/// <summary>第 4 章 TODO 4-B 的參考解答。</summary>
[RequireComponent(typeof(LineRenderer))]
public class Ch4_LaserSensor_Answer : MonoBehaviour
{
    [Header("射線設定")]
    public Vector2 direction = Vector2.down;
    public float maxDistance = 6f;
    public LayerMask detectLayers;

    [Header("連動的門")]
    public Transform door;
    public float openHeight = 3.6f;
    public float doorSpeed = 8f;

    LineRenderer line;
    Vector3 doorClosedPos;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        if (door != null) doorClosedPos = door.position;
    }

    void Update()
    {
        Vector2 dir = direction.normalized;

        // 解答 4-B
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, maxDistance, detectLayers);

        bool detected = hit.collider != null;

        float length = detected ? hit.distance : maxDistance;
        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + (Vector3)(dir * length));
        line.startColor = line.endColor = detected ? Color.green : Color.red;

        if (door != null)
        {
            Vector3 target = detected ? doorClosedPos + Vector3.up * openHeight : doorClosedPos;
            door.position = Vector3.MoveTowards(door.position, target, doorSpeed * Time.deltaTime);
        }
    }
}
