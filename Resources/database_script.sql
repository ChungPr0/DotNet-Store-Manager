-- ===============
-- 0. TẠO DATABASE
-- ===============
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'StoreManager')
BEGIN
    CREATE DATABASE StoreManager;
END
GO

USE StoreManager;
GO

-- ==============
-- 1. XÓA BẢNG CŨ
-- ==============
DROP TABLE IF EXISTS Invoice_details;
DROP TABLE IF EXISTS Invoices;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS ProductTypes;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Suppliers;
GO

-- ========================
-- 2. TẠO CẤU TRÚC BẢNG MỚI
-- ========================

-- Bảng Nhà cung cấp
CREATE TABLE Suppliers (
    sup_ID INT IDENTITY(1,1) PRIMARY KEY,
    sup_name NVARCHAR(255) NOT NULL,
    sup_address NVARCHAR(MAX) NOT NULL,
    sup_phone VARCHAR(20) NOT NULL,
    sup_start_date DATE DEFAULT CAST(GETDATE() AS DATE),
    sup_description NVARCHAR(MAX) NOT NULL
);

-- Bảng Khách hàng
CREATE TABLE Customers (
    cus_ID INT IDENTITY(1,1) PRIMARY KEY,
    cus_name NVARCHAR(255) NOT NULL,
    cus_address NVARCHAR(MAX),
    cus_phone VARCHAR(20)
);

-- Bảng Nhân viên
CREATE TABLE Employees (
    emp_ID INT IDENTITY(1,1) PRIMARY KEY,
    emp_name NVARCHAR(255) NOT NULL,
    emp_date_of_birth DATE NOT NULL,
    emp_phone VARCHAR(20) NOT NULL,
    emp_address NVARCHAR(MAX) NOT NULL,
    emp_salary DECIMAL(18,2) DEFAULT 5000000,
    emp_start_date DATE DEFAULT CAST(GETDATE() AS DATE),
    emp_username VARCHAR(50) UNIQUE,
    emp_password VARCHAR(255),
    emp_role VARCHAR(50) DEFAULT 'Employee' -- 'Admin' hoặc 'Employee'
);

-- Bảng Loại sản phẩm
CREATE TABLE ProductTypes (
    type_ID INT IDENTITY(1,1) PRIMARY KEY,
    type_name NVARCHAR(255) NOT NULL UNIQUE
);

-- Bảng Sản phẩm
CREATE TABLE Products (
    pro_ID INT IDENTITY(1,1) PRIMARY KEY,
    pro_name NVARCHAR(255) NOT NULL,
    pro_price DECIMAL(18,2) NOT NULL,
    pro_count INT DEFAULT 0,
    pro_description NVARCHAR(MAX),
    type_ID INT,
    sup_ID INT,
    FOREIGN KEY (type_ID) REFERENCES ProductTypes(type_ID),
    FOREIGN KEY (sup_ID) REFERENCES Suppliers(sup_ID)
);

