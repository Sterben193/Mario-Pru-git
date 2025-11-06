# Hướng Dẫn Tạo UI GameOver và Congratulation

## 📍 NƠI TẠO UI:

### **1. GameOver Canvas** → Tạo trong Scene 1-1 (hoặc tất cả scene chơi game)
- **Lý do**: Player có thể chết ở bất kỳ scene nào (1-1, 1-2, 1-3)
- **Vị trí**: Scene **1-1** (vì đây là scene chính, GameManager sẽ persist qua các scene)

### **2. Congratulation Canvas** → Tạo trong Scene 1-3
- **Lý do**: Chỉ hiện khi hoàn thành map 1-3
- **Vị trí**: Scene **1-3**

---

## 🎯 CÁC BƯỚC THỰC HIỆN:

### **PHẦN 1: Tạo GameOver Canvas trong Scene 1-1**

#### **Bước 1: Mở Scene 1-1**
1. Trong Unity Editor, mở scene **1-1**
2. File → Open Scene → Chọn `1-1.unity`

#### **Bước 2: Tạo Canvas GameOver**
1. Trong **Hierarchy panel**, right-click vào vùng trống
2. Chọn: **UI → Canvas**
3. Đặt tên GameObject: **`GameOver`** (QUAN TRỌNG: tên chính xác!)
4. **Quan trọng**: Trong Inspector, **TẮT checkbox** ở đầu (để inactive) - Canvas sẽ bị ẩn ban đầu

#### **Bước 3: Tạo UI Elements trong Canvas GameOver**

**3.1. Tạo Background Panel:**
- Right-click **GameOver** → **UI → Image**
- Đặt tên: `Background`
- **Image Component:**
  - Color: Đen với Alpha = 200-240 (màu nền tối)
- **RectTransform:**
  - Click vào preset **Stretch** (góc trên bên phải của RectTransform)
  - Stretch cả 4 phía để phủ toàn màn hình

