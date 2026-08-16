using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>第 1 章的參考解答（教師版場景使用）。學生請改自己的 Ch1_PlayerMove.cs。</summary>
public class Ch1_PlayerMove_Answer : MonoBehaviour
{
    [Header("移動")]
    public float moveSpeed = 6f;

    [Header("跳躍")]
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

        // 解答 1-A
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  move = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) move =  1f;

        // 解答 1-B（Unity 6 的寫法：linearVelocityX）
        rb.linearVelocityX = move * moveSpeed;

        if (kb.spaceKey.wasPressedThisFrame)
        {
            // 解答 1-C
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
