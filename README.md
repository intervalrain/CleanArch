[繁體中文](README_zh.md) | English

# CleanArch - Clean Architecture Study Project

A .NET 9 Clean Architecture implementation for authentication services, following the principles from [Amantinband's Clean Architecture template](https://github.com/amantinband/clean-architecture).

## 🏛️ Architecture Overview

This project demonstrates Clean Architecture principles with a focus on:
- **Separation of Concerns**: Each layer has distinct responsibilities
- **Dependency Inversion**: Dependencies point inward toward the domain
- **CQRS Pattern**: Command Query Responsibility Segregation with MediatR
- **Domain-Driven Design**: Rich domain models and error handling

## 📁 Project Structure

```
CleanArch/
├── CleanArch.Api/              # Presentation Layer
│   ├── Controllers/            # API Controllers
│   ├── Common/                 # HTTP utilities and error handling
│   └── Mappings/               # Request/Response mappings
├── CleanArch.Application/      # Application Layer
│   ├── Authentication/         # Auth commands, queries, handlers
│   └── Common/                 # Interfaces and abstractions
├── CleanArch.Contracts/        # API Contracts
│   └── Authentication/         # Request/Response DTOs
├── CleanArch.Domain/           # Domain Layer
│   ├── Entities/               # Domain entities
│   ├── Common/Errors/          # Domain errors
│   └── Persistence/            # Repository interfaces
├── CleanArch.Infrastructure/   # Infrastructure Layer
│   ├── Authentication/         # JWT implementation
│   ├── Persistence/            # Data access implementation
│   └── Time/                   # External service implementations
└── Docs/                       # Documentation
```

## 🚀 Features

### Authentication System
- **User Registration**: Create new user accounts with validation
- **User Login**: JWT-based authentication
- **Token Generation**: Secure JWT tokens with configurable settings
- **Error Handling**: Comprehensive domain-based error management

### Architecture Patterns
- **CQRS**: Separate commands and queries using MediatR
- **Repository Pattern**: Clean data access abstractions
- **Dependency Injection**: Modular service registration
- **Mapping**: Object-to-object mapping with Mapster

## 🛠️ Technology Stack

- **.NET 9**: Latest .NET framework
- **ASP.NET Core**: Web API framework
- **MediatR**: CQRS and mediator pattern
- **Mapster**: High-performance object mapping
- **JWT**: JSON Web Token authentication
- **Swagger**: API documentation

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- IDE(Visual Studio Code)

## 🏃‍♂️ Getting Started

### 1. Clone the Repository
```bash
git clone <your-repository-url>
cd CleanArch
```

### 2. Build the Solution
```bash
dotnet build
```

### 3. Run the Application
```bash
cd CleanArch.Api
dotnet run
```

### 4. Access the API
- **Swagger UI**: `https://localhost:7077/swagger`
- **API Base URL**: `https://localhost:7077`

## 📝 API Documentation

### Authentication Endpoints

#### Register User
```http
POST /auth/register
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "SecurePassword123!"
}
```

#### Login User
```http
POST /auth/login
Content-Type: application/json

{
  "email": "john.doe@example.com",
  "password": "SecurePassword123!"
}
```

**Response Format:**
```json
{
  "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

For detailed API documentation, see [Docs/Api.md](./Docs/Api.md).

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 📖 Learning Resources

This project implements patterns and principles from:

- **Clean Architecture** by Robert C. Martin
- **Amantinband's Clean Architecture Template**: [GitHub Repository](https://github.com/amantinband/clean-architecture)
- **Domain-Driven Design** principles
- **CQRS and Event Sourcing** patterns

## 🤝 Contributing

This is a study project. Feel free to:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📄 License

This project is for educational purposes. Feel free to use it as a learning resource.

## 🙏 Acknowledgments

- **Amantinband** for the excellent Clean Architecture template and tutorials
- **Clean Architecture** community for best practices and patterns
- **.NET Community** for comprehensive documentation and support

---

**Note**: This is a study project for learning Clean Architecture principles. It's not intended for production use without additional security, performance, and reliability considerations.