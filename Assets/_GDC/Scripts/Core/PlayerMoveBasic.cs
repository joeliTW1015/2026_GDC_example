using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 完整可用的基本移動腳本（第 1 章與第 4 章的答案合起來）。
/// 第 5、6 章直接用這支，讓你專心在該章的主題上。
/// </summary>
public class PlayerMoveBasic : MonoBehaviour
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

    public bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * feetOffset;
        return Physics2D.Raycast(origin, Vector2.down, checkDistance, groundLayers).collider != null;
    }
}
