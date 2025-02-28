# FlightDocsSystem

## 📌 Giới thiệu
FlightDocsSystem là một Web API được phát triển bằng **ASP.NET Core 6** nhằm quản lý tài liệu chuyến bay, hỗ trợ việc lưu trữ, truy xuất thông tin trong ngành hàng không.

## 🚀 Công nghệ sử dụng
- **.NET 6 (ASP.NET Core Web API)**
- **Entity Framework Core** (Code-First, Fluent API)
- **Microsoft SQL Server** (Lưu trữ dữ liệu)
- **AutoMapper** (Chuyển đổi dữ liệu giữa DTO và Model)
- **JWT Authentication** (Xác thực API)
- **Swagger UI** (Tài liệu API)
- **Repository Pattern** (Quản lý dữ liệu)

## 📚 Cấu trúc thư mục
```
FlightDocsSystem/
│-- Authorization/       # Xác thực và phân quyền
│-- Controllers/         # Xử lý request và trả về response cho client
│-- DTO/                 # Data Transfer Objects
│-- Data/                # DbContext và cấu hình EF Core
│-- Mapper/              # Cấu hình AutoMapper
│-- Migrations/          # Lưu trữ các migration của database
│-- Properties/          # Cấu hình dự án
│-- Repository/          # Repository Pattern
│-- Services/            # Chứa logic nghiệp vụ
│-- Upload/              # Thư mục lưu trữ file upload
│-- Validation/          # Kiểm tra dữ liệu đầu vào
│-- Program.cs           # Cấu hình ứng dụng
│-- TheThanh_WebAPI_Flight.csproj  # File cấu hình dự án
│-- appsettings.json     # Cấu hình database và JWT
```

## 🔑 Chức năng chính
✅ **Quản lý chuyến bay**: Tạo, đọc, cập nhật và xóa thông tin chuyến bay.  
✅ **Quản lý tài liệu chuyến bay**: Thêm, sửa, xóa, cho phép upload và download các tài liệu chuyến bay  
✅ **Quản lý người dùng**: Xác thực, phân quyền, quản lý thông tin người dùng   
✅ **Phân quyền tài liệu**: Cho phép người dùng có quyền truy cập tài liệu theo vai trò    
✅ **Xác thực & Phân quyền**: JWT Authentication, Refresh Token, Custom Authorization  

## 🔧 Hướng dẫn cài đặt
### 1️⃣ Clone repository
```console
git clone https://github.com/phanthethanh0209/Project_WebAPI_FlightDocsSystem.git
cd Project_WebAPI_FlightDocsSystem
```
### 2️⃣ Cấu hình database
- Mở **appsettings.json**, chỉnh sửa chuỗi kết nối SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FlightDocsDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```
- Mở **Package Manager Console** (Tools > NuGet Package Manager > Package Manager Console) và chạy lệnh sau để tạo cơ sở dữ liệu:
```powershell
Update-Database
```
- Nếu chưa có migration, tạo migration đầu tiên:
```powershell
Add-Migration InitialCreate
```
- Sau đó, cập nhật database:
```powershell
Update-Database
```

Ứng dụng sẽ chạy trên **https://localhost:5001** hoặc **http://localhost:5000**.

## 📚 API Documentation
Sử dụng **Swagger** để xem tài liệu API:
- Truy cập: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## 🛠 Đóng góp
Nếu bạn muốn đóng góp, hãy tạo **Pull Request** hoặc báo lỗi trong mục **Issues** của GitHub.
