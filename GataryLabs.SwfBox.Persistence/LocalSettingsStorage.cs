using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Persistence
{
    internal class LocalSettingsStorage<TSettings> where TSettings : new()
    {
        private readonly SemaphoreSlim semaphor = new SemaphoreSlim(1, 1);

        public async Task<TSettings> LoadAsync(string path, CancellationToken cancellationToken)
        {
            if (!File.Exists(path))
                return default;

            string rawData = await ReadTextFileAsync(path, cancellationToken);

            if (string.IsNullOrWhiteSpace(rawData))
            {
                return default;
            }

            TSettings deserializedSettings = JsonConvert.DeserializeObject<TSettings>(rawData);
            return deserializedSettings;
        }

        private async Task<string> ReadTextFileAsync(string path, CancellationToken cancellationToken)
        {
            await semaphor.WaitAsync();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return await reader.ReadToEndAsync(cancellationToken);
                }
            }
            finally
            {
                semaphor.Release();
            }
        }

        public async Task SaveAsync(TSettings settings, string path, CancellationToken cancellationToken)
        {
            string serializedSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);

            await WriteTextFileAsync(serializedSettings, path, cancellationToken);
        }

        private async Task WriteTextFileAsync(string text, string path, CancellationToken cancellationToken)
        {
            await semaphor.WaitAsync();

            try
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    await writer.WriteAsync(text.ToCharArray(), cancellationToken);
                }
            }
            finally
            {
                semaphor.Release();
            }
        }
    }
}