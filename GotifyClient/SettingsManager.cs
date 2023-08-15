using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GotifyClient
{
    public class SettingsManager<T> where T : class
    {
        private readonly string filePath;

        public SettingsManager(string fileName)
        {
            filePath = GetLocalFilePath(fileName);
        }

        private string GetLocalFilePath(string fileName)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, fileName);
        }

        public T LoadSettings() =>
            File.Exists(filePath) ?
            JsonSerializer.Deserialize<T>(File.ReadAllText(filePath)) :
            null;

        public void SaveSettings(T settings)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(filePath, json);
        }
    }
}
