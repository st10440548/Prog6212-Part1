CMS Part 3 - Automation Implementation
This package contains an enhanced ASP.NET Core MVC project with:
- Client-side auto-calculation (jQuery) for claim total.
- Server-side validation (DataAnnotations + FluentValidation scaffold).
- Automated policy checks configurable via appsettings.json.
- Approval workflow (Coordinator approve/reject; Manager override example).
- HR report generation (CSV of approved claims).
- API endpoints for claims status.
- Seed data for sample users and lecturers.
- Unit tests (xUnit) for business logic and automation checks.
To run: open CMS.sln in Visual Studio or run `dotnet restore` then `dotnet build`.
Update connection string in CMS/appsettings.json and run the provided SQL script or EF migrations.
