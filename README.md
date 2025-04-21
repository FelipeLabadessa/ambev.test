# Ambev Developer Evaluation API

This is a .NET API project using PostgreSQL as the database and JWT for authentication. The project is ready to run locally with Docker.

---

## Starting the Application

1. **Clone the repository and navigate to the project root.**
2. **Run Docker Compose to start the PostgreSQL database:**

```bash
docker compose up -d
```

> This will start PostgreSQL on the default port (`5432`).

3. **Run the API (.NET) as usual.**

- Migrations and seed data will be applied automatically on startup.

---

## Authentication

To access the protected endpoints of the application, you must authenticate first.

### Admin Credentials (full access):

- **User:** `admin@ambev.com`
- **Password:** `Teste@123`

### After logging in:

1. A **JWT token** will be returned.
2. Use this token to authenticate in other endpoints via the `Authorization` header:

```
Bearer {your_token_here}
```

---

## Running the Tests

To validate the business rules of the application, run the tests using:

```
Run All Tests
```

> This will execute all automated tests and ensure that the application logic works correctly.

---

## Ready to Use

With the API running, the database connected, and authentication completed, you’re ready to explore the application with full administrator permissions.

---

## Technologies Used

- .NET 8
- PostgreSQL
- Docker / Docker Compose
- JWT (Authentication)
- xUnit (Testing)

---
