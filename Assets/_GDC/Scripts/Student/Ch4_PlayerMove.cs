using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 第 4 章練習：用 Raycast 判斷腳下有沒有地板，修好「無限連跳」。
/// 移動與跳躍的部分已經幫你寫好了（就是第 1 章的答案），
/// 你只要完成 IsGrounded()。
/// </summary>
public class Ch4_PlayerMove : MonoBehaviour
{
    [Header("移動")]
    public float moveSpeed = 6f;
    public float jumpForce = 11f;

    [Header("地面偵測")]
    [Tooltip("射線起點要往下移多少（大約是身體的一半高）")]
    public float feetOffset = 0.6f;
    [Tooltip("射線長度。太短會跳不起來，太長會在空中也能跳")]
    public float checkDistance = 0.15f;
    [Tooltip("哪些圖層算是地板？請勾選 Ground")]
    public LayerMask groundLayers;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float move = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  move = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) move =  1f;
        rb.linearVelocityX = move * moveSpeed;

        if (kb.spaceKey.wasPressedThisFrame && IsGrounded())
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>腳下有沒有踩到地板？</summary>
    bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * feetOffset;

        // 把射線畫在 Scene 視窗裡，方便你看清楚它射到哪
        Debug.DrawRay(origin, Vector2.down * checkDistance, Color.red);

        // ────────── TODO 4-A ──────────
        // 從 origin 往下射一條長度 checkDistance 的射線，
        // 只偵測 groundLayers。有打到東西就回傳 true。
        // 提示：
        //   RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkDistance, groundLayers);
        //   return hit.collider != null;
        //  ⚠ 別忘了在 Inspector 把 Ground Layers 勾成 Ground。


        return true;   // ← 還沒寫之前永遠回傳 true，所以現在可以無限連跳
    }
}
