using System;
using System.IO;
using System.Runtime.Serialization;

namespace S2Lobby
{
    public sealed class Logger: IDisposable
    {
        private StreamWriter _fileStream;
        private readonly object _sync = new object();
        private static readonly Lazy<Logger> lazy = new Lazy<Logger> (() => new Logger());

        public static Logger Instance { get { return lazy.Value; }}

        private Logger()
        {
            lock (_sync)
            {
                #if DEBUG
                _fileStream = File.CreateText(Constants.LoggerFileDefaultDebug);
                #else
                _fileStream = File.CreateText(Constants.LoggerFileDefault);
                #endif
            }

            this._Log($"[Log system started]");
        }

        void IDisposable.Dispose()
        {
            this._Log($"[Log system stopped]");
            lock (_sync)
            {
                _fileStream.Close();
                _fileStream = null;
            }
            GC.SuppressFinalize(this);
        }

        private void _LogDebug(string text)
        {
            #if DEBUG
                Log(text);
            #endif
        }

        private void _Log(string text)
        {
            lock (_sync)
            {
                _fileStream?.WriteLine(text);
                Console.WriteLine(DateTime.Now.ToString(Constants.LoggerTimeFormat) + " | " + text);
            }
        }

        public static void Log(string text) => Logger.Instance._Log(text);
        public static void LogDebug(string text) => Logger.Instance._LogDebug(text);
    }
}
