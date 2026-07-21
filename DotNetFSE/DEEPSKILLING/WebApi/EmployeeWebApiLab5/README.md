# Employee Web API - Lab 5 (JWT Authentication)

## Objective

This lab demonstrates securing ASP.NET Core Web APIs using JSON Web Token (JWT) Authentication.

The API generates JWT tokens, validates incoming tokens, authorizes users, and supports role-based authorization.

---

## Technologies Used

- ASP.NET Core Web API (.NET 10)
- C#
- JWT Authentication
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swagger
- Postman
- Visual Studio 2022

---

## Project Structure

```
EmployeeWebApiLab5
│
├── Controllers
│   ├── AuthController.cs
│   └── EmployeeController.cs
│
├── Models
│   ├── Employee.cs
│   ├── Department.cs
│   └── Skill.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## Features

- JWT Token Generation
- JWT Authentication
- Authorization
- Role-Based Authorization
- Secure Employee API
- Swagger Support
- Postman Testing

---

## JWT Configuration

Authentication uses

```
Bearer Token
```

Issuer

```
mySystem
```

Audience

```
myUsers
```

Security Key

```
mysuperdupersecretkey123456789012
```

---

## API Endpoints

### Generate JWT

```
GET /api/Auth
```

Returns

```
JWT Token
```

---

### Protected API

```
GET /api/Employee
```

Requires

```
Authorization: Bearer <token>
```

---

## Authentication Flow

```
Client

↓

GET /api/Auth

↓

JWT Token Generated

↓

Copy Token

↓

Authorization
Bearer Token

↓

GET /api/Employee

↓

200 OK
```

---

## Testing in Postman

### Generate Token

```
GET

https://localhost:<port>/api/Auth
```

Copy the generated token.

---

### Access Employee API

```
GET

https://localhost:<port>/api/Employee
```

Authorization

```
Bearer Token
```

Paste the JWT token.

---

## JWT Test Cases

### Without Token

Request

```
GET /api/Employee
```

Expected

```
401 Unauthorized
```

---

### Valid Token

Expected

```
200 OK
```

Employee list returned.

---

### Invalid Token

Modify one character.

Expected

```
401 Unauthorized
```

---

### Expired Token

Set

```
expires: DateTime.Now.AddMinutes(2)
```

Wait two minutes.

Expected

```
401 Unauthorized
```

---

### Role-Based Authorization

```
[Authorize(Roles="POC")]
```

Admin token

Expected

```
403 Forbidden
```

or

```
401 Unauthorized
```

depending on configuration.

---

```
[Authorize(Roles="Admin,POC")]
```

Expected

```
200 OK
```

---

## Running the Project

Build

```
Ctrl + Shift + B
```

Run

```
F5
```

Swagger

```
https://localhost:<port>/swagger
```

---

## Required NuGet Packages

```
Microsoft.AspNetCore.Authentication.JwtBearer

Microsoft.IdentityModel.Tokens

Swashbuckle.AspNetCore
```

---

## HTTP Status Codes

| Status | Meaning |
|---------|---------|
|200|OK|
|401|Unauthorized|
|403|Forbidden|

---

## Learning Outcomes

- JWT Authentication
- Bearer Token Authentication
- Claims
- Authorization
- Role-Based Authorization
- ASP.NET Core Security
- Swagger
- Postman
- Secure REST APIs

---

## Author

Bhavana
