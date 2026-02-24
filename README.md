# Redarbor Technical Test – Backend (.NET 8)

## Overview

This project implements a Web API following:

- Clean Architecture
- DDD principles
- CQRS (EF Core for writes, Dapper for reads)
- SQL Server (Docker)
- Swagger documentation
- Dockerized environment (API + SQL Server)

The application exposes CRUD endpoints for the `Employee` entity as required in the technical test.

---

## Architecture

- Redarbor.Api → API / Composition Root
- Redarbor.Application → CQRS, Commands & Queries
- Redarbor.Domain → Entities & Business Rules (DDD)
- Redarbor.Infrastructure → EF Core, Dapper, Persistence
- Redarbor.Tests → Unit Tests

---

## Requirements

- Docker Desktop installed

---

## Run the project

From the root folder:

```bash
docker compose up --build
```

This will:

- Start SQL Server container
- Build and start the API container
- Apply EF Core migrations automatically

Expose API at:
```
http://localhost:5000
```
Swagger:
```
http://localhost:5000/swagger
```
### Stop the containers
```bash
docker compose down -v
```
## Available Endpoints

| Method | Endpoint           | Description        |
| ------ | ------------------ | ------------------ |
| GET    | /api/redarbor      | Get all employees  |
| GET    | /api/redarbor/{id} | Get employee by id |
| POST   | /api/redarbor      | Create employee    |
| PUT    | /api/redarbor/{id} | Update employee    |
| DELETE | /api/redarbor/{id} | Delete employee    |

## Database (Docker)

SQL Server runs in Docker.

Default credentials (for testing purposes only):
```
User: sa
Password: M1Pass123!
```
Connection string inside Docker:
```
Server=sqlserver,1433;Database=RedarborDb;User Id=sa;Password=M1Pass123!;TrustServerCertificate=True;
```
The password is fixed only to simplify local execution. In a real production environment, secrets should be managed securely.
