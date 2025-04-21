
# Ambev Developer Evaluation Project

This repository contains the Ambev Developer Evaluation project. The solution is designed with a multi-layered architecture and leverages multiple services such as PostgreSQL, MongoDB, and Redis. This guide will walk you through setting up the environment using Docker to test and run the application locally.

---

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- An IDE or editor of your choice (e.g., Visual Studio, VS Code)

---

## Services Overview

The application uses the following services:

- **Web API**: Main entry point for the application.
- **PostgreSQL**: Relational database for data storage.
- **MongoDB**: NoSQL database for handling notifications.
- **Redis**: Caching system for improved performance.

---

## Setting Up the Environment

### 1. Clone the Repository
```bash
git clone https://github.com/your-repo-name.git
cd your-repo-name
```

### 2. Build and Run the Environment with Docker Compose

Use the `docker-compose.yml` file included in the repository to spin up the required services.

```bash
docker-compose up --build
```

This command will:
- Build the `ambev.developerevaluation.webapi` image.
- Start all services defined in `docker-compose.yml`:
  - **Web API**: Available on ports `8080` (HTTP) and `8081` (HTTPS).
  - **PostgreSQL**: Available on port `5432`.
  - **MongoDB**: Available on port `27017`.
  - **Redis**: Available on port `6379`.

## Troubleshooting

### Common Issues
1. **Port Conflicts**: If any service fails to start due to port conflicts, check if the ports (`8080`, `8081`, `5432`, `27017`, `6379`) are already in use.
   - Update the `docker-compose.yml` file with alternative ports and rebuild the containers.

2. **Permission Issues**: Ensure Docker has the necessary permissions to access the paths defined in the `volumes` section.

3. **Connection Issues**:
   - Verify that all containers are running using `docker ps`.
   - Check the logs of specific containers using:
     ```bash
     docker logs <container_name>
     ```

---

## Running Tests

The project includes a comprehensive suite of tests. To execute the tests, use the following command:

```bash
dotnet test
```

Ensure all services are running, as some tests might rely on the database or cache.

---

## Stopping and Cleaning Up

To stop all containers:

```bash
docker-compose down
```

To clean up unused containers, images, volumes, and networks:

```bash
docker system prune -a
```

---

## Contribution Guide

1. Fork the repository.
2. Create a feature branch.
3. Submit a pull request with a clear description of your changes.

---

## Contact

For any questions or issues, please reach out to the repository maintainer.

---

Happy Coding! 🚀
