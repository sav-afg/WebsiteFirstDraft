    # Fitness Saviour

    A full-stack fitness web application built with C#, Blazor, and SQL Server. It provides personalized diet and exercise recommendations, allows users to log calories and macros, and visualizes progress with charts.

    ### Quick facts
    - Framework: .NET 10 (Blazor)
    - UI: Blazor (Razor components), HTML, CSS
    - Backend: C#, Entity Framework Core
    - Database: SQL Server

    ## Features
    - Daily calorie accumulator with user targets and history (`FoodEntry`, `ExerciseEntry`).
    - Personalized diet recommendations via questionnaire and scoring algorithm.
    - Exercise guidance (cardio, resistance, flexibility) with safe, general recommendations.
    - Data visualization for macro and calorie breakdowns (charts in `wwwroot` + components).
    - Persistent storage using EF Core and SQL Server.

    ## How it works (summary)
    - Users complete a questionnaire covering goals, preferences, and constraints.
    - The recommendation pipeline:
      1. Filter diet options by hard constraints (allergies, preferences).
      2. Score remaining diets against user responses:
         - Weight for goals (e.g., weight loss, muscle gain).
         - Preferences (macros, meal frequency).
         - Practical constraints (budget, time).
      3. Rank diets by score and present top results with breakdown charts.
    - Calorie accumulator:
      - Each `FoodEntry` adds calories/macros to the day's total.
      - Each `ExerciseEntry` subtracts estimated calories burned.
      - Daily target stored on the user profile; progress visualized in UI.

    ## Data model 
    - `User`:
      - `Id`, `Email`, `Name`, `DailyCalorieTarget`, `Preferences`
    - `FoodEntry`:
      - `Id`, `UserId`, `FoodId`, `Calories`, `Protein`, `Carbs`, `Fat`, `LoggedAt`
    - `ExerciseEntry`:
      - `Id`, `UserId`, `ExerciseId`, `EstimatedCaloriesBurned`, `LoggedAt`
    - `Diet` / `DietOption`:
      - `Id`, `Name`, `Description`, `MacrosTarget`, `Tags`
    - `Question` / `Response`:
      - `QuestionId`, `Text`, `ResponseType`
      - `Response`: `UserId`, `QuestionId`, `Value`

    Files to look for:
    - `Data/ApplicationDbContext.cs`
    - `Models/*` (e.g., `Diet.cs`, `FoodEntry.cs`, `ExerciseEntry.cs`, `User.cs`)
    - `Services/*` (recommendation engine, logging, data services)
    - Blazor pages: `Pages/Questionnaire.razor`, `Pages/Dashboard.razor`, `Pages/Recommendations.razor`
    - Reusable components: `Components/Chart.razor`, `Components/EntryForm.razor`

    ## Running locally

    Prerequisites:
    - .NET 10 SDK
    - SQL Server (local or remote)
    - Optional: `dotnet-ef` tools (for migrations)

    Setup:
    1. Copy `appsettings.example.json` to `appsettings.Development.json` and set the connection string for SQL Server:
       - e.g. `"ConnectionStrings:DefaultConnection": "Server=.;Database=FitnessSaviourDb;Trusted_Connection=True;TrustServerCertificate=True;"`
    2. Apply EF Core migrations:
       - `dotnet tool install --global dotnet-ef` (if not installed)
       - `dotnet ef database update --context ApplicationDbContext`
       - Or run migrations on startup if configured.
    3. Run the app:
       - `dotnet run --project src/FitnessSaviour` (adjust path to project)
       - Or press F5 / run from Visual Studio.

    Database migration quick commands:
    - Add migration: `dotnet ef migrations add InitialCreate --project src/FitnessSaviour --startup-project src/FitnessSaviour`
    - Update database: `dotnet ef database update --project src/FitnessSaviour --startup-project src/FitnessSaviour`

    Running tests:
    - `dotnet test`

    ## Development notes
    - Blazor layout:
      - UI pages live under `Pages/`
      - Shared layout and components under `Shared/` and `Components/`
      - Static assets in `wwwroot/`
    - Dependency Injection:
      - Register services (recommendation engine, repositories) in `Program.cs`.

    ## Privacy & Safety
    - Do not provide prescriptive medical or clinical advice.
    - Provide general, safe exercise suggestions and prompts to consult healthcare professionals when necessary.


    ## Contact / More info
    - Project developed as coursework for A-level Computer Science.
    - For architecture diagrams and development screenshots, refer to the "Application Development Screenshots" document bundled with the repo.
