USE [LaptopECommerce];
GO

-- Xóa dữ liệu cũ để tránh trùng lặp
DELETE FROM [Laptops];
GO

INSERT INTO [Laptops] ([LaptopId], [Name], [Brand], [CPU], [RAM], [Storage], [GraphicsCard], [Price], [ImageURL], [CreatedDate])
VALUES 
-- APPLE (Phong cách sang trọng, tối giản)
(NEWID(), N'MacBook Pro 14 M3', N'Apple', N'Apple M3 Chip', N'16GB', N'512GB SSD', N'10-core GPU', 45000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777218562/MacBook_Pro_14_M3_ep6777.jpg', GETDATE()),
(NEWID(), N'MacBook Air 13 M2', N'Apple', N'Apple M2 Chip', N'8GB', N'256GB SSD', N'8-core GPU', 26000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219068/MacBook_Air_13_M2_jjehbx.png', GETDATE()),
(NEWID(), N'MacBook Pro 16 M3 Max', N'Apple', N'Apple M3 Max', N'32GB', N'1TB SSD', N'40-core GPU', 92000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219069/MacBook_Pro_16_M3_Max_rott0n.png', GETDATE()),

-- SAMSUNG (Mỏng nhẹ, màn hình đẹp)
(NEWID(), N'Galaxy Book4 Ultra', N'Samsung', N'Intel Core Ultra 7', N'32GB', N'1TB SSD', N'RTX 4050', 58000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219069/Galaxy_Book4_Ultra_ghbmdm.jpg', GETDATE()),
(NEWID(), N'Galaxy Book3 Pro 360', N'Samsung', N'Intel Core i7-1360P', N'16GB', N'512GB SSD', N'Intel Iris Xe', 34000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219069/Galaxy_Book3_Pro_360_vb9fbz.jpg', GETDATE()),
(NEWID(), N'Galaxy Book Odyssey', N'Samsung', N'Intel Core i7-11600H', N'16GB', N'512GB SSD', N'RTX 3050Ti', 25000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219067/Galaxy_Book_Odyssey_nokazx.jpg', GETDATE()),

-- MSI (Gaming hầm hố, LED RGB)
(NEWID(), N'MSI Raider GE78 HX', N'MSI', N'Core i9-13980HX', N'64GB', N'2TB SSD', N'RTX 4090', 115000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219067/MSI_Raider_GE78_HX_xlwifh.jpg', GETDATE()),
(NEWID(), N'MSI Katana 15', N'MSI', N'Core i7-13620H', N'16GB', N'512GB SSD', N'RTX 4060', 28500000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219067/MSI_Katana_15_baaglu.png', GETDATE()),
(NEWID(), N'MSI Stealth 14 Studio', N'MSI', N'Core i7-13700H', N'16GB', N'1TB SSD', N'RTX 4050', 39000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219068/MSI_Stealth_14_s3ubzt.jpg', GETDATE()),

-- ASUS (Đa dạng từ Gaming ROG đến Zenbook OLED)
(NEWID(), N'ASUS ROG Zephyrus G14', N'ASUS', N'Ryzen 9 7940HS', N'16GB', N'1TB SSD', N'RTX 4060', 39500000, 'https://images.unsplash.com/photo-1616763355548-1b606f439f86?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'ASUS Zenbook 14 OLED', N'ASUS', N'Core i5-1340P', N'16GB', N'512GB SSD', N'Intel Iris Xe', 24500000, 'https://images.unsplash.com/photo-1496181133206-80ce9b88a853?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'ASUS Vivobook 15', N'ASUS', N'Core i5-12500H', N'8GB', N'512GB SSD', N'Intel UHD', 13500000, 'https://images.unsplash.com/photo-1580522154071-c6ca47a859ad?auto=format&fit=crop&q=80&w=800', GETDATE()),

-- ACER (Dòng Predator mạnh mẽ và Nitro quốc dân)
(NEWID(), N'Acer Predator Helios Neo 16', N'ACER', N'Core i7-13700HX', N'16GB', N'512GB SSD', N'RTX 4060', 36000000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219067/Acer_Predator_Helios_Neo_16_zfmhpc.jpg', GETDATE()),
(NEWID(), N'Acer Swift Go 14', N'ACER', N'Core i5-13500H', N'16GB', N'512GB SSD', N'Intel Iris Xe', 18500000, 'https://res.cloudinary.com/dl5gcr6xk/image/upload/v1777219353/acer_swift_go_14_vjxibt.jpg', GETDATE()),
(NEWID(), N'Acer Nitro V 15', N'ACER', N'Core i5-13420H', N'8GB', N'512GB SSD', N'RTX 2050', 16500000, 'https://images.unsplash.com/photo-1593642632823-8f785ba67e45?auto=format&fit=crop&q=80&w=800', GETDATE()),

-- LENOVO (ThinkPad doanh nhân và Legion gaming)
(NEWID(), N'Lenovo Legion Slim 5', N'Lenovo', N'Ryzen 7 7840HS', N'16GB', N'512GB SSD', N'RTX 4060', 32000000, 'https://images.unsplash.com/photo-1611078489935-0cb964de46d6?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Lenovo ThinkPad X1 Carbon Gen 11', N'Lenovo', N'Core i7-1355U', N'16GB', N'512GB SSD', N'Intel Iris Xe', 42000000, 'https://images.unsplash.com/photo-1585241645927-c7a8e5840c42?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Lenovo IdeaPad 3', N'Lenovo', N'Ryzen 5 5500U', N'8GB', N'256GB SSD', N'AMD Radeon', 10500000, 'https://images.unsplash.com/photo-1618424181497-157f25b6ddd5?auto=format&fit=crop&q=80&w=800', GETDATE()),

-- ALIENWARE (Thiết kế phi thuyền đặc trưng)
(NEWID(), N'Alienware m16 R2', N'Alienware', N'Core Ultra 7 155H', N'16GB', N'1TB SSD', N'RTX 4060', 55000000, 'https://images.unsplash.com/photo-1525547719571-a2d4ac8945e2?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Alienware x14 R2', N'Alienware', N'Core i7-13620H', N'16GB', N'512GB SSD', N'RTX 4050', 48000000, 'https://images.unsplash.com/photo-1624701928517-44c8ac49d93c?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Alienware m18 R1', N'Alienware', N'Core i9-13980HX', N'32GB', N'1TB SSD', N'RTX 4080', 85000000, 'https://images.unsplash.com/photo-1542751371-adc38448a05e?auto=format&fit=crop&q=80&w=800', GETDATE()),

-- DELL (XPS cao cấp và Inspiron phổ thông)
(NEWID(), N'Dell XPS 15 9530', N'Dell', N'Core i7-13700H', N'32GB', N'1TB SSD', N'RTX 4050', 52500000, 'https://images.unsplash.com/photo-1593305841991-05c297ba4575?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Dell Inspiron 14 5430', N'Dell', N'Core i5-1335U', N'16GB', N'512GB SSD', N'Intel Iris Xe', 18000000, 'https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?auto=format&fit=crop&q=80&w=800', GETDATE()),
(NEWID(), N'Dell Vostro 3510', N'Dell', N'Core i3-1115G4', N'8GB', N'256GB SSD', N'Intel UHD', 11000000, 'https://images.unsplash.com/photo-1531297484001-80022131f5a1?auto=format&fit=crop&q=80&w=800', GETDATE());
GO