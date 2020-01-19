using System;
using System.Collections.Generic;
using System.IO;

namespace Logging {
    public abstract class Logger : ILogger {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Debug(string message);

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Info(string message);

        /// <summary>
        /// Notices the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Notice(string message);

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Warning(string message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Error(string message);

        /// <summary>
        /// Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Critical(string message);

        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Alert(string message);

        /// <summary>
        /// Emergencies the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Emergency(string message);

        /// <summary>
        /// Logs the color of the level to console.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Invalid log level provided</exception>
        protected ConsoleColor LogLevelToConsoleColor(LogLevel logLevel) {
            switch (logLevel) {
                case LogLevel.Debug:
                    return ConsoleColor.White;
                case LogLevel.Info:
                    return ConsoleColor.Cyan;
                case LogLevel.Notice:
                    return ConsoleColor.Green;
                case LogLevel.Warning:
                    return ConsoleColor.Yellow;
                case LogLevel.Error:
                    return ConsoleColor.DarkMagenta;
                case LogLevel.Critical:
                    return ConsoleColor.Magenta;
                case LogLevel.Alert:
                    return ConsoleColor.DarkRed;
                case LogLevel.Emergency:
                    return ConsoleColor.Red;
                default:
                    throw new Exception("Invalid log level provided");
            }
        }
    }
}
