namespace BlazorBitcoinApp.DTOs
{
    public class BitcoinDataDTO_
    {
        public BitcoinDataDTO_()
        {

        }
        public BitcoinDataDTO_(DateTime day, decimal closeValue)
        {
            Day = day;
            CloseValue = closeValue;
        }

        public DateTime Day { get; set; }
        public decimal CloseValue { get; set; }
    }
}
