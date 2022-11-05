using BlazorBitcoinApp.DTOs;

namespace BlazorBitcoinApp.Services
{
    public class BitcoinService
    {
        private readonly HttpClient _httpClient;

        public BitcoinService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BitcoinDataDTO>> FindBy(DateTime startData)
        {

        }
    }
}
