using UnityEngine;

/// <summary>第 2 章的參考解答（教師版場景使用）。</summary>
public class Ch2_PlayerTouch_Answer : MonoBehaviour
{
    [Header("分數設定")]
    public int coinScore = 1;
    public int spikePenalty = 2;

    Respawner respawner;

    void Awake()
    {
        respawner = GetComponent<Respawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var gm = GameManager.Instance;

        // 解答 2-A
        if (other.CompareTag("Coin"))
        {
            gm.AddScore(coinScore);
            Destroy(other.gameObject);
        }

        // 解答 2-B
        if (other.CompareTag("Spike"))
        {
            gm.AddScore(-spikePenalty);
            gm.Fail("踩到尖刺了！回到起點");
            respawner.Respawn();
        }

        // 解答 2-C
        if (other.CompareTag("Goal"))
        {
            gm.Clear("過關！你學會 Tag 了");
        }
    }
}
