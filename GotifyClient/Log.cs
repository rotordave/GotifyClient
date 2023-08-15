using GotifyClient.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotifyClient
{
	internal static class Log
	{

		internal static event Action<LogMessage> LogMessage;

		internal static void Info(string message)
		{
			LogMessage?.Invoke(new GotifyClient.LogMessage(DateTime.Now, LogLevel.Information, message));
		}

		internal static void Warn(string message)
		{
			LogMessage?.Invoke(new GotifyClient.LogMessage(DateTime.Now, LogLevel.Warning, message));
		}

		internal static void Error(string message)
		{
			LogMessage?.Invoke(new GotifyClient.LogMessage(DateTime.Now, LogLevel.Error, message));
		}

	}

	internal class LogMessage
	{
		public DateTime Date { get; private set; }
		public string Message { get; private set; }
		public LogLevel LogLevel { get; private set; }

		public LogMessage(DateTime date, LogLevel logLevel, string message)
		{
			Date = date;
			Message = message;
			LogLevel = logLevel;
		}

	}
	internal enum LogLevel
	{
		Error = 1,
		Warning= 2,
		Information = 3
	}
}
