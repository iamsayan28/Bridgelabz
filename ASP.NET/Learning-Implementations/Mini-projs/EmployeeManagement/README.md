# Employee Management System — ASP.NET Core MVC + ADO.NET

A simple learning-project implementation. Plain HTML only — **no CSS anywhere on purpose**.

## How to run

1. Install the [.NET 8 SDK](https://dotnet.microsoft.com/download) and MySQL Server (or MySQL Community Server / XAMPP's MySQL).
2. Run `Database/CreateDatabase.sql` in MySQL Workbench (or `mysql -u root -p < Database/CreateDatabase.sql`) to create the database, tables, and seed data (login: `admin` / `admin123`).
3. Update the connection string in `appsettings.json` with your MySQL username/password/port:
   ```
   Server=localhost;Port=3306;Database=EmployeeManagementDB;Uid=root;Pwd=YOUR_MYSQL_PASSWORD;
   ```
4. From the project folder, run:
   ```
   dotnet restore
   dotnet run
   ```
5. Open the URL shown in the console (e.g. `https://localhost:5001`). You'll land on the Login page.

No Visual Studio or Windows is required to run this — ASP.NET Core is cross-platform. IIS is optional (see note below).

## What changed vs. classic ASP.NET MVC, and why

Since this uses **ASP.NET Core MVC** instead of classic ASP.NET MVC 5, a few pieces from the original spec don't apply the same way:

| Original requirement | How it's handled here |
|---|---|
| CSS styling (colors, layout) | **Skipped intentionally** — plain semantic HTML only, per request |
| `Web.config` | Replaced by `appsettings.json` + `Program.cs` |
| `RouteConfig.cs` | Routes configured directly in `Program.cs` (`MapControllerRoute`) — default route + one custom route (`/emp/{id}/details`) |
| Bundling (`System.Web.Optimization`) | Doesn't exist in Core — dropped. Scripts are referenced individually/via CDN in `_Layout.cshtml`, which is fine at this scale |
| HTML Helpers (`Html.TextBoxFor`, etc.) | Replaced by the idiomatic Core equivalent: **Tag Helpers** (`asp-for`, `asp-controller`, `asp-action`, `asp-validation-for`) |
| Windows IIS (mandatory) | Optional here — the app self-hosts via Kestrel (`dotnet run`) on any OS. On Windows you can still front it with IIS as a reverse proxy if you want to practice that step |
| StyleCop (classic MSBuild tool) | Not configured in this simple version. Modern equivalent, if you want it, is the `StyleCop.Analyzers` NuGet package + `.editorconfig` |
| Entity Framework | Not used — ADO.NET only, exactly as required |
| SQL Server ADO.NET classes (`SqlConnection`, etc.) | Using **MySQL** instead: `MySqlConnector` package, with `MySqlConnection`/`MySqlCommand`/`MySqlDataReader`/`MySqlParameter` — same ADO.NET pattern, different provider |

## Where each remaining requirement lives

- **Login/Session/Logout**: `Controllers/AccountController.cs`, session set via `HttpContext.Session.SetString("Username", ...)`
- **Route protection**: `Filters/LoginRequiredAttribute.cs`, applied via `[LoginRequired]` on `EmployeeController`
- **Employee CRUD + validation**: `Models/Employee.cs` (Data Annotations), `Controllers/EmployeeController.cs`, `Views/Employee/*.cshtml`
- **ADO.NET data access**: `Data/EmployeeRepository.cs`, `Data/UserRepository.cs` — all parameterized `SqlCommand`/`SqlParameter`, no string-concatenated SQL
- **Layout**: `Views/Shared/_Layout.cshtml` — app name, nav, logged-in user, logout, footer
- **Partial View**: `Views/Shared/_EmployeeTable.cshtml`
- **ViewBag**: `PageTitle`, `TotalEmployees`, `LoggedInUser` set in `EmployeeController`
- **TempData**: one-time success messages after Create/Edit/Delete, shown in `_Layout.cshtml` and auto-faded by jQuery
- **jQuery**: delete confirmation + message fade-out in `wwwroot/js/site.js`
