# Hướng Dẫn Setup Màn Hình Congratulation

## ✅ Code đã được cập nhật:
- ✅ `GameManager.cs` - Đã thêm logic hiển thị Congratulation khi hoàn thành map 1-3
- ✅ `FlagPole.cs` - Đã cập nhật để gọi LevelComplete() thay vì LoadLevel() trực tiếp

---

## 📋 Các Bước Thực Hiện Trên Unity Editor:

### **Bước 1: Tạo Canvas Congratulation**

1. **Mở Scene 1-3** (scene map cuối cùng)

2. **Tạo Canvas mới:**
   - Right-click trong **Hierarchy** → **UI → Canvas**
   - Đặt tên: **`Congratulation`** (QUAN TRỌNG: tên chính xác!)

3. **Cấu hình Canvas:**
   - **Canvas Component:**
     - Render Mode: **Screen Space - Overlay** (mặc định)
   - **Canvas Scaler:**
     - UI Scale Mode: **Scale With Screen Size**
     - Reference Resolution: **1920 x 1080** (hoặc tùy theo project)

### **Bước 2: Tạo UI Elements trong Canvas Congratulation**

1. **Tạo Background Panel (Tùy chọn):**
   - Right-click **Congratulation** → **UI → Image**
   - Đặt tên: `Background`
   - **Image Component:**
     - Color: Đen với Alpha ~200 (màu nền tối)
     - RectTransform: Stretch để phủ toàn màn hình

2. **Tạo Text "Congratulations!":**
   - Right-click **Congratulation** → **UI → Text - TextMeshPro**
   - Đặt tên: `TitleText`
   - **TextMeshProUGUI Component:**
     - Text: `CONGRATULATIONS!` hoặc `YOU WIN!`
     - Font Size: 72-96 (tùy kích thước màn hình)
     - Alignment: Center
     - Color: Vàng hoặc vàng cam (nổi bật)
     - Font Style: Bold
   - **RectTransform:**
     - Anchors: Middle-Center
     - Position Y: 100-150 (phía trên)

3. **Tạo Text điểm số (Tùy chọn):**
   - Right-click **Congratulation** → **UI → Text - TextMeshPro**
   - Đặt tên: `ScoreText`
   - **TextMeshProUGUI Component:**
     - Text: `Final Score: 000000` (sẽ được cập nhật bằng code)
     - Font Size: 36-48
     - Alignment: Center
     - Color: Trắng
   - **RectTransform:**
     - Anchors: Middle-Center
     - Position Y: 0 (giữa màn hình)

4. **Tạo Button "Main Menu":**
   - Right-click **Congratulation** → **UI → Button - TextMeshPro**
   - Đặt tên: `MainMenuButton`
   - **Button Component:**
     - Interactable: ✓ (checked)
   - **TextMeshProUGUI (trong Button):**
     - Text: `MAIN MENU`
     - Font Size: 36-48
     - Alignment: Center
     - Color: Trắng hoặc đen (tùy background button)
   - **RectTransform:**
     - Anchors: Middle-Center
     - Position Y: -150 đến -200 (phía dưới)
     - Width: 200-300
     - Height: 60-80

### **Bước 3: Setup Button Main Menu**

1. **Chọn Button "MainMenuButton"** trong Hierarchy

2. **Trong Inspector, tìm section "On Click ()":**
   - Click nút **+** để thêm event mới
   - Kéo GameObject có **GameManager** component vào Object field
   - Trong dropdown, chọn: **GameManager → LoadMainMenu()**

### **Bước 4: Gán Canvas Congratulation vào GameManager (Tùy chọn)**

**Cách 1: Gán thủ công (Khuyến nghị):**
1. Tìm GameObject có **GameManager** component trong Hierarchy
2. Chọn GameObject đó
3. Trong Inspector, tìm field **Congratulation Panel**
4. Kéo **Canvas Congratulation** từ Hierarchy vào field này

**Cách 2: Để tự động tìm (Nếu không gán):**
- Code sẽ tự động tìm GameObject có tên "Congratulation"
- Đảm bảo tên chính xác là **`Congratulation`**

### **Bước 5: Đảm Bảo Canvas Congratulation Bị Ẩn Ban Đầu**

1. **Chọn Canvas Congratulation** trong Hierarchy
2. **Trong Inspector**, đảm bảo:
   - Checkbox ở đầu Inspector (kế bên tên GameObject) phải **TẮT (unchecked)**
   - Điều này sẽ ẩn Canvas khi game bắt đầu

### **Bước 6: Test Congratulation Screen**

1. **Chạy Game** (Play mode)

2. **Test các trường hợp:**
   - Chơi game và hoàn thành map 1-1 → không hiện congratulation (load map tiếp)
   - Chơi game và hoàn thành map 1-2 → không hiện congratulation (load map tiếp)
   - Chơi game và hoàn thành map 1-3 → **Congratulation screen hiện ra!**
   - Click button Main Menu → quay về Main Menu

---

## 🎨 Gợi Ý Thiết Kế UI:

### **Layout Mẫu:**
```
┌─────────────────────────────┐
│  [Background - Màu đen/tối] │
│                             │
│      CONGRATULATIONS!       │
│         YOU WIN!            │
│                             │
│    Final Score: 000000      │
│                             │
│      [MAIN MENU]            │
│                             │
└─────────────────────────────┘
```

