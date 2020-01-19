using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Logging {
    public class FileLogger : Logger, IDisposable {
        /// <summary>
        /// The file path
        /// </summary>
        protected static readonly string FilePath = Properties.Settings.Default.filePath;

        /// <summary>
        /// The streams
        /// </summary>
        protected readonly Dictionary<string, StreamWriter> streams = new Dictionary<string, StreamWriter>();

        /// <summary>
        /// The filename
        /// </summary>
        protected readonly string filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public FileLogger(string filename) {
            if (string.IsNullOrEmpty(filename)) {
                throw new ArgumentException("Filename not provided");
            }
            this.filename = filename;
            this.streams = new Dictionary<string, StreamWriter>();
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Debug(string message) {
            this.LogToFile(LogLevel.Debug, message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Info(string message) {
            this.LogToFile(LogLevel.Info, message);
        }

        /// <summary>
        /// Notices the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Notice(string message) {
            this.LogToFile(LogLevel.Notice, message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Warning(string message) {
            this.LogToFile(LogLevel.Warning, message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Error(string message) {
            this.LogToFile(LogLevel.Error, message);
        }

        /// <summary>
        /// Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Critical(string message) {
            this.LogToFile(LogLevel.Critical, message);
        }

        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Alert(string message) {
            this.LogToFile(LogLevel.Alert, message);
        }

        /// <summary>
        /// Emergencies the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Emergency(string message) {
            this.LogToFile(LogLevel.Emergency, message);
        }

        /// <summary>
        /// Closes the streams.
        /// </summary>
        public void CloseStreams() {
            foreach (KeyValuePair<string, StreamWriter> cacheStreams in this.streams) {
                cacheStreams.Value.Close();
            }

            this.streams.Clear();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            this.CloseStreams();
        }

        /// <summary>
        /// Logs to file.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        private void LogToFile(LogLevel logLevel, string message) {
            string fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{this.filename}.log");

            this.CheckFileOperations(fullPath);

            if (!this.streams.ContainsKey(this.filename)) {
                this.streams.Add(this.filename, new StreamWriter(fullPath, true));
                this.streams[this.filename].AutoFlush = true;
            }

            this.streams[this.filename].WriteLine($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message}");
        }

        /// <summary>
        /// Checks the file operations.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        private void CheckFileOperations(string fullPath) {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!string.IsNullOrEmpty(FilePath)) {
                fullPath = Path.Combine(FilePath, $"{this.filename}.log");

                if (!Directory.Exists(FilePath)) {
                    Directory.CreateDirectory(FilePath);
                }
            } else {
                if (!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }
            }

            //if (!File.Exists(fullPath)) {
            //    File.Create(fullPath);
            //}
        }
    }
}
