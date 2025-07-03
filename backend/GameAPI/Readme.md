# GameAPI

GameAPI is a .NET 8.0 web service designed for managing and interacting with game sessions and rounds via exposed
RESTful API endpoints.

## Project Structure

- **GameAPI.Api:** ASP.NET Core web API project (main entry point).
- **GameAPI.Core:** Core business logic and domain models.
- **GameAPI.Infrastructure:** Data access and external services implementation layer.
- **GameAPI.Core.UnitTests:** xUnit and NSubstitute-based unit tests for core logic.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- (Optional) An IDE, e.g. JetBrains Rider, Visual Studio, or VS Code

### Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone https://github.com/jovana-cerovac/RockPaperScissorsLizardSpock.git
   cd backend/GameAPI
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Build the solution:**

   ```bash
    dotnet build
    ```

4. **Apply configuration (optional):**

    - Default configuration can be found in `GameAPI.Api/appsettings.json`.

5. **Run the application:**

   ```bash
   dotnet run --project GameAPI.Api --urls=https://localhost:7134
   ```

   By default, the API will be accessible at: `https://localhost:7134` or `http://localhost:5078`

   The swagger UI for API documentation will be available at:`https://localhost:7134/swagger/index.html` or `http://localhost:5078/swagger/index.html`

6. **Run tests:**

   ```bash
   dotnet test
   ```
