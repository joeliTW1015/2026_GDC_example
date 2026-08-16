using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>第 4 章 TODO 4-A 的參考解答。</summary>
public class Ch4_PlayerMove_Answer : MonoBehaviour
{
    [Header("移動")]
    public float moveSpeed = 6f;
    public float jumpForce = 11f;

    [Header("地面偵測")]
    public float feetOffset = 0.6f;
    public float checkDistance = 0.15f;
    public LayerMask groundLayers;

    Rigidbody2D rb;

    void Awake() { rb = GetComponent<Rigidbody2D>(); }

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

    bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * feetOffset;
        Debug.DrawRay(origin, Vector2.down * checkDistance, Color.red);

        // 解答 4-A
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkDistance, groundLayers);
        return hit.collider != null;
    }
}
