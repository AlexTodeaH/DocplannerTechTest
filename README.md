# Docplanner Tech Test

## Table of Contents
- [Overview](#overview)
- [Project Structure](#project-structure)
- [Requirements](#requirements)
- [Architecture](#architecture)
- [Design Patterns Used](#design-patterns-used)
- [Running the API](#running-the-api)
- [Running the Tests](#running-the-tests)

## Overview

This project is a .NET backend test for Docplanner Tech. The goal is to provide an API for managing doctor slots, allowing patients to see available slots and book appointments.

## Project Structure

- `DocplannerTechTest.Api`: The main Web API project.
- `DocplannerTechTest.Application`: Contains the application logic and service interfaces.
- `DocplannerTechTest.Domain`: Contains the domain models and logic.
- `DocplannerTechTest.Infrastructure`: Contains infrastructure-related code such as data access implementations.
- `DocplannerTechTest.Api.Tests`: Contains unit tests for the API project.
- `DocplannerTechTest.Application.Tests`: Contains unit tests for the application logic.
- `DocplannerTechTest.Domain.Tests`: Contains unit tests for the domain logic.
- `DocplannerTechTest.Infrastructure.Tests`: Contains unit tests for the infrastructure logic.

## Requirements

- Visual Studio 2022 or later
- .NET 8.0 SDK

## Architecture

The project follows the Clean Architecture principles, ensuring separation of concerns and maintainability.

## Design Patterns Used

- **Mediator Pattern**:
    - Implemented using the MediatR library in the Application layer.
    - The Mediator pattern centralizes complex communications and control logic between objects by encapsulating them in a mediator object.
    
- **CQRS (Command Query Responsibility Segregation)**:
    - Separates read (query) and write (command) operations to simplify the business logic and improve performance.

- **Dependency Injection**:
    - Used throughout the application to manage dependencies and promote loose coupling.
    - Configured in the API layer using the built-in ASP.NET Core DI container.

- **Exception Handling Middleware**:
    - A custom middleware component that handles exceptions globally and returns consistent error responses.
 
## Running the API

1. Clone the Repository
2. Open the `DocplannerTechTest.sln` Solution in Visual Studio
3. Build the Solution
4. Set `DocplannerTechTest.Api` as the startup project. Press `F5` or click the `Start` button to run the application. The API Swagger should open in your default browser.

## Running the Tests

1. Open the Test Explorer in Visual Studio (`Test` > `Test Explorer`). Click `Run All` to run all tests.
2. Alternatively, you can run the tests from the command line:
   
    ```sh
    dotnet test
    ```
