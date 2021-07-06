/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppServer.Services
{
    public class AppLogger : ILogger
    {
        private DateTime _currentDateForLog;
        private string _fileName;
        private string _directoryPath;
        private int _fileCount = 0;
        private static object _locker = new object();
        private LogLevel _level;

        public AppLogger(IConfiguration config)
        {

        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _level == logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            lock (_locker)
            {

                CheckLogDirectory();

                var fileName = GetFileName();
                if (string.IsNullOrEmpty(fileName))
                    return;
                var textRow = $"[{DateTime.Now}]  {exception.Message}";
                File.AppendAllLines(
                    fileName,
                    new[] { textRow });
            }
        }
        private string GetFileName()
        {
            if (string.IsNullOrEmpty(_directoryPath))
                return string.Empty;
            var now = DateTime.Now;
            if ((now - _currentDateForLog).Days == 1 || string.IsNullOrEmpty(_fileName))
            {
                _currentDateForLog = now.Date;
                _fileName = $"{_currentDateForLog.Year}-{_currentDateForLog.Month}-{_currentDateForLog.Day}";
                _fileCount = 0;
            }
            for (var i = _fileCount; i < int.MaxValue; i++)
            {
                var fileName = Path.Combine(_directoryPath, _fileName + (_fileCount == 0 ? "" : "_" + _fileCount.ToString()) + ".log");
                if (File.Exists(fileName))
                {
                    var length = new FileInfo(fileName).Length;
                    if (length > 20971520)
                    {
                        _fileCount++;
                        continue;
                    }
                }
                return fileName;
            }
            return string.Empty;
        }
        private void CheckLogDirectory()
        {
            if (string.IsNullOrEmpty(_directoryPath))
                return;
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
        }

    }
}
