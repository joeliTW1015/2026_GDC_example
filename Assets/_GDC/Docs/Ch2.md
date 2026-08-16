# 第 2 章 · 標籤 Tag

目標：吃光所有金幣、避開紅色尖刺、走到終點。

場景：`Assets/_GDC/Scenes/Ch2_Tag.unity`
要改的檔案：`Assets/_GDC/Scripts/Student/Ch2_PlayerTouch.cs`

> 這一章會用到你在第 1 章寫的 `Ch1_PlayerMove.cs`。如果那支還沒寫完，先回去補。

---

## Tag 是什麼

Tag 就是**貼在物件上的一張名牌**，讓程式可以問：「我碰到的這個東西，是什麼？」

金幣、尖刺、終點長得不一樣，但對程式來說它們都只是「一個 Collider」。
有了 Tag，程式才知道該加分、該扣血，還是該過關。

---

## 任務一：把 Tag 指派給物件

場景裡的金幣、尖刺、終點目前都是 **Untagged**。

1. 在 Hierarchy 點選一枚**金幣**
2. Inspector **最上方**有個 `Tag` 下拉選單，選 **Coin**
3. 其他五枚金幣也一樣（可以按住 `Ctrl` 一次選多個，一起改）
4. 兩根**尖刺** → `Spike`
5. **終點** → `Goal`

---

## 任務二：把三個 TODO 填完

```csharp
if (other.CompareTag("Coin"))
{
    gm.AddScore(coinScore);
    Destroy(other.gameObject);
}
```

`other` 是「碰到我的那個東西」，`other.gameObject` 就是它本身，`Destroy` 把它刪掉。

尖刺和終點請自己照樣寫，提示都在註解裡。

---

## 觀念：為什麼要用 CompareTag？

你可能會想這樣寫：

```csharp
if (other.tag == "Coin")     // 可以動，但不建議
```

用 `CompareTag` 有兩個好處：

1. **比較快**（不會產生垃圾記憶體）
2. **拼錯字會直接報錯**告訴你「這個 Tag 不存在」

用 `==` 的話，你把 `"Coin"` 打成 `"Coln"`，程式不會報錯，只會安靜地永遠不成立 ——
你可能要找半小時才發現。

---

## 觀念：OnTriggerEnter2D 什麼時候會被呼叫？

要同時滿足三個條件：

1. 兩個物件都有 **Collider 2D**
2. 其中至少一個 Collider 勾了 **Is Trigger**
3. 其中至少一個物件有 **Rigidbody 2D**

金幣沒反應時，就照這三點檢查。

---

## 加分題（這題會用到「自己新增 Tag」）

1. Edit > Project Settings > Tags and Layers > Tags，按 `+` 新增一個 **Bonus**
2. 複製一枚金幣（`Ctrl+D`），把 Tag 改成 Bonus，顏色改成別的
3. 在腳本裡加一段「碰到 Bonus 加 5 分」

其他挑戰：

- 讓尖刺不只扣分，還把分數歸零
- 加一個「必須吃滿 6 分才能過關」的判斷（提示：`if (gm.score >= 6)`）

---

## 常見問題

**Q：`Tag: Coin is not defined`**
A：拼錯字了。Tag 有大小寫之分，`coin` 和 `Coin` 是不一樣的。

**Q：碰到金幣沒反應？**
A：依序檢查 ① 金幣的 Tag 有沒有指派 ② 金幣的 Collider 有沒有勾 Is Trigger
③ 玩家有沒有 Rigidbody 2D。

**Q：走過尖刺沒事？**
A：尖刺的 Tag 忘了指派，或 TODO 2-B 還沒寫。

**Q：分數不會變？**
A：右上角 HUD 顯示的是 `GameManager.score`。確認你呼叫的是 `gm.AddScore(...)`。

---

卡住了 → `Assets/_GDC/Teacher/Answers/Ch2_PlayerTouch.txt`

下一章 → [Ch3.md](Ch3.md)
