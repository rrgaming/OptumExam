# Flight Management System - API

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


# flight-ui (React App)

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

## Connecting to API

Check the file src > api > constants.tsx and update the apiBaseUrl if you have changes in your web api localhost url.
