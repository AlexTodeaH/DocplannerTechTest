using DocplannerTechTest.Application.Configuration;
using DocplannerTechTest.Application.Features.Availability.Models;
using DocplannerTechTest.Application.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DocplannerTechTest.Application.Services
{
    public class SlotService : ISlotService
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceUrlsConfig _serviceUrlsConfig;
        private readonly AuthenticationConfig _authConfig;

        public SlotService(HttpClient httpClient, IOptions<ServiceUrlsConfig> serviceUrlsConfig, IOptions<AuthenticationConfig> authConfig)
        {
            _httpClient = httpClient;
            _serviceUrlsConfig = serviceUrlsConfig.Value;
            _authConfig = authConfig.Value;

            // Configure the HttpClient with Basic Authorization
            var authToken = Encoding.ASCII.GetBytes($"{_authConfig.Username}:{_authConfig.Password}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
        }

        public async Task<string> GetWeeklyAvailability(string date)
        {
            var response = await _httpClient.GetAsync($"{_serviceUrlsConfig.AvailabilityApi}/GetWeeklyAvailability/{date}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching weekly availability: {response.ReasonPhrase}");
            }
            return await response.Content.ReadAsStringAsync();
        }

        public async Task TakeSlot(TakeSlotRequest slotRequest)
        {
            var jsonContent = JsonConvert.SerializeObject(slotRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_serviceUrlsConfig.AvailabilityApi}/TakeSlot", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error taking slot: {response.ReasonPhrase}");
            }
        }
    }
}
