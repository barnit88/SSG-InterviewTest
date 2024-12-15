# SSG-Interview API

## Description

This project implements a **Job Candidate Hub API** that allows storing and updating job candidate information. The application provides a REST API endpoint that can create or update candidate profiles in a SQL database. The API uses **MediatR** for command handling, **FluentValidation** for input validation, and **Entity Framework Core** for data access. Additionally, **Serilog** is used for logging.

## Architecture

The solution is structured using **Clean Architecture** to promote separation of concerns, scalability, and maintainability. Below is the folder structure:


- **src/app/SSG.API**: Contains the controllers for the API.
- **src/common/SSG.Application**: Contains the business logic, including commands, handlers, and validation.
- **src/common/SSG.Domain**: Contains the domain entities like `Candidate`.
- **src/common/SSG.Infrastructure**: Contains implementation of database context and other infrastructure concerns.
- **tests/SSG.Application.Functional.Test**: Contains the unit tests for the application.

## Functional Requirements

The application provides the following API endpoint:

- **POST /create-or-update**: Creates or updates a candidate's profile.

### Input Fields

- First Name (Required)
- Last Name (Required)
- Phone Number
- Email (Required, used as unique identifier)
- Call Time Interval
- LinkedIn Profile URL
- GitHub Profile URL
- Comment (Required)

### Output

- Returns a success message when the candidate is created or updated.
- Handles error responses for invalid input or processing issues.

## Technical Requirements & Recommendations

- **.NET Stack**: The application is built with **.NET 8+** and uses **Entity Framework Core** for data access.
- **Self-Deployable**: The application is designed to run out of the box. Just open the solution in Visual Studio and run the app.
- **Logging**: The application uses **Serilog** for logging, ensuring proper logging of system events and errors.
- **Swagger**: **Swagger** is used for API documentation, allowing easy testing of the API endpoints.

### Packages Used

- **MediatR**: For handling commands and queries in a clean and decoupled way.
- **FluentValidation**: For validating input data in commands.
- **EF Core**: For database interactions and ORM functionality.
- **Swagger**: For API documentation and testing.
- **Serilog**: For structured logging.

## Setup Instructions

1. Clone the repository to your local machine.
2. Open the solution in **Visual Studio**.
3. Run the solution using Visual Studio.

## Testing

Unit tests are written for core functionality, and functional tests are included for command execution.