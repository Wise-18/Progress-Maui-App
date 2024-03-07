using ProgressMauiApp.Services;
using System.Text.Json;

namespace ProgressMauiApp
{
    public class RateService : IRateService
    {
        private readonly HttpClient _httpClient;

        public RateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Rate> GetRates(DateTime date)
        {
            string apiUrl = $"https://api.nbrb.by/exrates/rates?ondate={date:yyyy-MM-dd}&periodicity=0";

            HttpResponseMessage response = _httpClient.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var rates = JsonSerializer.Deserialize<List<Rate>>(json);
                List<Rate> result = new List<Rate>();  

                if (rates != null)
                {
                    int[] requiredCurIds = { 456, 451, 431, 426, 462, 429 };

                    foreach (var rt in rates)
                        foreach (var rci in requiredCurIds)
                            if (rci == rt.Cur_ID)
                                result.Add(rt);

                    return result;
                }
            }

            return null;
        }
    }
}
