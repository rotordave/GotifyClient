using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace GotifyClient
{
	internal class MessageListViewModel : ObservableObject
	{
		ObservableCollection<MessageViewModel> messages;

		internal MessageListViewModel()
		{
			Messages = new ObservableCollection<MessageViewModel>();
		}

		public ObservableCollection<MessageViewModel> Messages { get => messages; set => SetProperty(ref messages, value); } 

		internal void AddMessage(MessageViewModel obj)
		{
			Application.Current.Dispatcher.Invoke(() => messages.Add(obj));
		}
	}
}
