# Laptop E-Commerce

A full-stack e-commerce project built with **ASP.NET Core Web API** and **Blazor WebAssembly**, featuring a complete shopping cycle, JWT authentication, and SQL Server integration.

## Architecture
- **Backend**: `LaptopECommerce.Api` - ASP.NET Core 8.0 Web API
  - Handles business logic, Entity Framework Core migrations, and JWT Authentication.
- **Frontend**: `LaptopECommerceWASM` - Blazor WebAssembly (Standalone or Hosted)
  - Provides a single-page application (SPA) client-side experience.
- **Models**: `LaptopECommerce.Models` - Class Library
  - Shared DTOs and Data Models between Frontend and Backend.

## Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or Docker or Hosted DB)
- Visual Studio 2022 (recommended) or VS Code.

## Setup Instructions

### 1. Database Configuration
1. Open the project folder `LaptopECommerce.Api`.
2. Notice the `.env` file is ignored by Git. Create a `.env` file at the root of `LaptopECommerce.Api` using this template:
    ```env
    ConnectionStrings__DefaultConnection=Server=YOUR_SERVER; Database=YOUR_DB; User Id=YOUR_USER; Password=YOUR_PASSWORD; Encrypt=False; MultipleActiveResultSets=True;
    JwtSecurityKey=YOUR_SUPER_SECRET_KEY_HERE
    ```
    *If you don't use `.env`, you can also fill these values inside `appsettings.Development.json` for local development.*

### 2. Run the Application locally
- **Backend**: `cd LaptopECommerce.Api && dotnet run`
  - The API will auto-seed standard dummy data if your DB is empty.
- **Frontend**: `cd LaptopECommerceWASM && dotnet run`
  - Make sure `Program.cs` in WASM properly points to your running localhost API port or use the `builder.HostEnvironment.BaseAddress` approach when testing the hosted environment.

### 3. Production Deployment (MonsterASP.net / IIS)
This project is configured optimally for a **Hosted Blazor WebAssembly** deployment model.
1. Publish `LaptopECommerce.Api`.
2. Publish `LaptopECommerceWASM`.
3. Upload the API `publish` contents to the root of your web environment (e.g. `/wwwroot` on MonsterASP).
4. Do not include `web.config` inside the nested frontend folder.
5. Upload the WASM `wwwroot` contents into an inner `wwwroot` folder that sits alongside your API `.dll`.
6. Configure the `appsettings.json` on the server using your production secrets or supply a production `.env` file.

## Features
- Scalable structured solution separating Models, API, and UI.
- Secure Authentication using JWT tokens.
- Automatic database migrations and data seeding techniques natively integrated.
- Polished, responsive e-commerce web interface.
