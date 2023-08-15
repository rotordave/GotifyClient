using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using static GotifyClient.MessageController;

namespace GotifyClient
{
	internal class ClientViewModel : ObservableObject
	{
		private SettingsViewModel settingsViewModel;
		private MessageListViewModel messageListViewModel;
		private LogViewModel logViewModel;

		private MessageController messageController;

		private StreamState streamState = StreamState.Disconnected;


		public ClientViewModel()
		{
			logViewModel = new LogViewModel();

			settingsViewModel = new SettingsViewModel(GotifyClientApplication.SettingsManager);

			settingsViewModel.Load();

			messageListViewModel = new MessageListViewModel();

			messageController = new MessageController(settingsViewModel);

			messageController.MessageReceived += MessageController_MessageReceived;

			messageController.StreamStateChanged += MessageController_StreamStateChanged;

			messageController.OpenStream();

		}

		private void MessageController_StreamStateChanged(StreamState obj)
		{
			StreamState = obj;
		}

		public LogViewModel LogViewModel { get => logViewModel; set => SetProperty(ref logViewModel, value); }
		public SettingsViewModel SettingsViewModel { get => settingsViewModel; set => SetProperty(ref settingsViewModel, value); }
		public MessageListViewModel MessageListViewModel { get => messageListViewModel; set => SetProperty(ref messageListViewModel, value); }
		public StreamState StreamState { get => streamState; set => SetProperty(ref streamState, value); }

		private void MessageController_MessageReceived(Model.Message message)
		{
			var messageViewModel = new MessageViewModel(message);
			SendNotification(messageViewModel);
			MessageListViewModel.AddMessage(messageViewModel);

		}

		private void SendNotification(MessageViewModel message)
		{
			new ToastContentBuilder()
					//.AddArgument("action", "viewConversation")
					//.AddArgument("conversationId", 9813)
					//.AddHeader(message.Id.ToString(), message.Title, "")
					.AddText(message.Title)
					.AddText(message.Message)
					//.SetToastDuration(ToastDuration.Long)
					.Show();
		}
	}
}
