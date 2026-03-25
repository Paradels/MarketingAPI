# Marketing API

Marketing API is a .NET 8 Web API designed to handle marketing-related operations, such as dossier generation, mailing campaigns, and data processing.

## Architecture

The solution follows clean architecture principles with three main layers:
- **MarketingAPI.Api**: The presentation layer, containing controllers (`DossierController`, `MailingController`) and endpoints.
- **MarketingAPI.Core**: The domain and application layer, containing business logic, interfaces (`IDataService`), and core services (`MaillingService`).
- **MarketingAPI.Infrastructure**: The infrastructure layer, responsible for external concerns like PDF generation (`QuestPdfGeneratorService`) and data access (e.g., Excel files with `ExcelDataService`).

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An IDE such as Visual Studio 2022, Rider, or VS Code.

## Setup & Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Paradels/MarketingAPI.git
   ```

2. **Navigate to the solution directory:**
   ```bash
   cd MarketingAPI
   ```

3. **Restore packages:**
   ```bash
   dotnet restore
   ```

4. **Configuration:**
   Update the `appsettings.json` in the `MarketingAPI.Api` project with the necessary configuration for mailing servers, template locations, or file path endpoints.

5. **Run the API:**
   ```bash
   dotnet run --project MarketingAPI.Api/MarketingAPI.Api.csproj
   ```

6. **Swagger / OpenAPI Documentation:**
   Once the project is running, navigate to the base URL (typically `https://localhost:5001/swagger` depending on your `launchSettings.json`) to view the interactive API documentation.

## Features

- **Dossier Generation**: Uses QuestPDF to generate automated PDF dossiers based on incoming data.
- **Excel Data Processing**: Reads and processes marketing data source files (Excel) using infrastructure implementations.
- **Mailing Campaigns**: Manages marketing email distribution.

## License

This project is open-source and available under the MIT License (or the applicable license defined by the author).
