using GotifyClient.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotifyClient
{
	internal class LogMessageViewModel : ObservableObject
	{
		private DateTime date;
		private string message;
		private LogLevel logLevel;

		public LogMessageViewModel(LogMessage message)
		{
			Date = message.Date;
			Message = message.Message;
			LogLevel = message.LogLevel;
		}

		public LogMessageViewModel(DateTime date, LogLevel logLevel, string message)
		{
			Date = date;

			if (message.EndsWith(Environment.NewLine))
			{
				message.Substring(0, message.Length - Environment.NewLine.Length);
			}

			Message = message;
			LogLevel = logLevel;
		}

		public DateTime Date { get => date; set => SetProperty(ref date, value); }
		public string Message { get => message; set => SetProperty(ref message, value); }
		public LogLevel LogLevel { get => logLevel; set => SetProperty(ref logLevel, value); }

	}

}
