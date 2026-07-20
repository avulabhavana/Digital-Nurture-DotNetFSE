# Employee Web API - Lab 4 (CRUD Operations)

## Objective

This lab demonstrates how to perform CRUD (Create, Read, Update, Delete) operations using ASP.NET Core Web API.

The project uses hardcoded employee data and exposes RESTful APIs that can be tested using Swagger UI or Postman.

---

## Technologies Used

- ASP.NET Core Web API (.NET 10)
- C#
- Swagger (OpenAPI)
- Visual Studio 2022
- Postman

---

## Project Structure

```
EmployeeWebApiLab4
│
├── Controllers
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

- Read Employee List
- Add Employee
- Update Employee
- Delete Employee
- Input Validation
- ActionResult Implementation
- Swagger Documentation
- REST API

---

## API Endpoints

### GET

```
GET /api/Employee
```

Returns all employees.

Response

```
200 OK
```

---

### POST

```
POST /api/Employee
```

Adds a new employee.

Response

```
201 Created
```

---

### PUT

```
PUT /api/Employee
```

Updates an employee.

Validation

- Employee Id must be greater than 0.
- Employee Id must exist.

Responses

```
200 OK
400 Bad Request
```

---

### DELETE

```
DELETE /api/Employee/{id}
```

Deletes an employee.

Responses

```
200 OK
400 Bad Request
404 Not Found
```

---

## Employee Model

```
Employee
│
├── Id
├── Name
├── Salary
├── Permanent
├── Department
├── Skills
└── DateOfBirth
```

---

## Running the Project

Open the solution in Visual Studio.

Build the project

```
Ctrl + Shift + B
```

Run the project

```
F5
```

Swagger URL

```
https://localhost:<port>/swagger
```

---

## Testing Using Swagger

### GET

```
GET /api/Employee
```

### POST

```
POST /api/Employee
```

### PUT

```
PUT /api/Employee
```

### DELETE

```
DELETE /api/Employee/{id}
```

---

## Testing Using Postman

Create requests using:

GET

```
https://localhost:<port>/api/Employee
```

POST

```
https://localhost:<port>/api/Employee
```

PUT

```
https://localhost:<port>/api/Employee
```

DELETE

```
https://localhost:<port>/api/Employee/1
```

---

## Validation Implemented

- Invalid Employee Id
- Employee Not Found
- Proper HTTP Status Codes
- ActionResult Responses

---

## HTTP Status Codes

| Status | Meaning |
|---------|---------|
|200|OK|
|201|Created|
|400|Bad Request|
|404|Not Found|

---

## Learning Outcomes

- ASP.NET Core Web API
- CRUD Operations
- REST API Design
- ActionResult
- Swagger
- Postman Testing
- HTTP Status Codes

---

## Author

Jithendra
