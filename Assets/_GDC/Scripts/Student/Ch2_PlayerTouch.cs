using UnityEngine;

/// <summary>
/// 第 2 章練習：用 Tag 分辨「碰到的是什麼東西」。
///
/// Tag 回答的是「這是什麼」；第 3 章的 Layer 回答的是「誰能碰到誰」。
/// </summary>
public class Ch2_PlayerTouch : MonoBehaviour
{
    [Header("分數設定")]
    [Tooltip("吃到一枚金幣加幾分")]
    public int coinScore = 1;
    [Tooltip("踩到尖刺扣幾分")]
    public int spikePenalty = 2;

    Respawner respawner;

    void Awake()
    {
        respawner = GetComponent<Respawner>();
    }

    // 只要碰到「Is Trigger 有打勾」的碰撞器，Unity 就會呼叫這個函式
    void OnTriggerEnter2D(Collider2D other)
    {
        var gm = GameManager.Instance;

        // ────────── TODO 2-A ──────────
        // 碰到 Tag 是 Coin 的東西 → 加 coinScore 分，並讓那枚金幣消失。
        // 提示：if (other.CompareTag("Coin")) { gm.AddScore(coinScore); Destroy(other.gameObject); }
        //  ⚠ 如果出現「Tag: Coin is not defined」錯誤，
        //    代表你還沒在 Project Settings 建立這個 Tag。


        // ────────── TODO 2-B ──────────
        // 碰到 Tag 是 Spike 的東西 → 扣 spikePenalty 分，並回到起點。
        // 提示：回到起點用 respawner.Respawn();


        // ────────── TODO 2-C ──────────
        // 碰到 Tag 是 Goal 的東西 → 過關。
        // 提示：gm.Clear("過關！你學會 Tag 了");

    }
}
