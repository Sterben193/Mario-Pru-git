# Hướng Dẫn Setup Sound Manager

## ✅ Code đã được cập nhật:
- ✅ `SoundManager.cs` - Script quản lý tất cả sounds
- ✅ `PlayerMovement.cs` - Jump sound
- ✅ `Player.cs` - Player die sound, Grow sound
- ✅ `BlockCoin.cs` - Coin sound
- ✅ `Goomba.cs` - Stomp sound
- ✅ `PowerUp.cs` - Powerup sound (ăn nấm)
- ✅ `FlagPole.cs` - Stage clear sound
- ✅ `GameManager.cs` - GameOver sound, Victory sound

---

## 📋 Các Bước Thực Hiện Trên Unity Editor:

### **Bước 1: Tạo GameObject SoundManager**

1. **Mở Scene 1-1** (hoặc scene nào có GameManager)

2. **Tạo GameObject mới:**
   - Right-click trong **Hierarchy** → **Create Empty**
   - Đặt tên: **`SoundManager`**

3. **Gắn Script SoundManager:**
   - Chọn GameObject **SoundManager**
   - Trong Inspector, click **Add Component**
   - Tìm và chọn: **Sound Manager (Script)**

4. **Thêm AudioSource (tự động hoặc thủ công):**
   - Component AudioSource sẽ được tự động thêm
   - Nếu chưa có: **Add Component → Audio → Audio Source**

---

### **Bước 2: Gán Sound Files vào SoundManager**

1. **Chọn GameObject SoundManager** trong Hierarchy

2. **Trong Inspector, tìm component Sound Manager (Script)**

3. **Gán các AudioClip từ thư mục Sounds:**
   - **Jump Sound**: Kéo `smb_jump-small.wav` vào field
   - **Game Over Sound**: Kéo `smb_gameover.wav` vào field
   - **Player Die Sound**: Kéo `smb_mariodie.wav` vào field
   - **Victory Sound**: Kéo `smb_world_clear.wav` vào field
   - **Powerup Sound**: Kéo `smb_powerup.wav` vào field
   - **Coin Sound**: Kéo `smb_coin.wav` vào field
   - **Grow Sound**: Kéo `smb_powerup.wav` vào field (dùng chung với powerup)
   - **Stage Clear Sound**: Kéo `smb_stage_clear.wav` vào field
   - **Stomp Sound**: Kéo `smb_stomp.wav` vào field
   - **Background Music**: Kéo `01. Ground Theme.mp3` vào field (QUAN TRỌNG!)

---

### **Bước 3: Cấu Hình AudioSource**

1. **Chọn GameObject SoundManager**

2. **Trong Inspector, tìm component Audio Source:**

   - **Play On Awake**: **TẮT (unchecked)**
   - **Volume**: **0.5** (hoặc 0.3-0.7 tùy ý)
   - **Spatial Blend**: **0** (2D sound)
   - Các setting khác giữ mặc định

---

### **Bước 4: Đảm Bảo SoundManager Persist Qua Scenes**

1. **SoundManager đã có `DontDestroyOnLoad`** trong code
2. **Không cần làm gì thêm** - nó sẽ tự động persist qua các scene

---

## 🎵 Mapping Sound Files:

| Event | Sound File | Script |
|-------|------------|--------|
| Jump | `smb_jump-small.wav` | PlayerMovement.cs |
| GameOver | `smb_gameover.wav` | GameManager.cs |
| Player chết | `smb_mariodie.wav` | Player.cs |
| Victory | `smb_world_clear.wav` | GameManager.cs |
| Ăn nấm | `smb_powerup.wav` | PowerUp.cs |
| Lụm coin | `smb_coin.wav` | BlockCoin.cs |
| Hóa bự | `smb_powerup.wav` | Player.cs |
| Qua stage | `smb_stage_clear.wav` | FlagPole.cs |
| Nhảy lên quái | `smb_stomp.wav` | Goomba.cs |
| **Background Music** | **`01. Ground Theme.mp3`** | **GameManager.cs** |

---

