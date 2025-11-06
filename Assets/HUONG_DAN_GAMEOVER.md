# Hướng Dẫn Setup Canvas GameOver

## ✅ Code đã được cập nhật:
- ✅ `GameManager.cs` - Đã thêm logic hiển thị GameOver canvas khi player chết

---

## 📋 Các Bước Thực Hiện Trên Unity Editor:

### **Bước 1: Kiểm Tra Canvas GameOver**

1. **Mở Scene 1-1** trong Unity Editor

2. **Tìm Canvas GameOver trong Hierarchy:**
   - Canvas này đã được tạo sẵn (theo như bạn đã nói)
   - Tên GameObject phải là: **`GameOver`** (QUAN TRỌNG: tên chính xác!)
   - Nếu tên khác, đổi tên thành `GameOver` hoặc gán vào Inspector

3. **Kiểm tra Canvas GameOver:**
   - Canvas có component Canvas không?
   - Canvas có được bật (active) không?
   - **QUAN TRỌNG**: Canvas nên bị **TẮT (inactive)** ban đầu để ẩn khi game bắt đầu

### **Bước 2: Setup Button Main Menu**

1. **Tìm Button Main Menu trong Canvas GameOver:**
   - Mở Canvas GameOver trong Hierarchy
   - Tìm Button có tên "Main Menu" (hoặc tên tương tự)

2. **Cấu hình Button:**
   - Chọn Button trong Hierarchy
   - Trong Inspector, tìm **On Click ()** section
   - Click nút **+** để thêm event mới
   - Kéo GameObject có **GameManager** component vào Object field
   - Trong dropdown, chọn: **GameManager → LoadMainMenu()**

### **Bước 3: Gán Canvas GameOver vào GameManager (Tùy chọn)**

**Cách 1: Gán thủ công (Khuyến nghị):**
1. Tìm GameObject có **GameManager** component trong Hierarchy
   - Thường là GameObject riêng hoặc trong Canvas
2. Chọn GameObject đó
3. Trong Inspector, tìm field **Game Over Panel**
4. Kéo **Canvas GameOver** từ Hierarchy vào field này

**Cách 2: Để tự động tìm (Nếu không gán):**
- Code sẽ tự động tìm GameObject có tên "GameOver"
- Đảm bảo tên chính xác là **`GameOver`**

### **Bước 4: Đảm Bảo Canvas GameOver Bị Ẩn Ban Đầu**

1. **Chọn Canvas GameOver** trong Hierarchy
2. **Trong Inspector**, đảm bảo:
   - Checkbox ở đầu Inspector (kế bên tên GameObject) phải **TẮT (unchecked)**
   - Điều này sẽ ẩn Canvas khi game bắt đầu

### **Bước 5: Test GameOver**

1. **Chạy Game** (Play mode)

2. **Test các trường hợp:**
   - Chơi game và chết nhiều lần để hết lives
   - Khi hết lives, Canvas GameOver sẽ hiện ra
   - Game sẽ bị freeze (dừng lại)
   - Click button Main Menu → quay về Main Menu

---

## 🔧 Cấu Hình Chi Tiết Button Main Menu:

### **Cách 1: Sử dụng GameManager.LoadMainMenu() (Khuyến nghị)**

**Trong Inspector của Button:**
```
On Click ()
└── [0] 
    ├── Object: [Kéo GameManager GameObject vào đây]
    └── Function: GameManager → LoadMainMenu()
```

### **Cách 2: Tạo script riêng cho Button**

Nếu bạn muốn tạo script riêng:

1. **Tạo script mới** (ví dụ: `MainMenuButton.cs`)
2. **Code:**
```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Đảm bảo không bị freeze
        SceneManager.LoadScene(0); // Hoặc tên scene MainMenu
    }
}
```
3. **Gắn script vào Button**
4. **Trong On Click, chọn: MainMenuButton → GoToMainMenu()**

---

## ⚠️ Lưu Ý Quan Trọng:

1. **Tên GameObject:**
   - Canvas GameOver phải có tên **`GameOver`** (nếu dùng auto-find)
   - HOẶC gán vào Inspector GameManager

2. **Canvas phải bị ẩn ban đầu:**
   - Uncheck checkbox ở đầu Inspector
   - Để inactive khi game bắt đầu

3. **Scene Main Menu:**
   - Trong `LoadMainMenu()`, code đang load scene index 0
   - Nếu Main Menu không phải scene 0, sửa thành:
     - `SceneManager.LoadScene("MainMenu")` (nếu có tên)
     - HOẶC đổi scene index trong Build Settings

4. **Time.timeScale:**
   - Game sẽ bị freeze khi GameOver (Time.timeScale = 0f)
   - Button Main Menu sẽ reset về 1f khi click

5. **Lives hệ thống:**
   - GameOver chỉ hiện khi **hết lives** (lives = 0)
   - Nếu còn lives, game sẽ reset level thay vì hiện GameOver

---

## 🎯 Checklist Hoàn Thành:

- [ ] Canvas GameOver đã được tạo trong scene 1-1
- [ ] Canvas GameOver có tên là "GameOver" hoặc đã được gán vào GameManager
- [ ] Canvas GameOver bị ẩn (inactive) ban đầu
- [ ] Button Main Menu đã được cấu hình On Click
- [ ] Button Main Menu gọi GameManager.LoadMainMenu()
- [ ] Đã test: chết hết lives → GameOver hiện ra
- [ ] Đã test: click Main Menu → quay về Main Menu

---

## 📝 Troubleshooting:

**Vấn đề: GameOver không hiện khi chết**
- ✅ Kiểm tra lives đã về 0 chưa? (GameOver chỉ hiện khi hết lives)
- ✅ Kiểm tra Console có warning "GameOver Canvas not found" không?
- ✅ Kiểm tra Canvas GameOver có tên đúng "GameOver" không?
- ✅ Kiểm tra Canvas GameOver có được gán vào GameManager không?

**Vấn đề: Button Main Menu không hoạt động**
- ✅ Kiểm tra On Click đã được cấu hình chưa?
- ✅ Kiểm tra có kéo đúng GameManager GameObject vào không?
- ✅ Kiểm tra có chọn đúng function LoadMainMenu() không?
- ✅ Kiểm tra Console có lỗi gì không?

**Vấn đề: Game vẫn chạy sau khi GameOver**
- ✅ Kiểm tra Time.timeScale có được set về 0f trong GameOver() không?
- ✅ Kiểm tra Console có log gì không?

**Vấn đề: Scene Main Menu không load**
- ✅ Kiểm tra scene index trong Build Settings
- ✅ Kiểm tra tên scene Main Menu có đúng không?
- ✅ Sửa code trong LoadMainMenu() nếu cần

---

## 🔄 Nếu Muốn Hiện GameOver Ngay Khi Chết (Không Cần Hết Lives):

Nếu bạn muốn hiện GameOver ngay khi player chết (không cần chờ hết lives), sửa trong `ResetLevel()`:

```csharp
public void ResetLevel()
{
    CheckAndSaveHighScore();
    lives--;
    score = 0;
    coins = 0;

    // Hiện GameOver ngay khi chết
    GameOver();
    
    // HOẶC giữ logic hiện tại (chỉ hiện khi hết lives)
    // if (lives > 0) { ... } else { GameOver(); }
}
```

---

Chúc bạn thành công! 🎮

