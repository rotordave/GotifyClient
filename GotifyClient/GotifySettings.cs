using System;
using System.Collections.Generic;
using System.Text;

namespace GotifyClient
{
	public class GotifySettings
	{
		public string ServerUrl { get; set; }
		public string ClientToken { get; set; }
		public int LastNotificationId { get; set; }

		public bool ActivateOnMessage { get; set; }
	}
}
