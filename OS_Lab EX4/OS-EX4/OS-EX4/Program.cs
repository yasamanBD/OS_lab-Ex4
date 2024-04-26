using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace OS_EX4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> urls = new List<string>
            {
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Pezhman%20Kalani%20-%20Ye%20Dooneyi.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Amin%20Aslani%20-%20Zeynoo.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Arash%20Maghsoud%20%26%20Hossein%20Mokhte-%20Aroose%20Bandar.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Mohammad%20Penhan%20-%20Darya.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Mahmoud-Jahan-Dal-Adas.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Nakhoda%20Heydari%20-%20Bargh%20Ofto.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Mohsen_Khosroabadi-Remix_Bandari.mp3",
                "https://dl.musicmehr.net/Music/A/J/Jonoobishad/Mohsen-Chavoshi-Bazar-Khoramshahr-%28320%29.mp3"
            };

            await DownloadUrlsAsync(urls);
        }

        static async Task DownloadUrlsAsync(List<string> urls)
        {
            List<Task> downloadTasks = new List<Task>();

            foreach (string url in urls)
            {
                downloadTasks.Add(Task.Run(() => DownloadUrl(url)));
            }

            await Task.WhenAll(downloadTasks);
        }

        static void DownloadUrl(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string fileName = Path.GetFileName(url);
                    client.DownloadFile(new Uri(url), fileName);

                    Console.WriteLine($"Downloaded {url} successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to download {url}: {ex.Message}");
                }
            }
        }
    }

}
