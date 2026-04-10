# CronJob Console App

Console application that runs a scheduled job **every minute** using Cronos library (cron expression: `* * * * *`).

## Features
- Infinite loop checking schedule every second.
- Graceful shutdown on Ctrl+C.
- Sample job logs timestamp (customize `DoJobAsync()`).
- .NET 8 console app.

## Setup & Run
1. Open terminal in `c:/SorceCode/CronJobConsoleApp/`:
   ```
   cd c:/SorceCode/CronJobConsoleApp
   dotnet restore  # Ensures packages
   dotnet build    # Verify build
   dotnet run      # Start app
   ```
2. Observe logs every minute. Press Ctrl+C to stop.

## Customize
- **Cron expression**: Change `CronExpression.Parse("* * * * *", CronFormat.Standard)` (see [crontab.guru](https://crontab.guru/)).
- **Job logic**: Replace `DoJobAsync()` body (async-friendly).
- **TargetFramework**: Edit `.csproj`.
- **Run as service**: Use NSSM, Windows Service, or Docker.

## Test
App outputs like:
```
CronJobConsoleApp starting... (Ctrl+C to stop)
Job will trigger every minute: * * * * *
[2024-10-04 14:59:00] Cron job executed! (Replace this with your task)
```

Built with best practices: async, cancellation, UTC time.
