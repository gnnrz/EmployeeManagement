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
  "email": "admin@employee.com",
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
Email: admin@employee.com
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

## 🖥 Frontend

Frontend application responsible for authentication and employee creation flows.

---

### 🧰 Tech Stack

* React
* TypeScript
* Vite
* Axios
* React Router DOM

---

### ▶️ Running the Frontend

```bash
npm install
npm run dev
```

The application will be available at:

```
http://localhost:5173
```

---

### 🔐 Authentication Flow

* Users authenticate using **email and password**
* On successful login, a **JWT token** is returned by the backend
* The token is stored in **localStorage**
* Protected routes require authentication
* Unauthenticated users are redirected to the login page

---

### 🛡 Protected Routes

* Routes such as **Create Employee** are protected using a `ProtectedRoute`
* Access is denied if no JWT token is present

---

### 👤 Employee Creation

After authentication, the user is redirected to the **Create Employee** page.

The form allows creating a new employee with the following fields:

* First name
* Last name
* Email
* Document
* Birth date
* Role selection
* Password
* Two phone numbers

Business rule validations are handled by the backend, and error messages returned by the API are displayed to the user.

On successful creation:

* A success modal is displayed
* The user is redirected back to the login page

---

### 📁 Frontend Structure

```text
frontend/
├── src/
│   ├── auth/           # Authentication context and hooks
│   ├── pages/          # Application pages (Login, Create Employee)
│   ├── routes/         # Routing and protected routes
│   ├── shared/         # Axios instance and shared utilities
│   ├── styles/         # Global styles
│   └── app/            # App entry point
├── vite.config.ts
└── package.json
```