### **Màu Sắc Gợi Ý:**
- **Title Text**: Vàng (#FFD700) hoặc Vàng cam (#FFA500)
- **Background**: Đen với Alpha 220-240 (mờ một chút)
- **Button**: Xanh lá (#00FF00) hoặc màu nổi bật
- **Score Text**: Trắng (#FFFFFF)

---

## 🔧 Cấu Hình Nâng Cao (Tùy chọn):

### **Nếu Muốn Hiển Thị Điểm Số Trên Congratulation Screen:**

1. **Tạo script mới** để cập nhật điểm số (hoặc dùng UIManager):

```csharp
// Trong UIManager.cs hoặc tạo script mới
using TMPro;
using UnityEngine;

public class CongratulationUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            if (scoreText != null)
                scoreText.text = "Final Score: " + GameManager.Instance.score.ToString("000000");
            
            if (highScoreText != null)
                highScoreText.text = "High Score: " + GameManager.Instance.highScore.ToString("000000");
        }
    }
}
```

2. **Gắn script vào Canvas Congratulation**
3. **Gán các Text fields vào script**

### **Nếu Muốn Thêm Animation:**

1. **Thêm Animation component** vào Canvas Congratulation
2. **Tạo animation** cho fade in, scale, v.v.
3. **Play animation** khi Canvas được kích hoạt

---

## ⚠️ Lưu Ý Quan Trọng:

1. **Tên GameObject:**
   - Canvas Congratulation phải có tên **`Congratulation`** (nếu dùng auto-find)
   - HOẶC gán vào Inspector GameManager

2. **Canvas phải bị ẩn ban đầu:**
   - Uncheck checkbox ở đầu Inspector
   - Để inactive khi game bắt đầu

3. **Map 1-3:**
   - Congratulation chỉ hiện khi hoàn thành **world 1, stage 3**
   - Nếu hoàn thành các map khác, game sẽ load level tiếp theo

4. **Time.timeScale:**
   - Game sẽ bị freeze khi Congratulation hiện (Time.timeScale = 0f)
   - Button Main Menu sẽ reset về 1f khi click

5. **FlagPole trong map 1-3:**
   - Đảm bảo FlagPole có `nextWorld` và `nextStage` được set đúng
   - Code sẽ tự động phát hiện nếu là map 1-3

---

## 🎯 Checklist Hoàn Thành:

- [ ] Canvas Congratulation đã được tạo trong scene 1-3
- [ ] Canvas Congratulation có tên là "Congratulation" hoặc đã được gán vào GameManager
- [ ] Canvas Congratulation bị ẩn (inactive) ban đầu
- [ ] Đã tạo Text "Congratulations!" hoặc "You Win!"
- [ ] Đã tạo Button Main Menu
- [ ] Button Main Menu đã được cấu hình On Click
- [ ] Button Main Menu gọi GameManager.LoadMainMenu()
- [ ] Đã test: hoàn thành map 1-3 → Congratulation hiện ra
- [ ] Đã test: click Main Menu → quay về Main Menu

---

## 📝 Troubleshooting:

**Vấn đề: Congratulation không hiện khi hoàn thành map 1-3**
- ✅ Kiểm tra Console có warning "Congratulation Canvas not found" không?
- ✅ Kiểm tra Canvas Congratulation có tên đúng "Congratulation" không?
- ✅ Kiểm tra Canvas Congratulation có được gán vào GameManager không?
- ✅ Kiểm tra map hiện tại có đúng là world=1, stage=3 không?
- ✅ Kiểm tra FlagPole có gọi LevelComplete() không?

**Vấn đề: Congratulation hiện ở map khác (không phải 1-3)**
- ✅ Kiểm tra logic trong LevelComplete() có đúng không?
- ✅ Kiểm tra world và stage values trong GameManager

**Vấn đề: Button Main Menu không hoạt động**
- ✅ Kiểm tra On Click đã được cấu hình chưa?
- ✅ Kiểm tra có kéo đúng GameManager GameObject vào không?
- ✅ Kiểm tra có chọn đúng function LoadMainMenu() không?

**Vấn đề: Game vẫn chạy sau khi Congratulation hiện**
- ✅ Kiểm tra Time.timeScale có được set về 0f trong ShowCongratulation() không?
- ✅ Kiểm tra Console có log gì không?

---

## 🔄 Nếu Muốn Thay Đổi Map Chiến Thắng:

Nếu muốn congratulation hiện ở map khác (ví dụ: 2-3, 3-5, v.v.), sửa trong `LevelComplete()`:

```csharp
// Trong GameManager.cs
public void LevelComplete(int nextWorld, int nextStage)
{
    CheckAndSaveHighScore();
    
    // Thay đổi điều kiện ở đây
    if (world == 2 && stage == 3) // Ví dụ: map 2-3
    {
        ShowCongratulation();
    }
    else if (world == 1 && stage == 3) // Hoặc map 1-3
    {
        ShowCongratulation();
    }
    else
    {
        LoadLevel(nextWorld, nextStage);
    }
}
```

---

Chúc bạn thành công! 🎮🎉

