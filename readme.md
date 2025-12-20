# 🧑‍💼 Employee Management API

REST API for managing employees of a fictitious company, developed with **.NET 8**, applying **Clean Architecture**, **CQRS**, **JWT Authentication**, **Entity Framework Core**, and **Docker**.

---

## 🏗️ Architecture

The project follows **Clean Architecture**, organized into layers:

```
EmployeeManagement
│
├── Api              # Controllers, Authentication, Swagger, IoC
├── Application      # CQRS, Commands, Queries, Handlers
├── Domain           # Entities, Business Rules
├── Infrastructure   # EF Core, Repositories, Auth, JWT
├── Tests            # Domain and handler tests
```

### Applied Patterns
- ✅ Clean Architecture
- ✅ CQRS with MediatR
- ✅ Repository Pattern
- ✅ JWT Authentication
- ✅ Domain-Driven Design (DDD - light approach)

---

## 🔐 Authentication (JWT)

Authentication is handled using **JWT**, based on email and password.

### Login Endpoint
```http
POST /api/auth/login
```

#### Example request:
```json
{
  "email": "admin@admin.com",
  "password": "admin@123"
}
```

#### Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

## 👑 Master User (Bootstrap Seed)

When the application starts, a **master admin user** is automatically created:

```text
Email: admin@admin.com
Password: admin@123
Role: Director
```

This ensures the system is usable immediately, both **locally** and **via Docker**, without manual database setup.

---

## 📦 Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR
- BCrypt
- JWT (Microsoft Identity)
- Docker & Docker Compose
- Swagger / OpenAPI
- xUnit (Tests)

---

## 🐳 Running with Docker (recommended)

### Prerequisites
- Docker
- Docker Compose

### Start the application
```bash
docker compose up --build
```

The API will be available at:
```
http://localhost:8080/swagger
```

---

## ▶️ Running Locally (without Docker)

### Prerequisites
- .NET 8 SDK
- SQL Server or LocalDB

### Steps
```bash
dotnet restore
dotnet ef database update
dotnet run --project Api
```

---

## 📚 Main Endpoints

### Auth
- `POST /api/auth/login`

### Employees
- `POST /api/employees`
- `GET /api/employees`
- `GET /api/employees/{id}`
- `PUT /api/employees/{id}`
- `DELETE /api/employees/{id}`

All endpoints (except login) require a **valid JWT token**.

---

## 📊 Logging & Error Handling

The application uses a global exception handling middleware to centralize logging and error responses.

- Business rule violations (domain exceptions) are logged as warnings.
- Unexpected or technical failures are logged as errors.
- Expected flows (such as invalid credentials) are not treated as exceptions.

---

## 🧪 Tests

The project includes tests focused on:

- Domain business rules
- Employee creation
- Role hierarchy validation

Run tests with:
```bash
dotnet test
```





