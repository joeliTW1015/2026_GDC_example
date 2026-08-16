using UnityEngine;

/// <summary>
/// 第 4 章練習：雷射感應器。射線打到玩家時，門就升起來。
/// 畫線的部分已經寫好了，你只要完成那一行 Raycast。
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class Ch4_LaserSensor : MonoBehaviour
{
    [Header("射線設定")]
    [Tooltip("射線方向，(0,-1) 是往下")]
    public Vector2 direction = Vector2.down;
    [Tooltip("射線最長射多遠")]
    public float maxDistance = 6f;
    [Tooltip("要偵測哪些圖層？請勾選 Player")]
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
        RaycastHit2D hit = default;

        // ────────── TODO 4-B ──────────
        // 從自己的位置往 dir 射一條長度 maxDistance 的射線，只偵測 detectLayers。
        // 提示：hit = Physics2D.Raycast(transform.position, dir, maxDistance, detectLayers);


        bool detected = hit.collider != null;

        // 畫出雷射：打到東西就畫到接觸點，沒打到就畫滿長度
        float length = detected ? hit.distance : maxDistance;
        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + (Vector3)(dir * length));
        line.startColor = line.endColor = detected ? Color.green : Color.red;

        // 開關門
        if (door != null)
        {
            Vector3 target = detected ? doorClosedPos + Vector3.up * openHeight : doorClosedPos;
            door.position = Vector3.MoveTowards(door.position, target, doorSpeed * Time.deltaTime);
        }
    }
}
