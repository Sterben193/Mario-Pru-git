# Hướng Dẫn Setup Menu Music cho Main Menu

## 🎵 Vấn Đề:
Main Menu không có GameManager, nên SoundManager không tự động được tạo. Cần setup SoundManager trong Main Menu scene.

---

## 📋 Các Bước Thực Hiện:

### **Cách 1: Tạo SoundManager trong Main Menu Scene (Khuyến nghị)**

#### **Bước 1: Mở Scene MainMenu**
1. Trong Unity Editor, mở scene **MainMenu**

#### **Bước 2: Tạo GameObject SoundManager**
1. Trong **Hierarchy**, right-click → **Create Empty**
2. Đặt tên: **`SoundManager`**

#### **Bước 3: Gắn Script SoundManager**
1. Chọn GameObject **SoundManager**
2. **Inspector** → **Add Component**
3. Tìm và chọn: **Sound Manager (Script)**

#### **Bước 4: Gán Sound Files**
1. Chọn GameObject **SoundManager**
2. Trong Inspector, gán các sound files vào **Sound Manager (Script)**:
   - **Background Music**: `01. Ground Theme.mp3`
   - **Menu Music**: `01. Ground Theme.mp3` (hoặc file nhạc menu khác nếu có)
   - Các sound effects khác (tùy chọn cho Main Menu)

#### **Bước 5: Gắn MenuMusic Script**
1. Tìm một GameObject trong Main Menu (hoặc tạo GameObject mới)
2. **Add Component** → **Menu Music (Script)**
3. Script sẽ tự động phát nhạc menu khi scene load

---

### **Cách 2: Tạo SoundManager Prefab (Tùy chọn - Nâng cao)**

1. **Tạo SoundManager trong bất kỳ scene nào** (ví dụ: scene 1-1)
2. **Gán đầy đủ sound files** vào Inspector
3. **Kéo GameObject SoundManager vào Project** để tạo Prefab
4. **Trong Main Menu scene**, kéo Prefab vào Hierarchy
5. **Gắn MenuMusic script** vào một GameObject trong Main Menu

---

## ✅ Checklist:

- [ ] Đã tạo GameObject SoundManager trong Main Menu scene
- [ ] Đã gắn Sound Manager (Script) component
- [ ] Đã gán Background Music: `01. Ground Theme.mp3`
- [ ] Đã gán Menu Music: `01. Ground Theme.mp3` (hoặc file khác)
- [ ] Đã gắn MenuMusic script vào một GameObject trong Main Menu
- [ ] Đã test: Nhạc menu phát khi vào Main Menu

---

## 🔧 Lưu Ý:

1. **SoundManager sẽ persist qua scenes** nhờ DontDestroyOnLoad
2. **Chỉ cần tạo 1 lần** trong Main Menu (hoặc scene đầu tiên)
3. **Nếu SoundManager đã tồn tại** từ scene khác, MenuMusic sẽ dùng nó
4. **Menu Music sẽ tự động phát** khi vào Main Menu nhờ MenuMusic script

---

## 🎮 Test:

1. **Chạy game từ Main Menu**
2. **Nhạc menu sẽ tự động phát** khi scene load
3. **Khi chuyển sang game scene**, nhạc game sẽ phát
4. **Khi quay về Main Menu**, nhạc menu sẽ phát lại

---

## 📝 Troubleshooting:

**Vấn đề: Không có nhạc menu**
- ✅ Kiểm tra SoundManager có tồn tại trong Main Menu scene không?
- ✅ Kiểm tra Menu Music đã được gán vào SoundManager chưa?
- ✅ Kiểm tra MenuMusic script đã được gắn vào GameObject trong Main Menu chưa?
- ✅ Kiểm tra Console có lỗi gì không?

**Vấn đề: Nhạc menu không phát**
- ✅ Kiểm tra AudioSource trong SoundManager có được cấu hình đúng không?
- ✅ Kiểm tra Volume > 0
- ✅ Kiểm tra MenuMusic script có được enable không?

---

Chúc bạn thành công! 🎮🔊

