# 第 6 章 · 自由創作

**這一章沒有標準答案。** 起點在左邊、終點在右邊，中間的路要你自己蓋。

場景：`Assets/_GDC/Scenes/Ch6_Create.unity`

畫面下方是**素材倉庫**：選一個物件按 `Ctrl+D` 複製，再拖到你要的位置。
移動腳本已經幫你裝好了，直接可以跑跳。

---

## 怎麼建立自己的腳本

1. 在 Project 視窗的 `Assets/_GDC/Scripts/Student/` 上按右鍵
2. **Create > MonoBehaviour Script**（或 C# Script）
3. 取一個**沒有空格、不用中文**的名字，例如 `MovingPlatform`
4. ⚠️ **檔名一定要和裡面的 class 名稱一模一樣**，不然掛不上去
5. 寫完存檔，回 Unity 等編譯完，再把腳本拖到物件上

---

## 五個挑戰

### 1. 會來回移動的平台

複製 **Sample_Platform**，寫一支腳本讓它在兩點之間來回。

<details><summary>提示</summary>

```csharp
public float distance = 4f;   // 來回的距離
public float speed = 2f;

Vector3 startPos;
void Start() { startPos = transform.position; }

void Update()
{
    float x = Mathf.PingPong(Time.time * speed, distance);
    transform.position = startPos + new Vector3(x, 0f, 0f);
}
```
`Mathf.PingPong` 會產生 0 → distance → 0 → distance 的來回數值。
想垂直移動就把 `x` 換到 y。
</details>

### 2. 可以推的箱子（不用寫程式）

複製 **Sample_Box**。要能被推動，Rigidbody 2D 的 **Body Type** 要是 **Dynamic**。

試試看調 **Mass**（太重推不動、太輕像紙箱），
再把 `Assets/_GDC/Physics/` 裡的材質拖到 Collider 的 Material 比較差異。

### 3. 彈簧墊

做一個 Trigger 區域，玩家碰到就被彈飛。

<details><summary>提示</summary>

```csharp
public float power = 18f;

void OnTriggerEnter2D(Collider2D other)
{
    Rigidbody2D rb = other.attachedRigidbody;
    if (rb == null) return;

    rb.linearVelocityY = 0f;                              // 先歸零，彈跳才穩定
    rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
}
```
物件上的 Collider 記得勾 **Is Trigger**。
</details>

### 4. 巡邏敵人（會用到 Raycast）

一個會左右走的敵人，用射線偵測前方有沒有牆或懸崖，有就轉頭。

<details><summary>提示</summary>

```csharp
public float speed = 2f;
public float checkDistance = 0.6f;
public LayerMask groundLayers;      // 記得在 Inspector 勾 Ground

int dir = 1;
Rigidbody2D rb;
void Awake() { rb = GetComponent<Rigidbody2D>(); }

void Update()
{
    Vector2 pos = transform.position;

    // 前方有牆？
    bool wall = Physics2D.Raycast(pos, Vector2.right * dir, checkDistance, groundLayers);
    // 前方地板到底了？（往前下方射，射不到就是懸崖）
    bool edge = Physics2D.Raycast(pos + Vector2.right * dir * 0.5f,
                                  Vector2.down, 1.5f, groundLayers);

    if (wall || !edge) dir = -dir;

    rb.linearVelocityX = speed * dir;
}
```
</details>

### 5. 自己設計一個機關

任何東西都可以：傳送門、會掉下來的地板、追著你跑的敵人、限時關卡⋯⋯

---

## 檢查清單

做完後自己確認：

- [ ] 玩家從起點可以一路走到終點
- [ ] 至少用到一個「自己寫的腳本」
- [ ] 至少用到一次 Tag 或 Layer
- [ ] 至少用到一次 Raycast
- [ ] 有一個地方讓玩家會失敗（掉下去、被打到）
- [ ] 給旁邊的人玩過，他不用你解說就知道要幹嘛

---

## 常見問題

**Q：腳本拖不上物件？**
A：檔名和 class 名稱不一樣。`MovingPlatform.cs` 裡面就要是 `public class MovingPlatform`。

**Q：移動平台上的玩家會滑掉？**
A：平台的 Rigidbody 2D 用 **Kinematic** + `rb.MovePosition()` 移動，
比直接改 `transform.position` 穩定很多。

**Q：新物件掉下去不見了？**
A：它沒有 Collider，或者地板沒有 Collider。

**Q：想從頭來過？**
A：**GDC > 重建章節 > 第 6 章** 會還原成初始狀態（你做的東西會不見，先想清楚）。

---

## 做完之後

恭喜，你已經會了 Unity 2D 最核心的四件事：**物理、Raycast、Tag、Layer**。

接下來可以看的方向：

- **Tilemap** — 用畫的方式蓋關卡，比一塊一塊拖快很多
- **Animator** — 讓角色有走路、跳躍動畫
- **Cinemachine** — 更專業的攝影機控制
- **Audio** — 加音效與配樂

回到 [總覽](README.md)