-- Bảng Hóa đơn
CREATE TABLE Invoices (
    inv_ID INT IDENTITY(1,1) PRIMARY KEY,
    emp_ID INT,
    cus_ID INT,
    inv_price DECIMAL(18,2) DEFAULT 0,
    inv_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (emp_ID) REFERENCES Employees(emp_ID),
    FOREIGN KEY (cus_ID) REFERENCES Customers(cus_ID)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE Invoice_details (
    ind_ID INT IDENTITY(1,1) PRIMARY KEY,
    inv_ID INT,
    pro_ID INT,
    ind_count INT NOT NULL,
    unit_price DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (inv_ID) REFERENCES Invoices(inv_ID) ON DELETE CASCADE,
    FOREIGN KEY (pro_ID) REFERENCES Products(pro_ID)
);
GO

-- ===================
-- 3. CHÈN DỮ LIỆU MẪU
-- ===================

-- 3.1. Nhà cung cấp (Suppliers)
INSERT INTO Suppliers (sup_name, sup_address, sup_phone, sup_description) VALUES
(N'Công ty TNHH Thực Phẩm Sạch', N'123 Nguyễn Trãi, Q.1, TP.HCM', '0901234567', N'Chuyên cung cấp thực phẩm tươi sống, rau củ quả sạch.'),
(N'Vinamilk', N'10 Tân Trào, P. Tân Phú, Q.7, TP.HCM', '02854155555', N'Sữa tươi, sữa chua, phô mai và các sản phẩm từ sữa.'),
(N'Unilever Việt Nam', N'105 Tôn Dật Tiên, Q.7, TP.HCM', '02854135686', N'Hàng tiêu dùng nhanh: OMO, Dove, Sunsilk, Knorr...'),
(N'Công ty CP Acecook', N'10 Tân Trào, P. Tân Phú, Q.7, TP.HCM', '02837761234', N'Mì ăn liền Hảo Hảo, phở Đệ Nhất, bún Hằng Nga.'),
(N'PepsiCo Việt Nam', N'KCN Amata, Biên Hòa, Đồng Nai', '02513999999', N'Nước giải khát Pepsi, 7Up, Mirinda, Sting, Aquafina.'),
(N'Nestlé Việt Nam', N'10 Tân Trào, P. Tân Phú, Q.7, TP.HCM', '02839113737', N'Milo, Nescafé, Maggi, KitKat.'),
(N'Công ty CP Masan', N'Tầng 8, Central Plaza, 17 Lê Duẩn, Q.1', '02862563862', N'Nước mắm Nam Ngư, tương ớt Chinsu, mì Omachi.'),
(N'Heineken Việt Nam', N'Tầng 10, Bitexco, 2 Hải Triều, Q.1', '02838222755', N'Bia Heineken, Tiger, Larue, nước táo Strongbow.'),
(N'Công ty TNHH Nước Giải Khát Coca-Cola', N'KCN Thủ Đức, P. Linh Trung, TP. Thủ Đức', '02838961000', N'Coca-Cola, Sprite, Fanta, Nutriboost.'),
(N'Công ty CP Bánh Kẹo Kinh Đô', N'138-142 Hai Bà Trưng, P. Đa Kao, Q.1', '02838270838', N'Bánh Cosy, Solite, AFC, bánh trung thu.');

-- 3.2. Loại sản phẩm (ProductTypes)
INSERT INTO ProductTypes (type_name) VALUES
(N'Thực phẩm tươi sống'),
(N'Đồ uống & Giải khát'),
(N'Sữa & Chế phẩm từ sữa'),
(N'Gia vị & Đồ khô'),
(N'Bánh kẹo & Đồ ăn vặt'),
(N'Hóa mỹ phẩm'),
(N'Đồ dùng gia đình'),
(N'Văn phòng phẩm'),
(N'Thực phẩm đông lạnh'),
(N'Mẹ & Bé');

-- 3.3. Sản phẩm (Products)
INSERT INTO Products (pro_name, pro_price, pro_count, pro_description, type_ID, sup_ID) VALUES
(N'Thịt ba chỉ heo (500g)', 85000, 50, N'Thịt heo sạch chuẩn VietGAP', 1, 1),
(N'Cá hồi phi lê (300g)', 150000, 30, N'Cá hồi Na Uy tươi ngon', 1, 1),
(N'Gà ta thả vườn (1 con)', 180000, 20, N'Gà ta làm sạch, đóng gói hút chân không', 1, 1),
(N'Trứng gà ta (vỉ 10 quả)', 35000, 100, N'Trứng gà tươi mới mỗi ngày', 1, 1),
(N'Rau muống sạch (500g)', 15000, 80, N'Rau trồng thủy canh', 1, 1),
(N'Nước ngọt Pepsi (Lon 330ml)', 10000, 200, N'Vị cola truyền thống', 2, 5),
(N'Nước ngọt 7Up (Chai 1.5L)', 18000, 150, N'Vị chanh tươi mát', 2, 5),
(N'Bia Heineken (Thùng 24 lon)', 420000, 50, N'Bia thượng hạng từ Hà Lan', 2, 8),
(N'Nước suối Aquafina (Chai 500ml)', 5000, 300, N'Nước tinh khiết', 2, 5),
(N'Trà ô long Tea+ (Chai 450ml)', 12000, 120, N'Giúp hạn chế hấp thu chất béo', 2, 5),
(N'Sữa tươi Vinamilk 100% (Hộp 1L)', 32000, 100, N'Sữa tươi tiệt trùng không đường', 3, 2),
(N'Sữa chua Vinamilk Nha Đam (Lốc 4 hộp)', 28000, 80, N'Sữa chua ăn liền vị nha đam', 3, 2),
(N'Sữa đặc Ông Thọ (Lon 380g)', 22000, 150, N'Sữa đặc có đường', 3, 2),
(N'Sữa Milo lúa mạch (Lốc 4 hộp 180ml)', 29000, 200, N'Thức uống lúa mạch năng lượng', 3, 6),
(N'Phô mai Con Bò Cười (Hộp 8 miếng)', 35000, 60, N'Phô mai tam giác', 3, 2),
(N'Mì Hảo Hảo Tôm Chua Cay (Thùng 30 gói)', 115000, 100, N'Mì quốc dân', 4, 4),
(N'Nước mắm Nam Ngư (Chai 750ml)', 38000, 120, N'Vị ngon đậm đà', 4, 7),
(N'Tương ớt Chinsu (Chai 250g)', 15000, 200, N'Cay nồng, thơm ngon', 4, 7),
(N'Dầu ăn Neptune (Chai 1L)', 45000, 90, N'Dầu thực vật cao cấp', 4, 7),
(N'Gạo ST25 (Túi 5kg)', 180000, 40, N'Gạo ngon nhất thế giới', 4, 1),
(N'Bánh quy bơ Cosy (Gói 200g)', 25000, 80, N'Bánh quy giòn tan', 5, 10),
(N'Snack khoai tây Lay''s (Gói 65g)', 12000, 150, N'Vị tảo biển', 5, 5),
(N'Kẹo KitKat trà xanh (Gói 12 thanh)', 65000, 50, N'Vị trà xanh Nhật Bản', 5, 6),
(N'Bánh ChocoPie (Hộp 12 cái)', 55000, 70, N'Bánh bông lan kem socola', 5, 10),
(N'Kẹo dẻo Chip Chip (Gói 100g)', 15000, 100, N'Kẹo dẻo trái cây', 5, 10),
(N'Dầu gội Sunsilk Bồ Kết (Chai 650g)', 120000, 60, N'Óng mượt rạng ngời', 6, 3),
(N'Sữa tắm Lifebuoy (Chai 850g)', 150000, 50, N'Bảo vệ khỏi vi khuẩn', 6, 3),
(N'Bột giặt OMO Matic (Túi 3kg)', 180000, 40, N'Giặt máy cửa trên', 6, 3),
(N'Nước xả vải Comfort (Túi 1.8L)', 110000, 50, N'Hương ban mai', 6, 3),
(N'Kem đánh răng P/S (Tuýp 240g)', 35000, 100, N'Bảo vệ 123', 6, 3),
(N'Giấy vệ sinh Pulppy (Lốc 10 cuộn)', 85000, 60, N'Mềm mại, dai', 7, 3),
(N'Nước rửa chén Sunlight (Chai 750g)', 28000, 120, N'Chiết xuất chanh tươi', 7, 3),
(N'Khăn giấy ướt (Gói 100 tờ)', 30000, 80, N'Không mùi, an toàn cho da', 7, 3),
(N'Túi đựng rác tự hủy (Cuộn 1kg)', 45000, 100, N'Thân thiện môi trường', 7, 1),
(N'Màng bọc thực phẩm (Cuộn 30m)', 25000, 90, N'Giữ thực phẩm tươi lâu', 7, 1),
(N'Bút bi Thiên Long (Hộp 20 cây)', 80000, 50, N'Mực xanh, ngòi 0.5mm', 8, 1),
(N'Tập học sinh 96 trang (Lốc 10 quyển)', 65000, 40, N'Giấy trắng, không lem', 8, 1),
(N'Băng keo trong (Cuộn lớn)', 15000, 100, N'Dính chắc', 8, 1),
(N'Kéo văn phòng (Cây)', 20000, 60, N'Lưỡi thép không gỉ', 8, 1),
(N'Giấy A4 Double A (Ram 500 tờ)', 75000, 30, N'Định lượng 70gsm', 8, 1),
(N'Chả giò rế tôm thịt (Gói 500g)', 65000, 40, N'Giòn rụm', 9, 1),
(N'Xúc xích Đức (Gói 500g)', 70000, 50, N'Thơm ngon', 9, 1),
(N'Cá viên chiên (Gói 500g)', 55000, 60, N'Dai ngon', 9, 1),
(N'Há cảo (Gói 300g)', 45000, 40, N'Nhân thịt heo', 9, 1),
(N'Khoai tây chiên cọng (Gói 1kg)', 85000, 30, N'Nhập khẩu Bỉ', 9, 1),
(N'Tã quần Bobby size L (Gói 54 miếng)', 280000, 30, N'Thấm hút siêu tốc', 10, 3),
(N'Sữa bột Similac (Lon 900g)', 450000, 20, N'Dành cho trẻ 1-3 tuổi', 10, 6),
(N'Phấn rôm Johnson Baby (Chai 200g)', 45000, 50, N'Ngừa rôm sảy', 10, 3),
(N'Bình sữa Pigeon (Chai 250ml)', 150000, 20, N'Nhựa PP an toàn', 10, 1),
(N'Nước giặt đồ em bé D-nee (Túi 3L)', 190000, 25, N'Hương thơm dịu nhẹ', 10, 1);

-- 3.4. Khách hàng (Customers)
INSERT INTO Customers (cus_name, cus_address, cus_phone) VALUES
(N'Khách vãng lai', N'N/A', '0000000000'),
(N'Nguyễn Văn An', N'12 Lê Lợi, Q.1, TP.HCM', '0909123456'),
(N'Trần Thị Bích', N'34 Nguyễn Huệ, Q.1, TP.HCM', '0918654321'),
(N'Lê Hoàng Cường', N'56 Pasteur, Q.1, TP.HCM', '0933789012'),
(N'Phạm Minh Dũng', N'78 Hai Bà Trưng, Q.3, TP.HCM', '0977112233'),
(N'Hoàng Thị Em', N'90 Võ Thị Sáu, Q.3, TP.HCM', '0988445566'),
(N'Vũ Tuấn Phong', N'102 Điện Biên Phủ, Q.3, TP.HCM', '0966778899'),
(N'Đặng Thu Hà', N'15 Cách Mạng Tháng 8, Q.10, TP.HCM', '0944556677'),
(N'Bùi Văn Hùng', N'27 Ba Tháng Hai, Q.10, TP.HCM', '0911223344'),
(N'Đỗ Thị Lan', N'39 Lý Thường Kiệt, Q.10, TP.HCM', '0905678901'),
(N'Ngô Văn Kiên', N'51 Nguyễn Tri Phương, Q.10, TP.HCM', '0934567890'),
(N'Dương Thị Mai', N'63 Thành Thái, Q.10, TP.HCM', '0978901234'),
(N'Lý Văn Nam', N'75 Sư Vạn Hạnh, Q.10, TP.HCM', '0989012345'),
(N'Trịnh Thị Oanh', N'87 Tô Hiến Thành, Q.10, TP.HCM', '0961234567'),
(N'Mai Văn Phúc', N'99 Lữ Gia, Q.11, TP.HCM', '0945678901'),
(N'Cao Thị Quyên', N'111 Lê Đại Hành, Q.11, TP.HCM', '0912345678'),
(N'Phan Văn Rạng', N'123 Ông Ích Khiêm, Q.11, TP.HCM', '0903456789'),
(N'Hồ Thị Sương', N'135 Lạc Long Quân, Q.11, TP.HCM', '0935678901'),
(N'Đinh Văn Tài', N'147 Bình Thới, Q.11, TP.HCM', '0976789012'),
(N'Lâm Thị Uyên', N'159 Minh Phụng, Q.11, TP.HCM', '0987890123');

-- 3.5. Nhân viên (Employees)
INSERT INTO Employees (emp_name, emp_date_of_birth, emp_phone, emp_address, emp_salary, emp_start_date, emp_username, emp_password, emp_role) VALUES
(N'Nguyễn Quản Trị', '1990-01-01', '0909999999', N'TP.HCM', 20000000, '2020-01-01', 'admin', '123', 'Admin'),
(N'Trần Quản Lý', '1992-05-15', '0908888888', N'TP.HCM', 15000000, '2021-03-10', 'manager', '123', 'Employee'),
(N'Lê Bán Hàng 1', '1995-08-20', '0907777777', N'TP.HCM', 8000000, '2022-06-01', 'sale1', '123', 'Employee'),
(N'Phạm Bán Hàng 2', '1998-12-12', '0906666666', N'TP.HCM', 7500000, '2023-01-15', 'sale2', '123', 'Employee'),
(N'Hoàng Kho 1', '1993-04-30', '0905555555', N'TP.HCM', 9000000, '2021-09-05', 'storage1', '123', 'Employee'),
(N'Vũ Kho 2', '1996-10-10', '0904444444', N'TP.HCM', 8500000, '2022-11-20', 'storage2', '123', 'Employee');

-- 3.6. Hóa đơn (Invoices) & Chi tiết (Invoice_details)

-- Hóa đơn 1
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 2, 250000, '2023-12-20 10:30:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(1, 1, 1, 85000), 
(1, 11, 2, 32000), 
(1, 16, 1, 115000); 

-- Hóa đơn 2
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 3, 520000, '2024-01-15 14:15:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(2, 8, 1, 420000), 
(2, 22, 5, 12000), 
(2, 6, 4, 10000); 

-- Hóa đơn 3
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 1, 150000, '2024-02-10 09:00:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(3, 26, 1, 120000), 
(3, 30, 1, 35000); 

-- Hóa đơn 4
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 5, 850000, '2024-03-08 18:45:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(4, 42, 1, 450000), 
(4, 41, 1, 280000), 
(4, 45, 1, 190000); 

-- Hóa đơn 5
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 8, 320000, '2024-04-30 11:20:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(5, 2, 1, 150000), 
(5, 3, 1, 180000); 

-- Hóa đơn 6
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 10, 95000, '2024-05-01 08:30:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(6, 36, 1, 80000), 
(6, 38, 1, 15000); 

-- Hóa đơn 7
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 12, 210000, '2024-06-01 16:00:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(7, 14, 5, 29000), 
(7, 15, 2, 35000); 

-- Hóa đơn 8
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 15, 450000, '2024-07-15 19:30:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(8, 28, 2, 180000), 
(8, 29, 1, 110000); 

-- Hóa đơn 9
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 18, 125000, '2024-08-20 10:00:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(9, 21, 2, 25000), 
(9, 23, 1, 65000), 
(9, 25, 1, 15000); 

-- Hóa đơn 10
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 20, 300000, '2024-09-02 12:45:00');
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(10, 31, 2, 85000), 
(10, 32, 2, 28000), 
(10, 34, 2, 45000); 

