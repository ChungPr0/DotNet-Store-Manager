# 🛒 PHẦN MỀM QUẢN LÝ BÁN HÀNG (POS C# WINFORMS)

![C#](https://img.shields.io/badge/Language-C%23_10.0-purple?style=for-the-badge&logo=csharp)
![.NET](https://img.shields.io/badge/Framework-.NET_10-5C2D91?style=for-the-badge&logo=dotnet)
![Database](https://img.shields.io/badge/Database-SQL_Server-CC292B?style=for-the-badge&logo=microsoftsqlserver)
![Version](https://img.shields.io/badge/Version-2.0.0-green?style=for-the-badge)

> **Giải pháp quản lý bán hàng toàn diện, giao diện hiện đại, xử lý dữ liệu mạnh mẽ dành cho cửa hàng.**

---

## 📑 MỤC LỤC
1. [Giới thiệu](#-giới-thiệu)
2. [Tính năng nổi bật](#-tính-năng-nổi-bật)
3. [Chuẩn bị Database](#-chuẩn-bị-database-sql-server)
4. [Hướng dẫn cài đặt & chạy](#-hướng-dẫn-chạy-phần-mềm)
5. [Hướng dẫn sử dụng chi tiết](#-hướng-dẫn-sử-dụng-chi-tiết)

---

## 📖 GIỚI THIỆU

Phần mềm **Quản Lý Bán Hàng** được nâng cấp toàn diện trên nền tảng **C# WinForms (.NET 10)** kết hợp với hệ quản trị cơ sở dữ liệu **SQL Server**. Phiên bản này tập trung vào hiệu năng cao, giao diện Custom UI phẳng (Flat Design) hiện đại, bảo mật đa tầng và kiến trúc tối ưu (Lazy Loading) giúp phần mềm chạy mượt mà kể cả khi dữ liệu lớn.

---

## 🌟 TÍNH NĂNG NỔI BẬT

| Chức năng                  | Mô tả chi tiết                                                                                                        |
|:---------------------------|:----------------------------------------------------------------------------------------------------------------------|
| **📊 Tổng quan Dashboard** | Thống kê doanh thu, khách hàng, đơn hàng theo thời gian thực. Tích hợp **Biểu đồ Cột & Tròn Custom** đẹp mắt.         |
| **👥 Phân quyền Chặt chẽ** | Chống xâm nhập đa lớp. **Admin** (Toàn quyền) và **Employee** (Chỉ bán hàng, ẩn Dashboard, cấm sửa/xóa dữ liệu cũ).   |
| **📦 Quản lý Kho Hàng** | Tự động trừ kho khi bán. Cảnh báo vượt quá tồn kho. **Hoàn kho tự động** nếu Admin xóa hóa đơn.                       |
| **🧾 Hóa đơn Thông minh** | Giao diện tạo hóa đơn siêu tốc. Tự động điền và khóa tên nhân viên lập. Hỗ trợ **In hóa đơn** trực tiếp.              |
| **✨ Giao diện Custom** | Nút bấm 3D bo góc, hiệu ứng hover, chuyển tab mượt mà không load lại trang nhờ kiến trúc giữ State (Lazy Loading).    |
| **🛡️ Kiến trúc & Bảo mật** | Sử dụng Parameterized Queries (`SqlParameter`) chống SQL Injection 100%.                                              |

---

## 🛠 CHUẨN BỊ DATABASE (SQL SERVER)

Hệ thống sử dụng **Microsoft SQL Server** để đảm bảo tính toàn vẹn và chịu tải tốt.

### Cách thiết lập cơ sở dữ liệu:
1. Mở phần mềm **SQL Server Management Studio (SSMS)**.
2. Mở file script tạo database: `Resources/database_script.sql` (hoặc file `.sql` của bạn).
3. Bôi đen toàn bộ code và nhấn **Execute (F5)** để tạo bảng và dữ liệu mẫu.
4. Mở file `Utils/DatabaseConnector.cs` trong source code và sửa lại `ConnectionString` cho khớp với tên Server SQL của máy bạn.
   * *Ví dụ:* `Server=MY_PC\SQLEXPRESS;Database=StoreManager;Trusted_Connection=True;TrustServerCertificate=True;`

---

## 🚀 HƯỚNG DẪN CHẠY PHẦN MỀM

### Yêu cầu hệ thống:
* **Visual Studio 2022** (Có cài đặt workload .NET Desktop Development).
* **.NET 10 SDK**.

### Cách khởi động:
1. Mở file Solution `StoreManager.sln` bằng Visual Studio.
2. Nhấn `Ctrl + Shift + B` để Build dự án và tải các thư viện cần thiết.
3. Nhấn `F5` để chạy phần mềm.
*(Hoặc vào thư mục `bin\Debug\net10.0-windows\` chạy trực tiếp file `StoreManager.exe` sau khi đã build thành công).*

---

## 📘 HƯỚNG DẪN SỬ DỤNG CHI TIẾT

### 🔐 1. Đăng Nhập Hệ Thống
Hệ thống tự động điều hướng giao diện dựa trên vai trò tài khoản:

|  Vai trò  | Quyền hạn                                                                                             | Giao diện khởi đầu       |
|:---------:|:------------------------------------------------------------------------------------------------------|:-------------------------|
| **Admin** | Toàn quyền hệ thống. Được xem thống kê, thêm/sửa/xóa mọi dữ liệu (Sản phẩm, Khách, Hóa đơn, Cấp dưới).| **Dashboard (Tổng quan)**|
| **Employee**| Chỉ được phép bán hàng. Bị ẩn hoàn toàn Dashboard, Nhà cung cấp, Nhân sự. Không được xóa/sửa Hóa đơn cũ.| **Hóa Đơn** |

### 🛒 2. Quy Trình Bán Hàng (Dành cho Nhân viên & Admin)
1. Màn hình tự động hiển thị tab **Hóa Đơn** (Đối với nhân viên).
2. Bấm <kbd>Tạo mới</kbd>.
3. **Chọn Khách hàng:** Chọn từ danh sách thả xuống hoặc bấm nút tìm kiếm/thêm nhanh. *(Tên nhân viên lập hóa đơn được tự động điền và khóa cứng).*
4. **Thêm Sản phẩm:**
   * Bấm <kbd>Thêm SP</kbd>.
   * Chọn sản phẩm, hệ thống tự đối chiếu số lượng tồn kho trong SQL Server.
   * Nhập số lượng → **Xác nhận**.
5. **Thanh toán:** Kiểm tra tổng tiền và bấm <kbd>Lưu hóa đơn</kbd>.

### 🧾 3. Quản lý & In Hóa đơn
* **Xem chi tiết:** Click vào danh sách hóa đơn bên trái. Mọi thông tin chi tiết sản phẩm sẽ hiện ra.
* **Xóa hóa đơn (Chỉ Admin):** Bấm <kbd>Xóa</kbd> → Xác nhận. Hệ thống tự động hoàn trả số lượng sản phẩm về kho.
* **In hóa đơn:** Bấm nút <kbd>In</kbd> để xuất phiếu tính tiền chuẩn form.

### 📦 4. Quản lý Sản phẩm & Phân loại
* Xem danh sách, tìm kiếm và lọc sản phẩm theo giá/tên/ngày.
* Admin có quyền cập nhật nhanh **Phân loại (Type)** và **Nhà cung cấp (Supplier)** qua các Popup Dialog không cần chuyển trang.

---

<div style="text-align: center;">
<b>© 2026 Copyright by Chung. All rights reserved.</b><br>
<i>Designed and Coded with 💻 using C# WinForms & SQL Server.</i>
</div>