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
	internal class MessageController
	{
		internal event Action<Message> MessageReceived;
		internal event Action<StreamState> StreamStateChanged;
		private event Action<string> StreamDataReceived;
		private SettingsViewModel settings;
		private StreamState streamState = StreamState.Disconnected;
		private StreamState streamStateRequested = StreamState.Disconnected;

		public MessageController(SettingsViewModel settings)
		{
			this.settings = settings;

			StreamDataReceived += MessageController_StreamDataReceived;
		}

		//"{\"id\":32339,\"appid\":1,\"message\":\"Yyy\",\"title\":\"tttt\",\"priority\":0,\"date\":\"2021-08-03T14:45:19.06757736+10:00\"}\n"
		private void MessageController_StreamDataReceived(string messageData)
		{
			var message = JsonSerializer.Deserialize<Message>(messageData, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,

			});

			Task.Run(() => MessageReceived?.Invoke(message));
		}

		public void Disconect()
		{
			streamStateRequested = StreamState.Disconnected;

		}

		int connectTimeout = 5000;
		int connectTimeoutIncrement = 5000;
		int connectTimeoutMax = 60000;

		private void ReconnectTimeout(string message)
		{
			if (connectTimeout < connectTimeoutMax)
			{
				connectTimeout += connectTimeoutIncrement;
			}
			Log.Error(message + $". Reconnecting in {TimeSpan.FromMilliseconds(connectTimeout).TotalSeconds}s.");
			System.Threading.Thread.Sleep(connectTimeout);

		}
		private void ResetTimeout()
		{
			connectTimeout = 5000;
		}

		public void OpenStream() // check not opening multiple streams?
		{
			streamStateRequested = StreamState.Connected;

			Task.Run(() =>
			{
				var uri = "ws://" + settings.ServerUrl + "/stream?token=" + settings.ClientToken;

				while (streamStateRequested == StreamState.Connected)
				{
					using (ClientWebSocket ws = new ClientWebSocket())
					{
						Uri serverUri = new Uri(uri);

						var connectSource = new CancellationTokenSource(5000);
						var readSource = new CancellationTokenSource();
						//source.CancelAfter(500000);


						try
						{
							bool connected = false;
							StreamStateUpdate(StreamState.Disconnected);
							Log.Info($"Connecting to stream at {uri}");
							StreamStateUpdate(StreamState.Connecting);
							var connectTask = ws.ConnectAsync(serverUri, connectSource.Token);
							//Task.Run(() =>
							//{
							//	while (ws.State != WebSocketState.Open && connectTask.Status != TaskStatus.RanToCompletion && connectTask.Status != TaskStatus.Faulted && connectTask.Status != TaskStatus.WaitingForActivation)
							//	{
							//		System.Threading.Thread.Sleep(1000);
							//	}
							//	Log.Info($"ws.State != WebSocketState.Open: {ws.State}");
							//	if (ws.State != WebSocketState.Open)
							//	{
							//		connectSource.Cancel();
							//	}
							//});
							//connectTask.ContinueWith((result) =>
							//{
							//	if (result.Exception != null)
							//	{
							//		Log.Error($"Could not connect to stream: {result.Exception.GetBaseException().Message}");
							//		System.Threading.Thread.Sleep(5000);
							//	}
							//	else
							//	{
							//		connected = ws.State == WebSocketState.Open;
							//	}
							//});
							connectTask.Wait();
							if (ws.State != WebSocketState.Open)
							{
								continue;
							}
							ResetTimeout();
							Task.Run(() =>
							{

								while (ws.State == WebSocketState.Open)
								{
									System.Threading.Thread.Sleep(1000);
								}
								Log.Info($"ws.State != WebSocketState.Open: {ws.State}");
								readSource.Cancel();
							});
							Log.Info($"Connected");
							StreamStateUpdate(StreamState.Connected);
						}
						catch (TaskCanceledException)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"TaskCanceledException while connecting to stream");
							continue;
						}
						catch (AggregateException ex)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"Could not connect to stream: {ex.GetBaseException().Message}");
							continue;
						}
						catch (Exception ex)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"Could not connect to stream: {ex.Message}");
							continue;
						}

						while (ws.State == WebSocketState.Open)
						{
							var receiveBuffer = new byte[8192];
							string message = "";
							bool readData = true;
							while (readData)
							{
								ArraySegment<byte> bytesReceived = new ArraySegment<byte>(receiveBuffer);
								Log.Info($"Stream: Waiting for data");
								var receiveTask = ws.ReceiveAsync(bytesReceived, readSource.Token);

								try
								{
									receiveTask.ContinueWith((result) =>
									{
										if (result.Exception != null)
										{
											Log.Error($"Error while receiving bytes from stream: {receiveTask.Exception.GetBaseException().Message}");
											readData = false;
										}
										else
										{
											Log.Info($"Stream: Received {result.Result.Count} bytes");

											if (result.Result.MessageType == WebSocketMessageType.Close)
											{
												Log.Info($"Stream: Received Close message - {result.Result.CloseStatus}: {result.Result.CloseStatusDescription}");
												readData = false;
											}
											else
											{
												if (result.Result.EndOfMessage)
												{
													message += Encoding.UTF8.GetString(receiveBuffer, 0, result.Result.Count);
													Log.Info($"Stream: Received message: {message}");
													StreamDataReceived?.Invoke(message);
													message = "";
												}
											}
										}
									}).Wait();

									if (receiveTask.Exception != null)
									{
										Log.Error($"Error while receiving bytes from stream: {receiveTask.Exception.GetBaseException().Message}");
										break;
									}
								}
								catch (TaskCanceledException)
								{
									Log.Warn($"TaskCanceledException while reading from stream");
									break;
								}
							}

						}

					}
				}

			});

		}


		public void OpenStreamOld() // check not opening multiple streams?
		{
			streamStateRequested = StreamState.Connected;

			Task.Run(() =>
			{
				var uri = "ws://" + settings.ServerUrl + "/stream?token=" + settings.ClientToken;

				while (streamStateRequested == StreamState.Connected)
				{
					using (ClientWebSocket ws = new ClientWebSocket())
					{
						Uri serverUri = new Uri(uri);

						var connectSource = new CancellationTokenSource(5000);
						var readSource = new CancellationTokenSource();
						//source.CancelAfter(500000);


						try
						{
							bool connected = false;
							StreamStateUpdate(StreamState.Disconnected);
							Log.Info($"Connecting to stream at {uri}");
							StreamStateUpdate(StreamState.Connecting);
							var connectTask = ws.ConnectAsync(serverUri, connectSource.Token);
							//Task.Run(() =>
							//{
							//	while (ws.State != WebSocketState.Open && connectTask.Status != TaskStatus.RanToCompletion && connectTask.Status != TaskStatus.Faulted && connectTask.Status != TaskStatus.WaitingForActivation)
							//	{
							//		System.Threading.Thread.Sleep(1000);
							//	}
							//	Log.Info($"ws.State != WebSocketState.Open: {ws.State}");
							//	if (ws.State != WebSocketState.Open)
							//	{
							//		connectSource.Cancel();
							//	}
							//});
							//connectTask.ContinueWith((result) =>
							//{
							//	if (result.Exception != null)
							//	{
							//		Log.Error($"Could not connect to stream: {result.Exception.GetBaseException().Message}");
							//		System.Threading.Thread.Sleep(5000);
							//	}
							//	else
							//	{
							//		connected = ws.State == WebSocketState.Open;
							//	}
							//});
							connectTask.Wait();
							if (ws.State != WebSocketState.Open)
							{
								continue;
							}
							ResetTimeout();
							Task.Run(() =>
							{

								while (ws.State == WebSocketState.Open)
								{
									System.Threading.Thread.Sleep(1000);
								}
								Log.Info($"ws.State != WebSocketState.Open: {ws.State}");
								readSource.Cancel();
							});
							Log.Info($"Connected");
							StreamStateUpdate(StreamState.Connected);
						}
						catch (TaskCanceledException)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"TaskCanceledException while connecting to stream");
							continue;
						}
						catch (AggregateException ex)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"Could not connect to stream: {ex.GetBaseException().Message}");
							continue;
						}
						catch (Exception ex)
						{
							StreamStateUpdate(StreamState.Disconnected);
							ReconnectTimeout($"Could not connect to stream: {ex.Message}");
							continue;
						}

						while (ws.State == WebSocketState.Open)
						{
							var receiveBuffer = new byte[8192];

							var offset = 0;
							var dataPerPacket = 1024;
							bool readData = true;
							while (readData)
							{
								ArraySegment<byte> bytesReceived = new ArraySegment<byte>(receiveBuffer, offset, dataPerPacket);
								Log.Info($"Stream: Waiting for data");
								var receiveTask = ws.ReceiveAsync(bytesReceived, readSource.Token);

								try
								{
									receiveTask.ContinueWith((result) =>
									{
										if (result.Exception != null)
										{
											Log.Error($"Error while receiving bytes from stream: {receiveTask.Exception.GetBaseException().Message}");
											readData = false;
										}
										else
										{
											Log.Info($"Stream: Received {result.Result.Count} bytes");

											if (result.Result.MessageType == WebSocketMessageType.Close)
											{
												Log.Info($"Stream: Received Close message - {result.Result.CloseStatus}: {result.Result.CloseStatusDescription}");
												readData = false;
											}
											else
											{
												offset += result.Result.Count;
												if (result.Result.EndOfMessage)
												{
													var message = Encoding.UTF8.GetString(receiveBuffer, 0, offset);
													Log.Info($"Stream: Received message: {message}");
													StreamDataReceived?.Invoke(message);
												}
											}
										}
									}).Wait();

									if (receiveTask.Exception != null)
									{
										Log.Error($"Error while receiving bytes from stream: {receiveTask.Exception.GetBaseException().Message}");
										break;
									}
								}
								catch (TaskCanceledException)
								{
									Log.Warn($"TaskCanceledException while reading from stream");
									break;
								}
							}

						}

					}
				}

			});

		}

		private void StreamStateUpdate(StreamState state)
		{
			streamState = state;
			Task.Run(() => StreamStateChanged?.Invoke(state));
		}

		internal enum StreamState
		{
			Disconnected,
			Connecting,
			Connected
		}
	}
}
