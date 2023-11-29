using System.Text;

namespace HashtagHelpClient.Services;
public class FunnelService
{
    string apiUrl = "http://192.168.1.139:5000";
    string endpoint = "/api/Funnel/googleSheetsUpload";
    private readonly HttpClient _httpClient;

    public FunnelService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<string> SendDataAsync(string jsonData)
    {
        try
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            // Обработка ошибок
            return $"Error: {ex.Message}";
        }
    }
}
