# Course Management API

## 📌 Description
This is a RESTful Web API built using ASP.NET Core for managing students and courses.  
It uses Entity Framework Core for database operations and JWT for authentication and authorization.

---

## 🛠 Technologies Used
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

---

## ▶ How to Run the Project

1. Open terminal in project folder
2. Run the following command:

   dotnet run

3. Open browser and go to:

   http://localhost:5160/swagger

---

## 🔐 Authentication

- Use endpoint:

  POST /api/auth/login

- Copy the token from response

- Click "Authorize" in Swagger and enter:

  Bearer YOUR_TOKEN

---

## 🔒 Security

JWT is used for securing the API.  
Only authenticated users can access protected endpoints.

HTTP-only cookies are secure because they cannot be accessed by JavaScript, which protects them from XSS attacks.

---

## 📸 Features

- Create Student
- Get Students
- Authentication using JWT
- Authorization using roles
