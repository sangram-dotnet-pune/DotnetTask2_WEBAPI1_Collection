# 🚀 EmployeeAPI – ASP.NET Core Web API with Entity Framework Core (SQL Server)

![.NET](https://img.shields.io/badge/.NET-6.0%2B-blueviolet?style=flat-square)
![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux-lightgrey?style=flat-square)

---

## 📘 Project Overview

**EmployeeAPI** is a simple ASP.NET Core Web API project demonstrating how to perform **CRUD operations** using **Entity Framework Core (EF Core)** with **SQL Server**.

The project follows a clean architecture using the **Repository Pattern** and **Dependency Injection**, and integrates **Swagger UI** for testing the endpoints.

---

## 🧩 Features

- ✅ ASP.NET Core Web API Architecture
- ✅ Entity Framework Core with SQL Server
- ✅ Repository Pattern for better code separation
- ✅ Dependency Injection for service management
- ✅ Swagger UI for testing REST APIs
- ✅ Code-First Database Creation using EF Core Migrations

---

## ⚙️ Technologies Used

| Category | Technology |
|-----------|-------------|
| Framework | .NET 8 |
| Language | C# |
| Database | Microsoft SQL Server |
| ORM | Entity Framework Core |
| Tools | Visual Studio / Visual Studio Code |
| API Testing | Swagger (Swashbuckle) |

---

## 🏗️ Setup Instructions

### 1️⃣ Create the Web API Project

Create a new ASP.NET Core Web API project using Visual Studio or CLI.

**Using CLI:**

```bash
dotnet new webapi -n EmployeeAPI
cd EmployeeAPI
```

---

### 2️⃣ Install Required NuGet Packages

Install the EF Core and SQL Server dependencies:

```bash
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
```

**Or using .NET CLI:**

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

### 3️⃣ Create the Model

📁 **Path:** `Models/Employee.cs`

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}
```

---

### 4️⃣ Create the DbContext

📁 **Path:** `Models/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
```

---

### 5️⃣ Add Connection String

📄 **File:** `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

⚠️ **Note:** Replace `YOUR_SERVER_NAME` with your actual SQL Server instance (e.g., `(localdb)\\MSSQLLocalDB`).

---

### 6️⃣ Configure Services in Program.cs

📄 **File:** `Program.cs`

```csharp
using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Default Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

---

### 7️⃣ Add Repository Pattern

📁 **Folder:** `Repository`

**Interface:** `IEmployeeRepository.cs`  
**Class:** `EmployeeRepository.cs`

Implements all CRUD operations for Employee entity using EF Core.

---

### 8️⃣ Run EF Core Migrations

Create and apply initial migration:

```bash
Add-Migration InitialCreate
Update-Database
```

**Or using .NET CLI:**

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

✅ This command creates a new database (`EmployeeDB`) and `Employees` table automatically in SQL Server.

---

### 9️⃣ Create Controller

📁 **Path:** `Controllers/EmployeeController.cs`

Implements REST endpoints (GET, POST, PUT, DELETE) for Employee operations using the repository layer.

---

### 🔟 Run and Test the API

Start the project:

```bash
dotnet run
```

Then open Swagger UI in your browser:

```
https://localhost:5001/swagger
```

You can now test:

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Employee` | Fetch all employees |
| GET | `/api/Employee/{id}` | Get employee by ID |
| POST | `/api/Employee` | Add a new employee |
| PUT | `/api/Employee/{id}` | Update an employee |
| DELETE | `/api/Employee/{id}` | Delete an employee |

---

## 📂 Folder Structure

```
EmployeeAPI/
│
├── Controllers/
│   └── EmployeeController.cs
│
├── Models/
│   ├── Employee.cs
│   └── AppDbContext.cs
│
├── Repository/
│   ├── IEmployeeRepository.cs
│   └── EmployeeRepository.cs
│
├── appsettings.json
├── Program.cs
└── EmployeeAPI.csproj
```

---

## 📷 Recommended Screenshots (for Documentation)

- ✅ Swagger UI showing API endpoints
- ✅ SQL Server database with Employee table
- ✅ Successful `Add-Migration` and `Update-Database` outputs
- ✅ CRUD operations tested in Swagger

---

## 🧠 Learning Outcomes

By completing this project, you will learn:

- ✅ How to create a Web API using ASP.NET Core
- ✅ How to configure EF Core with SQL Server
- ✅ How to apply Migrations for database creation
- ✅ How to implement the Repository Pattern
- ✅ How to test APIs using Swagger

---



## ⭐ Acknowledgements

Special thanks to:

- **Microsoft Docs** – for ASP.NET Core & EF Core guidance
- **Visual Studio** – for providing an excellent IDE for .NET development

---
