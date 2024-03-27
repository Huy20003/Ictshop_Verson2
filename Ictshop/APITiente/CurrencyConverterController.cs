using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ictshop.APITiente
{
    public class CurrencyConverterController: ICurrencyConverter
    {
        private const string ApiKey = "10c97f8490bd6a6950579515";
        private const string BaseUrl = "https://v6.exchangerate-api.com/v6/10c97f8490bd6a6950579515/latest/USD";


        public async Task<decimal> ConvertVNDToUSD(decimal amount)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    HttpResponseMessage response = await client.GetAsync($"{ApiKey}/latest/VND");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var data = JsonConvert.DeserializeObject<ExchangeRateResponse>(json);

                        // Lấy tỷ giá từ VND sang USD từ dữ liệu JSON
                        double exchangeRate = data.conversion_rates.USD;

                        // Chuyển đổi giá tiền từ VND sang USD
                        decimal convertedAmount = amount / (decimal)exchangeRate;

                        return convertedAmount;
                    }
                    else
                    {
                        // Xử lý trường hợp lấy dữ liệu không thành công
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return 0;
            }
        }
    }

    public class ExchangeRateResponse
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_last_update_unix { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update_unix { get; set; }
        public string time_next_update_utc { get; set; }
        public string base_code { get; set; }
        public ConversionRates conversion_rates { get; set; }
    }

    public class ConversionRates
    {
        public double USD { get; set; }
        // Các loại tiền tệ khác có thể được thêm vào đây
    }
}
