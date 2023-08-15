using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotifyClient
{
	internal class SettingsViewModel : ObservableObject
	{
		SettingsManager<GotifySettings> settingsManager;
		GotifySettings gotifySettings;

		private string serverUrl;
		private string clientToken;
		private int lastNotificationId;

		public SettingsViewModel(SettingsManager<GotifySettings> settingsManager)
		{
			this.settingsManager = settingsManager;
		}

		public string ServerUrl { get => serverUrl; set => SetProperty(ref serverUrl, value); }

		public string ClientToken { get => clientToken; set => SetProperty(ref clientToken, value); }

		public int LastNotificationId { get => lastNotificationId; set => SetProperty(ref lastNotificationId, value); }

		internal void Load()
		{
			gotifySettings = settingsManager.LoadSettings();

			if (gotifySettings == null)
			{
				gotifySettings = new GotifySettings();
			}

			ServerUrl = gotifySettings.ServerUrl;
			ClientToken = gotifySettings.ClientToken;
			LastNotificationId = gotifySettings.LastNotificationId;
		}
	}
}
