using UnityEngine;

/// <summary>
/// 第 3 章練習：用 LayerMask 只偵測「特定圖層」的東西。
/// 玩家靠近時門會升起，走遠了又降下來。
/// </summary>
public class Ch3_ProximityDoor : MonoBehaviour
{
    [Header("偵測設定")]
    [Tooltip("偵測範圍半徑（選取這個物件可以在 Scene 視窗看到圓圈）")]
    public float radius = 3.5f;

    [Tooltip("要偵測哪些圖層？請把 Player 勾起來")]
    public LayerMask detectLayers;

    [Header("門的動作")]
    [Tooltip("門要升多高")]
    public float openHeight = 3.5f;
    [Tooltip("升降速度")]
    public float speed = 8f;

    Vector3 closedPos;

    void Awake()
    {
        closedPos = transform.position;
    }

    void Update()
    {
        bool near = false;

        // ────────── TODO 3-A ──────────
        // 用 Physics2D.OverlapCircle 檢查半徑 radius 內，
        // 有沒有屬於 detectLayers 的碰撞器。有的話 near = true。
        // 提示：near = Physics2D.OverlapCircle(transform.position, radius, detectLayers) != null;
        //  ⚠ 別忘了在 Inspector 把 Detect Layers 勾成 Player，
        //    不然這裡永遠偵測不到東西。


        Vector3 target = near ? closedPos + Vector3.up * openHeight : closedPos;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // 在 Scene 視窗把偵測範圍畫出來，方便調整 radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
