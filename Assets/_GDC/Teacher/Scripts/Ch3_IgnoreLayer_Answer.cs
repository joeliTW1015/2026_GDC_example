using UnityEngine;

/// <summary>
/// 第 3 章練習 2 的參考解答。
/// 學生的做法是到 Project Settings > Physics 2D 取消勾選碰撞矩陣；
/// 教師版為了不動到專案設定（那是全域的，會影響學生版），
/// 改成執行時用程式做同一件事。效果一樣。
/// </summary>
public class Ch3_IgnoreLayer_Answer : MonoBehaviour
{
    void Awake()
    {
        int player = LayerMask.NameToLayer("Player");
        int ghost  = LayerMask.NameToLayer("GhostWall");
        if (player >= 0 && ghost >= 0)
            Physics2D.IgnoreLayerCollision(player, ghost, true);
    }
}
