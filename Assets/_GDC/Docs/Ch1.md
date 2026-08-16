# 第 1 章 · 移動與跳躍

**你的第一支腳本。** 目標是讓玩家走到最右邊的綠色終點。

場景：`Assets/_GDC/Scenes/Ch1_Move.unity`
要改的檔案：`Assets/_GDC/Scripts/Student/Ch1_PlayerMove.cs`

---

## 先玩一次

按 ▶。按 `A` `D` 完全沒反應 —— 因為程式還沒寫。

---

## 任務一：把三個 TODO 填完

用滑鼠雙擊 `Ch1_PlayerMove.cs` 打開它（會用 VS Code 或 Rider 開啟）。
裡面有三段標著 `TODO` 的空白，每一段的下面都有「提示」註解。

### TODO 1-A：讀鍵盤

`move` 這個變數代表「要往哪走」：`-1` 是左、`1` 是右、`0` 是不動。

```csharp
if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  move = -1f;
```

右邊那行請自己照樣寫出來。

### TODO 1-B：設定速度

```csharp
rb.linearVelocityX = move * moveSpeed;
```

⚠️ **不是 `rb.velocity.x`**。Unity 6 改名了，詳見 [README](README.md)。

### TODO 1-C：跳躍

```csharp
rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
```

`ForceMode2D.Impulse` 是「瞬間推一下」，適合跳躍。
如果用 `ForceMode2D.Force`（持續施力），玩家會像坐火箭一樣慢慢升空 —— 可以試試看。

存檔後切回 Unity，等左下角的轉圈圈跑完（那是在編譯），再按 ▶。

---

## 任務二：玩家一直翻倒？

因為膠囊有物理，撞到東西會轉。

修法：選取 **Player** → Rigidbody 2D → 展開 **Constraints** → 勾選 **Freeze Rotation** 的 **Z**。

（2D 遊戲只有 Z 軸會轉，所以只要凍結 Z。）

---

## 任務三：調出好手感

| 參數 | 太小 | 太大 |
|---|---|---|
| **Move Speed** | 走起來很拖 | 難以控制、容易衝過頭 |
| **Jump Force** | 跳不過缺口 | 飛得太高看不到路 |

沒有標準答案。試 5～15 之間，找出你覺得最順的組合。
**這就是遊戲設計裡的「手感調校」，職業開發者也是這樣一個一個試出來的。**

---

## 觀念：Update 是什麼？

`void Update()` 裡的程式碼，Unity **每一幀都會跑一次**（一秒大約 60 次）。
所以「按著 D 就往右移動」不需要寫迴圈 —— Update 本身就是迴圈。

---

## 加分題

1. 加一個「衝刺」：按住 `Shift` 時速度變兩倍
2. 讓玩家面向移動方向（提示：`transform.localScale` 的 x 改成 -1 可以左右翻轉）
3. 跳躍時把顏色改掉（提示：`GetComponent<SpriteRenderer>().color`）

---

## 常見問題

**Q：`Input` does not contain a definition for `GetKeyDown`**
A：本專案只能用新版 Input System，要用 `Keyboard.current`。見 [README](README.md)。

**Q：`Rigidbody2D` does not contain a definition for `velocity`**
A：Unity 6 改名成 `linearVelocity` / `linearVelocityX` 了。

**Q：改完存檔了，但遊戲沒變？**
A：切回 Unity 等它編譯完（右下角有轉圈圈）。如果 Console 有紅字，先修好錯誤。

**Q：可以無限連跳耶？**
A：對，這是**故意留的 bug**。第 4 章會用 Raycast 修好它。

---

卡住了 → `Assets/_GDC/Teacher/Answers/Ch1_PlayerMove.txt`

下一章 → [Ch2.md](Ch2.md)
