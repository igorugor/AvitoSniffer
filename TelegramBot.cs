using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AvitoSniffer
{
    public class ChatData
    {
        public long chat_id { get; set; }
        public string text { get; set; }
    }

    internal class TelegramBot
    {
        private string baseUrl = "";
        private string token = "";
        private long chatId = 0;

        private HttpClient _httpClient = new HttpClient();

        public TelegramBot(string baseUrl, string token, long chatId)
        {
            this.baseUrl = baseUrl;
            this.token = token;
            this.chatId = chatId;
        }

        public async void SendMessage(string message)
        {
            var json = JsonConvert.SerializeObject(new ChatData
            {
                chat_id = this.chatId,
                text = message
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try { await _httpClient.PostAsync(this.baseUrl + this.token + "/sendMessage", content); } catch { }
        }
    }
}
