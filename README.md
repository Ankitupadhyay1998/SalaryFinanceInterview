Here is a clean and professional README.md you can directly use for your assignment repository.

---

md
# Salary Finance Interview – API + SDK + Console Demo

## Overview

This project demonstrates a complete **contract-driven architecture** using ASP.NET Core, OpenAPI (Swagger), NSwag SDK generation, and a console application consuming the generated client.

It is designed to showcase enterprise-level backend design including:
- REST API development
- OpenAPI contract generation
- Automated C# SDK generation
- Dependency Injection (DI)
- Strongly typed client consumption
- Standardized error handling

---

## Architecture Flow

text
ASP.NET Core API
        ↓
Swagger / OpenAPI Specification
        ↓
NSwag Client Generator
        ↓
Generated C# SDK (ApiClient Project)
        ↓
Console Application (Consumer)


---

## Projects Structure

### 1. SalaryFinanceInterview.Api

* ASP.NET Core Web API (.NET 9)
* Controllers + Minimal APIs
* Swagger/OpenAPI enabled
* System.Text.Json source generation
* Standardized error handling using ProblemDetails
* XML documentation enabled for API metadata

---

### 2. SalaryFinanceInterview.ApiClient

* Auto-generated C# SDK using NSwag
* Strongly typed API client
* Dependency Injection compatible
* HttpClientFactory support
* Custom exception handling (ApiException)
* DTOs generated from OpenAPI schema
* System.Text.Json serialization support

---

### 3. SalaryFinanceInterview.ConsoleDemo

* Console application consuming the SDK
* Uses Dependency Injection (HostBuilder)
* Demonstrates all API operations:

  * CRUD operations
  * Minimal APIs
  * Typed responses
* Handles exceptions from API client

---

## Key Features

### API Layer

* RESTful endpoints (GET, POST, PUT, DELETE)
* Minimal APIs
* Swagger/OpenAPI documentation
* XML comments integration
* Standard error format using ProblemDetails
* CancellationToken support for request abort handling

---

### SDK Layer (NSwag Generated)

* Strongly typed API client interface
* Async-only methods
* HttpClient injection via DI
* Auto-generated DTOs from OpenAPI
* Typed exception handling for API failures
* System.Text.Json integration

---

### Console Application

* Uses Microsoft.Extensions.Hosting
* Dependency Injection setup
* Calls all API endpoints via SDK
* Handles API exceptions gracefully
* Demonstrates real-world SDK consumption pattern

---

## How SDK Generation Works

1. API runs and exposes Swagger JSON:

   
   https://localhost:<port>/swagger/v1/swagger.json
   

2. NSwag reads OpenAPI specification

3. Generates:

   * C# client
   * DTO models
   * Interfaces
   * Exception classes

4. Output is placed inside:

   
   SalaryFinanceInterview.ApiClient/Generated/
   

---

## How to Run

### Step 1: Run API

bash
dotnet run --project SalaryFinanceInterview.Api


---

### Step 2: Generate SDK (NSwag)

bash
nswag run


---

### Step 3: Run Console App

bash
dotnet run --project SalaryFinanceInterview.ConsoleDemo


---

## Design Decisions

### Why System.Text.Json?

* High performance
* Native .NET support
* Source generation support
* No dependency on Newtonsoft.Json

---

### Why NSwag?

* Automatic SDK generation
* Strong typing
* OpenAPI-first approach
* Supports DI and HttpClientFactory

---

### Why CancellationToken?

* Allows request cancellation when client disconnects
* Improves resource efficiency
* Prevents unnecessary background processing

---

## Important Concepts Demonstrated

* OpenAPI contract-first design
* Dependency Injection (DI)
* HttpClientFactory usage
* Strongly typed SDK generation
* API versioning readiness
* Clean separation of concerns
* Enterprise integration pattern

---

## Notes

* Generated SDK files should NOT be manually modified
* Only API project is source of truth
* SDK is regenerated from OpenAPI contract
* XML documentation enhances Swagger + SDK comments

---

## Author

Candidate implementation for Senior Full Stack .NET Developer assignment.
