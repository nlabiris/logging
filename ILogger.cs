namespace Logging {
    public interface ILogger {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Notices the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Notice(string message);

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(string message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Critical(string message);

        /// <summary>
        /// Alerts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Alert(string message);

        /// <summary>
        /// Emergencies the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Emergency(string message);
    }
}
