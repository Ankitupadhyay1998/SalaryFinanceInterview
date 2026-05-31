# SalaryFinanceInterview – Contract-Driven API, SDK & MVC Consumer Demo

## Overview

This repository demonstrates a complete enterprise-style **contract-driven architecture** using modern .NET technologies including:

* ASP.NET Core Web API (.NET 9)
* OpenAPI / Swagger
* NSwag SDK Generation
* Dependency Injection (DI)
* Typed HttpClient Consumption
* MVC Consumer Application
* ProblemDetails Standardized Error Handling
* System.Text.Json Source Generation

The solution showcases how APIs can expose strongly-typed reusable SDKs that are consumed by external applications such as MVC apps, console applications, or frontend systems.

---

# Solution Architecture

```text
ASP.NET Core API
        ↓
Swagger / OpenAPI Contract
        ↓
NSwag Code Generation
        ↓
Generated C# SDK (ApiClient)
        ↓
Consumers
 ┌───────────────┬────────────────┐
 │ MVC Web App   │ Console App    │
 └───────────────┴────────────────┘
```

---

# Projects Structure

## 1. SalaryFinanceInterview.Api

ASP.NET Core Web API project exposing RESTful endpoints and OpenAPI documentation.

### Features

* ASP.NET Core Web API (.NET 9)
* CRUD Operations
* Controllers + Minimal APIs
* Swagger/OpenAPI Documentation
* XML Documentation Integration
* ProblemDetails Standardized Error Responses
* In-Memory Data Storage
* System.Text.Json Source Generation
* Validation Attributes
* CancellationToken Support

### Controllers

* Employees
* LoanApplications
* SalaryAdvances
* Demo
* WeatherForecast

---

## 2. SalaryFinanceInterview.ApiClient

Auto-generated strongly typed SDK generated using NSwag from the OpenAPI contract.

### Features

* Generated C# API Client
* Strongly Typed DTOs
* HttpClientFactory Support
* Dependency Injection Integration
* Async API Methods
* Typed Exception Handling
* System.Text.Json Serialization
* Auto-generated Interfaces & Models

### Important Concepts

* Generated SDK acts as an abstraction layer over raw HTTP calls
* OpenAPI becomes the source of truth
* SDK regeneration automatically syncs API contracts

---

## 3. SalaryFinanceInterview.ConsoleDemo

Console application demonstrating SDK consumption using Dependency Injection and HostBuilder.

### Features

* SDK Consumption
* CRUD Operations
* Minimal API Consumption
* Typed Responses
* Exception Handling
* DI using Microsoft.Extensions.Hosting

### Demonstrates

* Real-world SDK usage
* Enterprise integration patterns
* Clean separation between API and consumer applications

---

## 4. SalaryFinanceInterview.WebDemo

ASP.NET Core MVC application consuming the generated SDK through Dependency Injection.

### Features

* MVC Architecture
* SDK Consumption using DI
* CRUD Screens
* Form Submission
* API Error Handling
* ProblemDetails Display
* Bootstrap UI
* Typed Models from SDK

### Demonstrates

* Server-side SDK integration
* MVC + API communication
* Validation error handling
* Enterprise frontend-backend integration

---

# OpenAPI & SDK Generation Flow

## Step 1 — API Generates OpenAPI Contract

Swagger/OpenAPI JSON exposed automatically:

```text
https://localhost:<port>/swagger/v1/swagger.json
```

---

## Step 2 — NSwag Reads OpenAPI Specification

NSwag uses the OpenAPI document to generate:

* DTO models
* Interfaces
* Typed API clients
* Exception classes
* Serialization logic

---

## Step 3 — SDK Generated

Generated code output:

```text
SalaryFinanceInterview.ApiClient/Generated/
```

---

# Key Enterprise Concepts Demonstrated

## Contract-Driven Development

OpenAPI acts as the central contract between producer and consumer applications.

---

## Strongly Typed SDK Generation

Consumers never manually write HTTP request code.

Instead they consume:

```csharp
await apiClient.EmployeesGETAsync(1);
```

instead of manually building requests using HttpClient.

---

## Dependency Injection (DI)

SDK integrates directly with:

```csharp
builder.Services.AddHttpClient();
```

and is resolved automatically through ASP.NET Core DI container.

---

## HttpClientFactory

Avoids:

* socket exhaustion
* improper HttpClient lifecycle management

Provides:

* resiliency
* centralized configuration
* logging integration

---

## ProblemDetails Standardized Error Handling

API returns RFC-standardized validation errors:

```json
{
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Status": [
      "The Status field is required."
    ]
  }
}
```

MVC application consumes and displays these errors gracefully.

---

## System.Text.Json Source Generation

Improves:

* performance
* startup time
* serialization efficiency
* AOT readiness

by generating serialization metadata during compile time.

---

## CancellationToken Support

Allows request cancellation when:

* browser disconnects
* client aborts requests
* network interruptions occur

Improves scalability and resource efficiency.

---

# Technologies Used

* .NET 9
* ASP.NET Core
* Swagger / OpenAPI
* Swashbuckle
* NSwag
* System.Text.Json
* ASP.NET Core MVC
* Dependency Injection
* HttpClientFactory
* Bootstrap

---

# Running the Solution

## 1. Run API

```bash
dotnet run --project SalaryFinanceInterview.Api
```

---

## 2. Generate SDK

```bash
nswag run
```

---

## 3. Run MVC Application

```bash
dotnet run --project SalaryFinanceInterview.WebDemo
```

---

## 4. Run Console Application

```bash
dotnet run --project SalaryFinanceInterview.ConsoleDemo
```

---

# Important Notes

* Generated SDK files should not be manually modified
* API project is the source of truth
* Any API contract change requires SDK regeneration
* Swagger/OpenAPI accuracy is critical for client compatibility
* XML documentation enriches Swagger metadata and generated SDK comments

---

# What This Project Demonstrates

This solution demonstrates real-world enterprise backend architecture patterns including:

* API-first development
* Contract-driven SDK generation
* Typed API consumption
* Enterprise error handling
* Dependency Injection
* HttpClientFactory integration
* MVC + API integration
* Modern .NET development practices

---

## Author

Developed by Ankit Kumar Upadhyay

This project was created as part of a Senior Full Stack .NET Developer technical assignment demonstrating modern API-first and contract-driven architecture using ASP.NET Core, OpenAPI, NSwag, and MVC integration.

## License

This project is intended for educational and demonstration purposes.
