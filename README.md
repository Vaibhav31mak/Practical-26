# Practical26

## Overview

Practical26 is a .NET 10 ASP.NET Core Web API implementing the CQRS (Command Query Responsibility Segregation) pattern using MediatR, FluentValidation, EF Core, and Clean Architecture.

The solution separates:
- Write operations using Command Repositories
- Read operations using Query Repositories

This improves maintainability, scalability, and separation of concerns.

---

# Technologies

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- AutoMapper
- Swagger/OpenAPI

---

# CQRS Flow

## Command Flow

```text
Controller
   ↓
Command
   ↓
Handler
   ↓
Command Repository
   ↓
Command Unit Of Work
   ↓
Database
```

## Query Flow

```text
Controller
   ↓
Query
   ↓
Handler
   ↓
Query Repository
   ↓
AsNoTracking()
   ↓
Database
```

---

# Project Structure

```text
Practical26.Api
│
├── Controllers
│   └── EmployeesController.cs
│
├── Middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Program.cs
└── appsettings.json

Practical26.Application
│
├── Features
│   └── Employees
│       ├── Commands
│       ├── Queries
│       ├── Handlers
│       ├── Validators
│       ├── CommandModels
│       │   └── UpdateEmployeeModel.cs
│       │
│       └── QueryModels
│
└── Behaviours

Practical26.DAL
│
├── Context
│   └── ApplicationDbContext.cs
│
├── Repositories
│   ├── Command
│   └── Query
│
├── UnitOfWork
│
└── Seeders
│   └── DatabaseSeeder.cs

Practical26.Domain
│
└── Entities
    └── Employee.cs
```

---

# API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | /api/employees | Create employee |
| PUT | /api/employees | Update employee |
| DELETE | /api/employees/{id} | Soft Delete employee |
| GET | /api/employees | Get all employees |
| GET | /api/employees/{id} | Get employee by id |

---

# Run The Project

## Prerequisites

- .NET 10 SDK
- SQL Server
- Visual Studio 2022 / VS Code

---

# Configure Connection String

Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=Practical26Db;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

# Apply Migrations

```bash
Add-Migration InitialCreate -Project Practical26.DAL -StartupProject Practical26.Api
```

```bash
Update-Database -Project Practical26.DAL -StartupProject Practical26.Api
```

---

# Run API

```bash
dotnet run --project Practical26.Api
```

Swagger:

```text
https://localhost:{port}/swagger
```

---

# Features

- CQRS architecture
- MediatR request handling
- FluentValidation pipeline validation
- Separate command/query repositories
- Command-side Unit Of Work
- EF Core with SQL Server
- AutoMapper integration
- Global exception handling
- Clean Architecture
- Async/Await support
