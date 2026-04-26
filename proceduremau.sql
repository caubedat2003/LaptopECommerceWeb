USE [LaptopECommerce];
GO

-- 1. GetLaptopsByBrandApple
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandApple]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'Apple'
END
GO

-- 2. GetLaptopsByBrandSamsung
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandSamsung]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'Samsung'
END
GO

-- 3. GetLaptopsByBrandMSI
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandMSI]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'MSI'
END
GO

-- 4. GetLaptopsByBrandASUS
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandASUS]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'ASUS'
END
GO

-- 5. GetLaptopsByBrandACER
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandACER]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'ACER'
END
GO

-- 6. GetLaptopsByBrandLenovo
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandLenovo]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'Lenovo'
END
GO

-- 7. GetLaptopsByBrandAlienware
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandAlienware]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'Alienware'
END
GO

-- 8. GetLaptopsByBrandDell
CREATE OR ALTER PROCEDURE [dbo].[GetLaptopsByBrandDell]
AS
BEGIN
    SELECT * FROM [Laptops] WHERE [Brand] = 'Dell'
END
GO

-- 9. GetShippers (Lấy những User có Role là Shipper)
CREATE OR ALTER PROCEDURE [dbo].[GetShippers]
AS
BEGIN
    SELECT * FROM [AspNetUsers] WHERE [Role] = 'Shipper'
END
GO
