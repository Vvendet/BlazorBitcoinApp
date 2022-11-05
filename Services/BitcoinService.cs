using BlazorBitcoinApp.DTOs;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace BlazorBitcoinApp.Services
{
    public class BitcoinService : IBitcoinService
    {
        private readonly HttpClient _httpClient;

        public BitcoinService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BitcoinDataDTO>> FindBy(DateTime startData)
        {
            var response = await _httpClient.GetAsync($"data.messari.io/api/v1/markets/binance-btc-usdt/metrics/price/time-series?start={startData.ToString("yyyy-MM-dd")}&interval=1d");
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResult);
            var values = jObject.SelectToken("data.values").ToString();

            if (string.IsNullOrEmpty(values))
            {
                return new List<BitcoinDataDTO>();
            }
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<decimal[]>>(values);

            return data.Select(d => new BitcoinDataDTO(new DateTime(1970, 1, 1).AddMilliseconds((long)d[0]), d[3])).ToList();
        }
    }
}
