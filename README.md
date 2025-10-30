# Tercüman Takip (TercumanTakip)

A web-based management system for tracking translators, assignments, and related workflows — built with **ASP.NET Core MVC** and **Entity Framework Core**.

[![.NET](https://img.shields.io/badge/.NET-6.0+-blue.svg)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

> **Note:** The `appsettings.json` file currently contains a sample/local connection string.  
> Move all real credentials or environment-specific secrets out of source control. See the [Configuration & Security](#configuration--security) section below.

---

## Tech Stack
- **Backend:** ASP.NET Core MVC (C#)
- **Database:** Entity Framework Core + SQL Server
- **Frontend:** Razor Views, Bootstrap, SCSS

## Table of Contents
- [Overview](#overview)
- [Repository Structure](#repository-structure)
- [Prerequisites](#prerequisites)
- [Quick Start](#quick-start)
- [Database & Migrations](#database--migrations)
- [Configuration & Security](#configuration--security)
- [Development Notes](#development-notes)
- [Contributing](#contributing)
- [Troubleshooting](#troubleshooting)
- [License & Contact](#license--contact)

---

## Overview

**Tercüman Takip** is an ASP.NET Core web application designed to help organizations manage translators (*tercüman*), track their assignments, and monitor project workflows efficiently.  
It follows the MVC architecture pattern with clear separation between Controllers, Models, Services, and Views.

This project was developed during an internship at **SGDD-ASAM**.

---

## Repository Structure

**Top-level files and directories:**
```
├── .gitattributes
├── .gitignore
├── TercumanTakipWeb.sln
├── TercumanTakipWeb.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── Controllers/
├── Models/
├── Services/
├── Views/
├── Migrations/
├── Properties/
├── wwwroot/
└── bin/, obj/ (build output — ignored)
```

---

## Prerequisites

- **.NET SDK 6.0+** (or the version referenced in the project file)
- **Database:** SQL Server / LocalDB / SQLite (depending on configuration)
- **Optional:** Visual Studio or VS Code for development

---

## Quick Start (Development)

1. **Clone the repository**
   ```bash
   git clone https://github.com/berkay-aktas/tercumantakip.git
   cd tercumantakip
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Configure your environment**
   - Remove or replace credentials in `appsettings.json`.
   - Create a `appsettings.example.json` (without secrets) and add `appsettings.json` to `.gitignore`.
   - Ensure `ConnectionStrings → TercumanTakipConnection` points to a valid database.

4. **Apply database migrations (Entity Framework Core)**
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef database update --project ./TercumanTakipWeb.csproj
   ```

5. **Run the app**
   ```bash
   dotnet run --project ./TercumanTakipWeb.csproj
   ```
   Or open the solution in Visual Studio and run from there.

---

## Database & Migrations

Entity Framework Core handles database migrations. Use the following commands to manage them:

```bash
# Add a new migration
dotnet ef migrations add <MigrationName> --project ./TercumanTakipWeb.csproj

# Update the database
dotnet ef database update --project ./TercumanTakipWeb.csproj
```

Migrations are located in the `/Migrations` directory.

---

## Configuration & Security

- `appsettings.json` contains local sample values. Treat connection strings, API keys, and credentials as sensitive data.
- Recommended best practices:
  - Add an **`appsettings.example.json`** file to the repo as a template (no secrets).
  - Add `appsettings.json` and `appsettings.Development.json` to `.gitignore`.
  - Use **environment variables** or **User Secrets Manager** for local secret management.

**Common sensitive file types to exclude:**
```
*.pfx
*.pem
*.key
*.env
*.secrets.json
*.user
*.suo
```

> See the `.gitignore` file for a complete list of excluded files and directories.

---

## Development Notes

- **Entry Point:** `Program.cs`
- **Architecture:** Follows standard MVC principles
  - `Controllers/` — request handling
  - `Models/` — data structures and EF entities
  - `Services/` — business logic and database operations
  - `Views/` — Razor pages for UI rendering
- Register new services in the DI container within `Program.cs`.

---

## Contributing

1. Fork the repository and create a new branch:
   ```bash
   git checkout -b feature/your-feature
   ```
2. Implement your feature or fix, including tests if applicable.
3. Commit, push, and open a pull request with a clear description.

Include migration steps if your changes affect the data model.

---

## Troubleshooting

| Issue | Possible Fix |
|-------|---------------|
| **DB connection errors** | Check your connection string and ensure the database server is running. |
| **EF migration mismatch** | Rebuild the project and confirm you’re targeting the correct project in EF commands. |
| **Port conflicts** | Update launch settings or specify a different port with `--urls`. |

---

## License & Contact

This project is licensed under the [MIT License](LICENSE).

**Author:** Berkay Aktaş  
Developed during internship at **SGDD-ASAM**  
GitHub: [@berkay-aktas](https://github.com/berkay-aktas)

---
