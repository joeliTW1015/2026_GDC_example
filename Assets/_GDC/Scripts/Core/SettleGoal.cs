using UnityEngine;

/// <summary>
/// 目標區：指定的物件停留在區域內且幾乎靜止一段時間，就算過關。
/// 用「直接指定物件」而不是 Tag，因為 Tag 是第 2 章才教的內容。
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class SettleGoal : MonoBehaviour
{
    [Header("過關條件")]
    [Tooltip("要停進來的物件")]
    public Rigidbody2D targetBody;
    [Tooltip("速度小於這個值才算靜止")]
    public float stillSpeed = 0.4f;
    [Tooltip("要連續靜止幾秒才過關")]
    public float holdSeconds = 0.8f;

    [Header("過關訊息")]
    public string clearMessage = "過關！球成功停在籃子裡";

    float timer;
    bool inside;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (targetBody != null && other.attachedRigidbody == targetBody) inside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (targetBody != null && other.attachedRigidbody == targetBody) { inside = false; timer = 0f; }
    }

    void Update()
    {
        if (targetBody == null) return;

        // 進到區域內、而且速度夠慢，才開始累計時間
        bool still = inside && targetBody.linearVelocity.magnitude < stillSpeed;
        timer = still ? timer + Time.deltaTime : 0f;

        if (timer >= holdSeconds && GameManager.Instance != null)
            GameManager.Instance.Clear(clearMessage);
    }
}