**3.2. Tạo Text "GAME OVER":**
- Right-click **GameOver** → **UI → Text - TextMeshPro**
- Đặt tên: `GameOverText`
- **TextMeshProUGUI Component:**
  - Text: `GAME OVER`
  - Font Size: 72-96
  - Alignment: Center
  - Color: Đỏ (#FF0000) hoặc Trắng
  - Font Style: Bold
- **RectTransform:**
  - Anchors: Middle-Center
  - Position Y: 100-150 (phía trên)

**3.3. Tạo Button "Main Menu":**
- Right-click **GameOver** → **UI → Button - TextMeshPro**
- Đặt tên: `MainMenuButton`
- **Button Component:**
  - Interactable: ✓ (checked)
- **TextMeshProUGUI (trong Button):**
  - Text: `MAIN MENU`
  - Font Size: 36-48
  - Alignment: Center
- **RectTransform:**
  - Anchors: Middle-Center
  - Position Y: -150 đến -200 (phía dưới)
  - Width: 250
  - Height: 70

**3.4. Setup Button Main Menu:**
- Chọn **MainMenuButton** trong Hierarchy
- Trong Inspector, tìm section **On Click ()**
- Click nút **+** để thêm event
- Kéo GameObject có **GameManager** component vào Object field
- Chọn function: **GameManager → LoadMainMenu()**

---

### **PHẦN 2: Tạo Congratulation Canvas trong Scene 1-3**

#### **Bước 1: Mở Scene 1-3**
1. Trong Unity Editor, mở scene **1-3**
2. File → Open Scene → Chọn `1-3.unity`

#### **Bước 2: Tạo Canvas Congratulation**
1. Trong **Hierarchy panel**, right-click vào vùng trống
2. Chọn: **UI → Canvas**
3. Đặt tên GameObject: **`Congratulation`** (QUAN TRỌNG: tên chính xác!)
4. **Quan trọng**: Trong Inspector, **TẮT checkbox** ở đầu (để inactive) - Canvas sẽ bị ẩn ban đầu

#### **Bước 3: Tạo UI Elements trong Canvas Congratulation**

**3.1. Tạo Background Panel:**
- Right-click **Congratulation** → **UI → Image**
- Đặt tên: `Background`
- **Image Component:**
  - Color: Đen với Alpha = 200-240
- **RectTransform:**
  - Stretch để phủ toàn màn hình

**3.2. Tạo Text "CONGRATULATIONS!":**
- Right-click **Congratulation** → **UI → Text - TextMeshPro**
- Đặt tên: `TitleText`
- **TextMeshProUGUI Component:**
  - Text: `CONGRATULATIONS!` hoặc `YOU WIN!`
  - Font Size: 72-96
  - Alignment: Center
  - Color: Vàng (#FFD700) hoặc Vàng cam (#FFA500)
  - Font Style: Bold
- **RectTransform:**
  - Anchors: Middle-Center
  - Position Y: 100-150

**3.3. Tạo Text Điểm Số (Tùy chọn):**
- Right-click **Congratulation** → **UI → Text - TextMeshPro**
- Đặt tên: `ScoreText`
- **TextMeshProUGUI Component:**
  - Text: `Final Score: 000000`
  - Font Size: 36-48
  - Alignment: Center
  - Color: Trắng
- **RectTransform:**
  - Anchors: Middle-Center
  - Position Y: 0 (giữa màn hình)

**3.4. Tạo Button "Main Menu":**
- Right-click **Congratulation** → **UI → Button - TextMeshPro**
- Đặt tên: `MainMenuButton`
- **Button Component:**
  - Interactable: ✓ (checked)
- **TextMeshProUGUI (trong Button):**
  - Text: `MAIN MENU`
  - Font Size: 36-48
- **RectTransform:**
  - Anchors: Middle-Center
  - Position Y: -150 đến -200
  - Width: 250
  - Height: 70

**3.5. Setup Button Main Menu:**
- Chọn **MainMenuButton** trong Hierarchy
- Trong Inspector, tìm section **On Click ()**
- Click nút **+** để thêm event
- Kéo GameObject có **GameManager** component vào Object field
- Chọn function: **GameManager → LoadMainMenu()**

---

### **PHẦN 3: Gán Canvas vào GameManager**

#### **Bước 1: Chọn GameObject Game Manager**
1. Trong **Hierarchy**, tìm GameObject có **GameManager** component
2. Click chọn GameObject đó

#### **Bước 2: Gán Canvas trong Inspector**
1. Trong **Inspector panel**, tìm component **Game Manager (Script)**
2. Bạn sẽ thấy 2 fields:
   - **Game Over Panel**
   - **Congratulation Panel**

3. **Gán GameOver Canvas:**
   - Mở scene **1-1** (nếu chưa mở)
   - Trong Hierarchy, tìm Canvas **GameOver**
   - Kéo Canvas **GameOver** từ Hierarchy vào field **Game Over Panel** trong Inspector

4. **Gán Congratulation Canvas:**
   - Mở scene **1-3**
   - Trong Hierarchy, tìm Canvas **Congratulation**
   - Kéo Canvas **Congratulation** từ Hierarchy vào field **Congratulation Panel** trong Inspector

**Lưu ý**: Nếu GameManager có `DontDestroyOnLoad`, bạn có thể gán từ scene nào cũng được, nhưng nên gán từ scene 1-1.

---

## 🎨 CẤU TRÚC HIERARCHY MẪU:

### **Scene 1-1:**
```
Hierarchy
├── Game Manager
├── Canvas (UI chính)
│   ├── ScoreText
│   ├── CoinsText
│   └── HighScoreText
└── GameOver (Canvas) ← INACTIVE
    ├── Background
    ├── GameOverText
    └── MainMenuButton
```

### **Scene 1-3:**
```
Hierarchy
├── (Game Manager - DontDestroyOnLoad từ scene khác)
├── Canvas (UI chính)
│   ├── ScoreText
│   ├── CoinsText
│   └── HighScoreText
└── Congratulation (Canvas) ← INACTIVE
    ├── Background
    ├── TitleText
    ├── ScoreText (tùy chọn)
    └── MainMenuButton
```

---

## ⚠️ LƯU Ý QUAN TRỌNG:

1. **Canvas phải bị inactive ban đầu:**
   - Uncheck checkbox ở đầu Inspector
   - Code sẽ tự động active khi cần

2. **Tên GameObject:**
   - GameOver Canvas: tên **`GameOver`**
   - Congratulation Canvas: tên **`Congratulation`**
   - Nếu không đúng tên, code sẽ tự tìm nhưng có thể lỗi

3. **GameManager DontDestroyOnLoad:**
   - GameManager persist qua các scene
   - Gán Canvas một lần từ scene 1-1 là đủ
   - Canvas trong scene khác sẽ được tìm tự động khi cần

4. **Nếu Canvas không hoạt động:**
   - Kiểm tra Canvas có được gán vào GameManager không
   - Kiểm tra tên GameObject có đúng không
   - Kiểm tra Console có warning/error không

---

## ✅ CHECKLIST HOÀN THÀNH:

### **GameOver Canvas:**
- [ ] Đã tạo Canvas "GameOver" trong scene 1-1
- [ ] Canvas bị inactive (unchecked)
- [ ] Đã tạo Text "GAME OVER"
- [ ] Đã tạo Button "MAIN MENU"
- [ ] Button đã setup On Click với GameManager.LoadMainMenu()
- [ ] Đã gán Canvas vào GameManager → Game Over Panel

### **Congratulation Canvas:**
- [ ] Đã tạo Canvas "Congratulation" trong scene 1-3
- [ ] Canvas bị inactive (unchecked)
- [ ] Đã tạo Text "CONGRATULATIONS!"
- [ ] Đã tạo Button "MAIN MENU"
- [ ] Button đã setup On Click với GameManager.LoadMainMenu()
- [ ] Đã gán Canvas vào GameManager → Congratulation Panel

### **Test:**
- [ ] Chết hết lives → GameOver hiện ra
- [ ] Hoàn thành map 1-3 → Congratulation hiện ra
- [ ] Click Main Menu → Quay về Main Menu

---

## 🔍 TROUBLESHOOTING:

**Vấn đề: GameOver không hiện khi chết**
- ✅ Kiểm tra Canvas "GameOver" có được gán vào GameManager không
- ✅ Kiểm tra Console có warning "GameOver Canvas not found" không
- ✅ Kiểm tra lives đã về 0 chưa? (GameOver chỉ hiện khi hết lives)

**Vấn đề: Congratulation không hiện khi hoàn thành 1-3**
- ✅ Kiểm tra Canvas "Congratulation" có được gán vào GameManager không
- ✅ Kiểm tra Console có warning "Congratulation Canvas not found" không
- ✅ Kiểm tra map hiện tại có đúng là world=1, stage=3 không

**Vấn đề: Canvas không tìm thấy**
- ✅ Kiểm tra tên GameObject có đúng "GameOver" và "Congratulation" không
- ✅ Kiểm tra Canvas có trong scene đúng không
- ✅ Thử gán thủ công vào Inspector thay vì để auto-find

---

Chúc bạn thành công! 🎮

