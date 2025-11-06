# Hướng Dẫn Sửa GameOver Panel Tràn Màn Hình

## 🔧 Vấn Đề:
GameOver Canvas hiển thị nhỏ xíu ở góc trái thay vì tràn ra toàn màn hình.

## ✅ Giải Pháp:

### **Bước 1: Cấu Hình Canvas GameOver**

1. **Chọn Canvas "GameOver"** trong Hierarchy

2. **Trong Inspector, kiểm tra các component:**

   **A. Canvas Component:**
   - Render Mode: **Screen Space - Overlay** (hoặc Screen Space - Camera)
   - Pixel Perfect: Có thể bật hoặc tắt (tùy chọn)

   **B. Canvas Scaler Component:**
   - **Nếu chưa có Canvas Scaler → Add Component → Canvas Scaler**
   - **UI Scale Mode**: Chọn **Scale With Screen Size**
   - **Reference Resolution**: 
     - X: **1920** (hoặc 1280)
     - Y: **1080** (hoặc 720)
   - **Screen Match Mode**: **Match Width Or Height**
   - **Match**: **0.5** (hoặc giữ mặc định)

   **C. Graphic Raycaster** (tự động có khi tạo Canvas)

3. **RectTransform của Canvas:**
   - Click vào **RectTransform** component
   - **Anchors**: Click vào preset **Stretch** (góc trên bên phải của RectTransform)
     - Hoặc đặt thủ công:
     - Anchor Presets: **Stretch Stretch** (nhấn Alt+Shift khi click preset)
   - **Left, Right, Top, Bottom**: Tất cả đều = **0**
   - Điều này sẽ làm Canvas phủ toàn màn hình

---

### **Bước 2: Cấu Hình Background Panel**

1. **Chọn Background Image** trong Canvas GameOver (hoặc tạo mới nếu chưa có)

2. **Tạo Background nếu chưa có:**
   - Right-click **GameOver** → **UI → Image**
   - Đặt tên: `Background`

3. **Cấu hình RectTransform:**
   - Click vào preset **Stretch** (góc trên bên phải)
   - **Left, Right, Top, Bottom**: Tất cả = **0**
   - Background sẽ phủ toàn Canvas

4. **Cấu hình Image Component:**
   - **Color**: Đen với Alpha = 200-240 (màu nền tối)
   - Hoặc có thể dùng Sprite màu đen/solid color

---

### **Bước 3: Cấu Hình Text và Button**

1. **Text "GAME OVER":**
   - Chọn Text trong GameOver Canvas
   - **RectTransform:**
     - Anchors: **Middle-Center**
     - Position: X = 0, Y = 100-150
     - Width: 400-600
     - Height: 100-150
   - **TextMeshProUGUI:**
     - Font Size: 72-96 (hoặc lớn hơn tùy màn hình)
     - Alignment: Center

2. **Button "MAIN MENU":**
   - Chọn Button trong GameOver Canvas
   - **RectTransform:**
     - Anchors: **Middle-Center**
     - Position: X = 0, Y = -150 đến -200
     - Width: 250-300
     - Height: 60-80

---

## 🎯 CÁCH NHANH NHẤT:

### **Option 1: Reset Canvas RectTransform**

1. Chọn **Canvas "GameOver"**
2. Trong Inspector, tìm **RectTransform**
3. Click vào icon **3 chấm** (⋮) ở góc trên bên phải của RectTransform
4. Chọn **Reset**
5. Sau đó:
   - Click vào preset **Stretch** (góc trên bên phải)
   - Đặt **Left, Right, Top, Bottom = 0**

### **Option 2: Tạo Canvas Mới (Nếu cần)**

1. **Xóa Canvas GameOver cũ** (nếu quá phức tạp)
2. **Tạo Canvas mới:**
   - Right-click Hierarchy → **UI → Canvas**
   - Đặt tên: **GameOver**
3. **Canvas sẽ tự động có:**
   - Canvas Scaler với Scale With Screen Size
   - RectTransform đã stretch
4. **Chỉ cần:**
   - Tạo Background Image và stretch nó
   - Tạo Text và Button như bình thường

---

## 📋 CHECKLIST:

- [ ] Canvas GameOver có **Canvas Scaler** component
- [ ] Canvas Scaler: **UI Scale Mode = Scale With Screen Size**
- [ ] Canvas Scaler: **Reference Resolution** đã set (1920x1080)
- [ ] Canvas RectTransform: **Anchors = Stretch Stretch**
- [ ] Canvas RectTransform: **Left, Right, Top, Bottom = 0**
- [ ] Background Image: **RectTransform = Stretch Stretch**
- [ ] Background Image: **Left, Right, Top, Bottom = 0**
- [ ] Background Image: **Color Alpha = 200-240** (màu nền tối)

---

## 🔍 Kiểm Tra Nhanh:

1. **Chọn Canvas GameOver** trong Hierarchy
2. **Trong Scene view**, bạn sẽ thấy Canvas có:
   - Góc trên bên trái ở (-960, 540) hoặc tương tự
   - Góc dưới bên phải ở (960, -540) hoặc tương tự
   - Canvas phủ toàn viewport

3. **Nếu Canvas vẫn nhỏ:**
   - Kiểm tra lại Canvas Scaler
   - Kiểm tra RectTransform anchors
   - Thử reset RectTransform

---

## 💡 MẸO:

- **Luôn dùng preset "Stretch"** cho Canvas và Background
- **Reference Resolution** nên match với resolution game bạn design
- **Nếu game chạy trên nhiều resolution**, dùng Canvas Scaler với Match Width Or Height = 0.5

---

Sau khi sửa, test lại game và GameOver sẽ tràn ra toàn màn hình! 🎮

