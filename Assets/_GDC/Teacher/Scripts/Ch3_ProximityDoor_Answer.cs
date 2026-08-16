using UnityEngine;

/// <summary>第 3 章的參考解答（教師版場景使用）。</summary>
public class Ch3_ProximityDoor_Answer : MonoBehaviour
{
    [Header("偵測設定")]
    public float radius = 3.5f;
    public LayerMask detectLayers;

    [Header("門的動作")]
    public float openHeight = 3.5f;
    public float speed = 8f;

    Vector3 closedPos;

    void Awake()
    {
        closedPos = transform.position;
    }

    void Update()
    {
        // 解答 3-A
        bool near = Physics2D.OverlapCircle(transform.position, radius, detectLayers) != null;

        Vector3 target = near ? closedPos + Vector3.up * openHeight : closedPos;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
