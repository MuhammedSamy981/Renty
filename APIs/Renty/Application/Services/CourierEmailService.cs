using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Renty.Domain.Models;


namespace Renty.Application.Services
{
    public class CourierEmailService
{
    private readonly HttpClient _httpClient;
    private readonly string _courierToken;

    public CourierEmailService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _courierToken = config["Courier:AuthToken"]; // add this in appsettings
    }

    public async Task<bool> SendAsync(Message message)
    {
        var payload = new
        {
            message = new
            {
                to = new
                {
                    email = message.Email
                },
                template=  message.Template,
        data = new
        {
            link = message.Link
        },
                /*content = new
                {
                    title = message.Subject,
                    body = message.Body
                },*/
                routing = new
                {
                    method = "single",
                    channels = new[] { "email" }
                }
            }
        };

        var json = JsonSerializer.Serialize(payload);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.courier.com/send")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _courierToken);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }
}


    }
