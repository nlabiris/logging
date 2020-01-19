using System;

namespace Logging {
    public class ConsoleLogger : Logger {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Debug(string message) {
            this.LogToConsole(LogLevel.Debug, message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Info(string message) {
            this.LogToConsole(LogLevel.Info, message);
        }

        /// <summary>
        /// Notices the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Notice(string message) {
            this.LogToConsole(LogLevel.Notice, message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Warning(string message) {
            this.LogToConsole(LogLevel.Warning, message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Error(string message) {
            this.LogToConsole(LogLevel.Error, message);
        }

        /// <summary>
        /// Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Critical(string message) {
            this.LogToConsole(LogLevel.Critical, message);
        }


        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Alert(string message) {
            this.LogToConsole(LogLevel.Alert, message);
        }

        /// <summary>
        /// Emergencies the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Emergency(string message) {
            this.LogToConsole(LogLevel.Emergency, message);
        }

        /// <summary>
        /// Logs to console.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        private void LogToConsole(LogLevel logLevel, string message) {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = this.LogLevelToConsoleColor(logLevel);
            Console.WriteLine($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message}");
            Console.ForegroundColor = oldColor;
        }
    }
}
