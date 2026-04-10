using System;
using System.Threading;
using System.Threading.Tasks;
using Cronos;

namespace CronJobConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            Console.WriteLine("CronJobConsoleApp starting... (Ctrl+C to stop)");
            Console.WriteLine("Job will trigger every minute: * * * * *");

            var cronExpr = CronExpression.Parse("* * * * *", CronFormat.Standard);
            var now = DateTime.UtcNow;
            var nextExecution = cronExpr.GetNextOccurrence(now, TimeZoneInfo.Utc) ?? now.AddYears(1);

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    if (DateTime.UtcNow >= nextExecution)
                    {
                        await DoJobAsync();
                        nextExecution = cronExpr.GetNextOccurrence(DateTime.UtcNow, TimeZoneInfo.Utc) ?? DateTime.UtcNow.AddYears(1);
                    }

                    await Task.Delay(1000, cts.Token); // Check every second
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nShutting down...");
            }
        }

        static async Task DoJobAsync()
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Cron job executed! (Replace this with your task)");
            // Add your job logic here, e.g., API call, DB update, file write
            await Task.Delay(100); // Simulate work
        }
    }
}
