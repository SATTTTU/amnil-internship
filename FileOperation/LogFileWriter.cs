using System;
using System.IO;

namespace FileOperation
{
    public class LogFileWriter
    {
        private readonly string _logFilePath;

        public LogFileWriter(string logFilePath = "application.log")
        {
            _logFilePath = logFilePath;
        }

        public void Log(string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch
            {
                Console.WriteLine("Failed to write to log.");
            }
        }
    }
}