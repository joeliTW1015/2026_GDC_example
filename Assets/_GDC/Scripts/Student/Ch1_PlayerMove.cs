using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 第 1 章練習：讓玩家可以左右移動與跳躍。
///
/// ⚠ 本專案使用「新版 Input System」，所以沒有 Input.GetKeyDown()。
///   鍵盤要用 Keyboard.current，例如 Keyboard.current.dKey.isPressed。
/// </summary>
public class Ch1_PlayerMove : MonoBehaviour
{
    [Header("移動")]
    [Tooltip("左右移動速度（單位 / 秒），試試 3 ~ 12")]
    public float moveSpeed = 6f;

    [Header("跳躍")]
    [Tooltip("跳躍力道，越大跳越高，試試 6 ~ 16")]
    public float jumpForce = 11f;

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

        // ────────── TODO 1-A ──────────
        // 按 A 或 ← 時 move = -1；按 D 或 → 時 move = 1。
        // 提示：kb.aKey.isPressed、kb.leftArrowKey.isPressed
        //      if (???) move = -1f;
        //      if (???) move =  1f;


        // ────────── TODO 1-B ──────────
        // 把水平速度設成 move * moveSpeed。
        // 提示：rb.linearVelocityX = ???
        //  ⚠ Unity 6 把 velocity 改名成 linearVelocity，
        //    網路教學看到的 rb.velocity 在這裡會編譯失敗。


        if (kb.spaceKey.wasPressedThisFrame)
        {
            // ────────── TODO 1-C ──────────
            // 往上加一道「瞬間」的力，讓玩家跳起來。
            // 提示：rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }
}
