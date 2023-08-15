using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace GotifyClient
{
	internal class LogViewModel : ObservableObject
	{
		ObservableCollection<LogMessageViewModel> logMessages;

		internal LogViewModel()
		{
			LogMessages = new ObservableCollection<LogMessageViewModel>();

			Log.LogMessage += Log_LogMessage;
		}

		public ObservableCollection<LogMessageViewModel> LogMessages { get => logMessages; set => SetProperty(ref logMessages, value); }

		internal void Log_LogMessage(LogMessage logMessage)
		{
			Application.Current?.Dispatcher.Invoke(() => LogMessages.Add(new LogMessageViewModel(logMessage)));
		}
	}
}
