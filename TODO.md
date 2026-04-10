# CronJobConsoleApp TODO - Cronos Migration

## Migration Steps (from NCrontab to Cronos)

- [x] 1. Update CronJobConsoleApp.csproj: Remove NCrontab, add Cronos PackageReference
- [x] 2. Update Program.cs: Replace using/import, CrontabSchedule → CronExpression, GetNextOccurrences → GetNextOccurrence (UTC)
- [x] 3. Update README.md: Replace NCrontab mentions with Cronos, code examples
- [x] 4. dotnet clean; dotnet restore; dotnet build (verify)
- [x] 5. dotnet run (test every minute job)
- [x] 6. Mark all complete

Original tasks:
- [x] Create project directory and base files (.csproj, Program.cs, README.md, .sln)
- [x] Add NCrontab NuGet package
- [x] Update Program.cs with cron logic (every minute job)
- [x] Update README.md with instructions
- [x] Test: dotnet build succeeded
