using GotifyClient.Model;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GotifyClient
{
	internal static class GotifyClientApplication
    {
        internal static SettingsManager<GotifySettings> SettingsManager;
        internal static ClientViewModel ClientViewModel;
        internal static LogViewModel LogViewModel;

        static GotifyClientApplication()
        {
            SettingsManager = new SettingsManager<GotifySettings>("settings.json");
            LogViewModel = new LogViewModel();
            ClientViewModel = new ClientViewModel();
            
        }

	}
}
