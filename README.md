# 💻 Hệ Thống Thương Mại Điện Tử Laptop (Laptop E-Commerce)

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Blazor](https://img.shields.io/badge/Blazor-WASM-512bd4?style=for-the-badge&logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=for-the-badge&logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server/)

Một giải pháp thương mại điện tử hoàn chỉnh dành cho việc kinh doanh Laptop, được xây dựng trên nền tảng **ASP.NET Core Web API** và **Blazor WebAssembly**. Dự án hỗ trợ quy trình mua hàng khép kín, quản lý phân quyền và tích hợp hệ thống quản trị mạnh mẽ.

---

## 🌟 Tổng Quan Dự Án

Dự án này là một ứng dụng web Single Page Application (SPA) hiện đại, tập trung vào trải nghiệm người dùng và tính bảo mật. Hệ thống cho phép người dùng tìm kiếm, xem chi tiết và mua laptop từ các thương hiệu hàng đầu như Apple, Dell, Asus, MSI, v.v.

### Mục tiêu dự án:
- Cung cấp giao diện mua sắm mượt mà, phản hồi nhanh.
- Quản lý kho hàng và đơn hàng hiệu quả cho quản trị viên.
- Hệ thống thanh toán và theo dõi trạng thái đơn hàng thời gian thực.
- Phân quyền người dùng rõ ràng (Khách hàng, Thủ kho, Shipper, Admin).

---

## 🚀 Công Nghệ Sử Dụng

### Backend (LaptopECommerce.Api)
- **Framework**: `ASP.NET Core 8.0 Web API`
- **ORM**: `Entity Framework Core`
- **Database**: `SQL Server` (Hỗ trợ cả Raw SQL Procedures và Migrations)
- **Security**: `JWT Authentication` & `Role-base Authorization`
- **Thư viện bổ trợ**: `Polly` (xử lý lỗi và khả năng phục hồi), `DotNetEnv` (quản lý biến môi trường).
- **Khác**: Dependency Injection, Middleware, Swagger UI.

### Frontend (LaptopECommerceWASM)
- **Framework**: `Blazor WebAssembly (WASM)`
- **Styling**: `Bootstrap` & `Custom CSS`
- **Thư viện UI**: `Blazored.Toast` (thông báo), `Blazored.LocalStorage` (lưu trữ cục bộ).
- **Security**: Custom `AuthenticationStateProvider`.

### Models (LaptopECommerce.Models)
- Thư viện lớp chung (Class Library) chứa các `DTOs`, `Entities` và `View Models` dùng chung cho cả Client và Server.

---

## ✨ Chức Năng Chính

### 🛒 Đối với Khách Hàng (User)
- **Trang chủ**: Hiển thị sản phẩm nổi bật, banner khuyến mãi.
- **Xem theo thương hiệu**: Lọc sản phẩm theo Apple, Asus, Dell, MSI, Samsung, Acer, Lenovo.
- **Tìm kiếm**: Tìm kiếm laptop theo tên và thông số.
- **Giỏ hàng**: Thêm/Xóa sản phẩm, cập nhật số lượng trực tiếp.
- **Thanh toán**: Quy trình đặt hàng, nhập địa chỉ và xác nhận đơn hàng.
- **Quản lý tài khoản**: Xem Profile, đổi mật khẩu, lịch sử đơn hàng.

### 🛠️ Đối với Quản Trị Viên (Admin)
- **Quản lý Sản phẩm**: Thêm mới, chỉnh sửa thông tin cấu hình, hình ảnh laptop.
- **Quản lý Người dùng**: Danh sách thành viên, cấp quyền, khóa/mở tài khoản.
- **Quản lý Đơn hàng**: Theo dõi danh sách đơn hàng, phê duyệt, gán shipper.
- **Trạng thái đơn hàng**: Cập nhật quy trình từ Đang xử lý -> Đang giao -> Hoàn thành.

### 🚚 Đối với Người Giao Hàng (Shipper)
- **Danh sách giao hàng**: Xem các đơn hàng được gán cho bản thân.
- **Cập nhật trạng thái**: Đánh dấu đã giao hàng thành công hoặc thất bại.

---

## 📂 Cấu Trúc Thư Mục

```text
LaptopECommerceWeb/
├── LaptopECommerce.Api/       # Dự án Backend Web API
│   ├── Controller/            # Xử lý các API Endpoints
│   ├── Data/                  # DbContext và cấu hình Database
│   ├── Entities/              # Các thực thể dữ liệu
│   └── Migrations/            # Lịch sử thay đổi Schema Database
├── LaptopECommerceWASM/       # Dự án Frontend Blazor WASM
│   ├── Pages/                 # Giao diện người dùng (User, Admin, Shipper, Brand)
│   ├── Shared/                # Các Component dùng chung (NavMenu, Layout)
│   └── wwwroot/               # Static assets (CSS, JS, Images)
├── LaptopECommerce.Models/    # Thư viện chứa Models & DTOs
├── db_laptop_ecommerce_clean.sql # File script khởi tạo database
└── README.md                  # Tài liệu hướng dẫn (File này)
```

---

## 🛠️ Cài Đặt & Chạy Dự Án

### 1. Cấu hình Cơ sở dữ liệu
1. Tạo một database mới trên SQL Server.
2. Chạy file script `db_laptop_ecommerce_clean.sql` để tạo bảng và dữ liệu mẫu.
3. Trong thư mục `LaptopECommerce.Api`, tạo file `.env` hoặc chỉnh sửa `appsettings.json`:
   ```env
   ConnectionStrings__DefaultConnection=Server=YOUR_SERVER; Database=LaptopDB; Integrated Security=True; TrustServerCertificate=True;
   JwtSecurityKey=Your_Super_Secret_Key_At_Least_32_Chars
   ```

### 2. Chạy API (Backend)
```bash
cd LaptopECommerce.Api
dotnet run
```

### 3. Chạy Client (Frontend)
```bash
cd LaptopECommerceWASM
dotnet run
```

---

## 🌍 Triển Khai (Deployment)

Dự án hiện được cấu hình để triển khai tốt nhất trên **MonsterASP.net**:
- Cài đặt Frontend WASM bên trong thư mục `wwwroot` của Backend API.
- Cấu hình tệp `web.config` để hỗ trợ ASP.NET Core và Routing của Blazor.
- Truy cập API thông qua HTTPS ổn định.

---

## 📬 Liên Hệ

Nếu bạn có bất kỳ câu hỏi nào về dự án, vui lòng liên hệ:
- **Tác giả**: Anh Đạt
- **Email**: anh23dat.truong@gmail.com
- **GitHub**: [(https://github.com/caubedat2003)]

---
*Dự án thực hiện nhằm mục đích học tập và xây dựng ứng dụng thực tế với .NET 8.*