## ✅ Checklist Hoàn Thành:

- [ ] Đã tạo GameObject SoundManager
- [ ] Đã gắn Sound Manager (Script) component
- [ ] Đã gán tất cả 9 sound files vào Inspector
- [ ] AudioSource đã được cấu hình (Play On Awake = false, Volume = 0.5)
- [ ] Đã test: Nhảy → có sound
- [ ] Đã test: Chết → có sound
- [ ] Đã test: Lụm coin → có sound
- [ ] Đã test: Ăn nấm → có sound
- [ ] Đã test: Nhảy lên quái → có sound
- [ ] Đã test: GameOver → có sound
- [ ] Đã test: Victory → có sound
- [ ] Đã test: Qua stage → có sound
- [ ] Đã gán Background Music: `01. Ground Theme.mp3`
- [ ] Đã test: Nhạc nền phát khi game start
- [ ] Đã test: Nhạc nền loop liên tục

---

## 🔧 Điều Chỉnh Volume:

### **Cách 1: Điều chỉnh trong SoundManager.cs**
Trong `SoundManager.cs`, dòng:
```csharp
audioSource.volume = 0.5f; // Thay đổi giá trị này (0.0 - 1.0)
```

### **Cách 2: Điều chỉnh từng sound riêng**
Trong các method `PlaySound()`, có thể điều chỉnh volume:
```csharp
SoundManager.Instance.PlaySound(clip, 0.7f); // 0.7 = 70% volume
```

### **Cách 3: Điều chỉnh trong Inspector**
- Chọn SoundManager
- Trong AudioSource component, thay đổi **Volume** slider (cho sound effects)
- Trong "MusicSource" child object, thay đổi **Volume** slider (cho background music)

### **Cách 4: Điều chỉnh background music volume riêng**
Trong `SoundManager.cs`, dòng:
```csharp
musicSource.volume = 0.3f; // Thay đổi giá trị này (0.0 - 1.0)
```
Hoặc gọi method:
```csharp
SoundManager.Instance.SetMusicVolume(0.5f); // 0.5 = 50% volume
```

---

## 📝 Troubleshooting:

**Vấn đề: Không có sound khi chơi**
- ✅ Kiểm tra SoundManager có tồn tại trong scene không?
- ✅ Kiểm tra SoundManager.Instance có null không? (xem Console)
- ✅ Kiểm tra AudioSource có được gán đúng không?
- ✅ Kiểm tra Volume có > 0 không?
- ✅ Kiểm tra sound files có được gán vào Inspector không?

**Vấn đề: Sound quá to hoặc quá nhỏ**
- ✅ Điều chỉnh Volume trong AudioSource component
- ✅ Hoặc sửa code trong SoundManager.cs

**Vấn đề: Sound bị lặp lại hoặc không dừng**
- ✅ Đảm bảo Play On Awake = false
- ✅ Code đã dùng PlayOneShot() nên không bị conflict

**Vấn đề: Một số sound không phát**
- ✅ Kiểm tra sound file có được gán đúng không
- ✅ Kiểm tra Console có lỗi gì không
- ✅ Kiểm tra SoundManager.Instance có null không

---

## 🎯 Lưu Ý:

1. **SoundManager sẽ persist qua scenes** nhờ DontDestroyOnLoad
2. **Chỉ cần tạo 1 lần** trong scene đầu tiên (1-1)
3. **Sound files cần được import đúng format** (WAV, MP3, OGG)
4. **Nếu muốn tắt sound**, có thể thêm checkbox Mute trong SoundManager

---

## 🎮 Test Ngay:

1. **Chạy game**
2. **Nhảy** → Nghe jump sound
3. **Lụm coin** → Nghe coin sound
4. **Ăn nấm** → Nghe powerup sound
5. **Chết** → Nghe die sound
6. **Nhảy lên Goomba** → Nghe stomp sound
7. **Qua stage** → Nghe stage clear sound
8. **GameOver** → Nghe game over sound
9. **Victory (map 1-3)** → Nghe victory sound

---

Chúc bạn thành công! 🎮🔊