-- Hóa đơn 11 (2 tiếng trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 4, 180000, DATEADD(hour, -2, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(11, 20, 1, 180000); 

-- Hóa đơn 12 (4 tiếng trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 6, 60000, DATEADD(hour, -4, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(12, 9, 12, 5000); 

-- Hóa đơn 13 (Hôm qua)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 7, 220000, DATEADD(day, -1, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(13, 42, 1, 70000), 
(13, 43, 2, 55000), 
(13, 44, 1, 45000); 

-- Hóa đơn 14 (Hôm qua)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 9, 500000, DATEADD(day, -1, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(14, 8, 1, 420000), 
(14, 7, 5, 18000); 

-- Hóa đơn 15 (3 ngày trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 11, 150000, DATEADD(day, -3, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(15, 1, 1, 85000), 
(15, 5, 2, 15000), 
(15, 4, 1, 35000); 

-- Hóa đơn 16 (4 ngày trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 13, 90000, DATEADD(day, -4, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(16, 19, 2, 45000); 

-- Hóa đơn 17 (5 ngày trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 14, 250000, DATEADD(day, -5, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(17, 40, 1, 75000), 
(17, 37, 2, 65000), 
(17, 39, 2, 20000); 

-- Hóa đơn 18 (6 ngày trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 16, 110000, DATEADD(day, -6, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(18, 24, 2, 55000); 

-- Hóa đơn 19 (Tuần trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (3, 17, 350000, DATEADD(day, -8, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(19, 27, 2, 150000), 
(19, 33, 2, 30000); 

-- Hóa đơn 20 (Tháng trước)
INSERT INTO Invoices (emp_ID, cus_ID, inv_price, inv_date) VALUES (4, 19, 180000, DATEADD(day, -35, GETDATE()));
INSERT INTO Invoice_details (inv_ID, pro_ID, ind_count, unit_price) VALUES
(20, 3, 1, 180000);
GO

SELECT * FROM Employees;
GO