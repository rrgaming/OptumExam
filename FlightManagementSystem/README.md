# Flight Management System

## Overview

The **Flight Management System** is a .NET 9 API application designed to manage flights and passengers. It supports:
- Creating and listing flights
- Adding passengers to flights with seat and baggage validation
- Enforcing business rules for different flight classes (First, Business, Economy)
- Returning structured error responses for validation and business rule violations

## Features

- **Flight Management:** Add, retrieve, and list flights.
- **Passenger Management:** Add passengers to flights, ensuring no duplicates and enforcing seat/baggage rules.
- **Class Rules:** Each flight class has its own seat range, baggage allowance, and weight limits.
- **Error Handling:** Returns structured JSON errors (e.g., for duplicate flights, baggage exceeded, no seats available).

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later (recommended)
- (Optional) [Postman](https://www.postman.com/) or similar tool for API testing

## Getting Started

### 1. Clone the Repository

### 2. Restore Dependencies

### 3. Build the Solution

### 4. Run the API

Navigate to the API project directory (usually `FlightManagementSystem.API`) and run:

By default, the API will start on `https://localhost:5001` or `http://localhost:5000` But modify launchSettings.json

### 5. Test the API

- Use Swagger UI (if enabled) at `https://localhost:5001/swagger` to explore and test endpoints.
- Or use Postman/cURL to send requests to the API.

## Project Structure

- **FlightManagementSystem.Domain**: Domain entities, enums, and business rules.
- **FlightManagementSystem.Application**: Application logic, DTOs, and services.
- **FlightManagementSystem.Infrastructure**: Data access interfaces and implementations.
- **FlightManagementSystem.API**: API controllers, middleware, and startup configuration.


