using GotifyClient.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotifyClient
{
	internal class MessageViewModel : ObservableObject
	{
		private int appId;
		private DateTime date;
		private int id;
		private string message;
		private int priority;
		private string title;
		private Message message1;

		public MessageViewModel(Message messageModel)
		{
			AppId = messageModel.Appid ?? 0;
			Date = messageModel.Date ?? DateTime.MinValue;
			Id = messageModel.Id ?? 0;
			Message = messageModel.MessageContent;
			Priority = (int?)messageModel.Priority ?? 0;
			Title = messageModel.Title;
		}

		public int AppId { get => appId; set => SetProperty(ref appId, value); }
		public DateTime Date { get => date; set => SetProperty(ref date, value); }
		public int Id { get => id; set => SetProperty(ref id, value); }
		public string Message { get => message; set => SetProperty(ref message, value); }
		public int Priority { get => priority; set => SetProperty(ref priority, value); }
		public string Title { get => title; set => SetProperty(ref title, value); }

	}
}
