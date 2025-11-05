# Hướng Dẫn Triển Khai High Score Trên Unity Editor

## ✅ Code đã được cập nhật tự động:
- ✅ `GameManager.cs` - Đã thêm logic high score
- ✅ `UIManager.cs` - Đã thêm hiển thị high score

---

## 📋 Các Bước Thực Hiện Trên Unity Editor:

### **Bước 1: Tạo Text UI cho High Score**

1. **Mở Scene chứa Canvas** (thường là scene đầu tiên hoặc scene có UI)

2. **Tìm Canvas trong Hierarchy**
   - Canvas thường nằm trong Hierarchy panel
   - Nếu chưa có, tạo mới: `Right-click Hierarchy → UI → Canvas`

3. **Tạo TextMeshPro Text mới cho High Score**
   - **Right-click** vào **Canvas** trong Hierarchy
   - Chọn **UI → Text - TextMeshPro**
   - Unity sẽ hỏi "TMP Essentials" → Chọn **Import TMP Essentials** (nếu chưa có)
   - Đặt tên GameObject mới là: **`HighScoreText`** (QUAN TRỌNG: tên phải chính xác!)

### **Bước 2: Cấu Hình HighScoreText**

1. **Chọn GameObject `HighScoreText`** trong Hierarchy

2. **Trong Inspector, thiết lập các thông số:**

   **Rect Transform:**
   - **Anchors**: Đặt ở góc trên bên phải (ví dụ: Top-Right)
   - **Position**: Điều chỉnh vị trí phù hợp (ví dụ: X = -50, Y = -30)
   - **Width**: Khoảng 200-250
   - **Height**: Khoảng 30-40

   **TextMeshProUGUI Component:**
   - **Text**: `HIGH SCORE: 000000` (text mặc định)
   - **Font Size**: 24-32 (tùy theo kích thước màn hình)
   - **Alignment**: Left (hoặc Center tùy ý)
   - **Color**: Màu vàng hoặc trắng (để phân biệt với SCORE thường)
   - **Font Style**: Có thể chọn Bold để nổi bật

### **Bước 3: Kiểm Tra UIManager Component**

1. **Tìm GameObject có UIManager script** trong Hierarchy
   - Thường là Canvas hoặc một GameObject con của Canvas

2. **Chọn GameObject đó**, xem Inspector

3. **Kiểm tra UIManager Component:**
   - **High Score Text**: Có thể để trống (code sẽ tự tìm)
   - HOẶC kéo thả `HighScoreText` vào field này

### **Bước 4: Test High Score**

1. **Chạy Game** (Play mode)

2. **Kiểm tra:**
   - High Score Text hiển thị với giá trị ban đầu: `HIGH SCORE: 000000`
   - Chơi game và đạt điểm
   - Khi player chết, điểm cao nhất sẽ được lưu
   - Restart game, high score vẫn hiển thị điểm cao nhất

3. **Test lưu trữ:**
   - Đạt điểm cao (ví dụ: 5000)
   - Chết để lưu high score
   - Thoát game và chạy lại
   - High score vẫn giữ nguyên → ✅ Hoạt động!

---

## 🔧 Cấu Hình Nâng Cao (Tùy chọn):

### **Thay Đổi Vị Trí High Score Text:**

Nếu muốn đặt ở vị trí khác:
- **Top-Left**: Góc trên bên trái
- **Top-Center**: Giữa trên
- **Top-Right**: Góc trên bên phải (khuyến nghị)

### **Thay Đổi Format Hiển Thị:**

Trong `UIManager.cs`, dòng 47, bạn có thể thay đổi:
- `"HIGH SCORE: "` → `"BEST: "` hoặc `"RECORD: "`
- `"000000"` → `"0,000,000"` (có dấu phẩy) hoặc format khác

### **Reset High Score (Test/Debug):**

Nếu muốn reset high score, thêm button hoặc code:
```csharp
// Trong GameManager hoặc script khác
PlayerPrefs.DeleteKey("HighScore");
PlayerPrefs.Save();
```

---

## ⚠️ Lưu Ý Quan Trọng:

1. **Tên GameObject phải chính xác**: `HighScoreText` (không có khoảng trắng, phân biệt hoa thường)

2. **Canvas phải tồn tại**: Nếu không có Canvas, code sẽ không tìm thấy Text

3. **TextMeshPro phải được import**: Nếu chưa có, Unity sẽ tự động import khi tạo Text

4. **High Score chỉ lưu khi player chết**: Điểm được kiểm tra và lưu trong `ResetLevel()`

5. **PlayerPrefs lưu vĩnh viễn**: Chỉ mất khi:
   - Xóa game
   - Clear PlayerPrefs (Edit → Clear All PlayerPrefs)
   - Xóa bằng code

---

## 🎯 Checklist Hoàn Thành:

- [ ] Đã tạo GameObject `HighScoreText` trong Canvas
- [ ] Đã cấu hình TextMeshProUGUI với text mặc định
- [ ] Đã đặt vị trí phù hợp trên màn hình
- [ ] Đã test chạy game và thấy high score hiển thị
- [ ] Đã test đạt điểm cao và lưu thành công
- [ ] Đã test restart game và high score vẫn giữ nguyên

---

## 📝 Troubleshooting:

**Vấn đề: High Score không hiển thị**
- ✅ Kiểm tra tên GameObject có đúng `HighScoreText` không
- ✅ Kiểm tra GameObject có TextMeshProUGUI component không
- ✅ Kiểm tra GameObject có nằm trong Canvas không

**Vấn đề: High Score không lưu**
- ✅ Kiểm tra player có chết (gọi `ResetLevel()`) không
- ✅ Kiểm tra Console có lỗi gì không
- ✅ Thử clear PlayerPrefs và test lại

**Vấn đề: High Score hiển thị sai**
- ✅ Kiểm tra format trong `UIManager.cs` dòng 47
- ✅ Kiểm tra `highScore` property trong GameManager có public không

---

Chúc bạn thành công! 🎮

