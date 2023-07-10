using Assignment.Models;
using Newtonsoft.Json;
using PatientInformationPortalAPI.Models;
using PatientInformationPortaUI.Models;

namespace PatientINdormationPortalUI.Services
{
    public class Service : IService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        readonly string apiGetAllDiseases = "https://localhost:7009/api/GetList/GetAllDiseases";
        readonly string apiGetAllAllergies = "https://localhost:7009/api/GetList/GetAllAllergies";
        readonly string apiGetAllNCDs = "https://localhost:7009/api/GetList/GetAllNCDs";
        public Service(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Allergies>> GetAllAllergies()
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient();
                var response = await _httpClient.GetAsync(apiGetAllAllergies);
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Allergies>>(responseData);
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return null;
        }

        public async Task<List<Disease>> GetAllDiseases()
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient();
                var response = await _httpClient.GetAsync(apiGetAllDiseases);
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Disease>>(responseData);
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return null;
        }

        public async Task<List<NCD>> GetAllNCDs()
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient();
                var response = await _httpClient.GetAsync(apiGetAllNCDs);
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<NCD>>(responseData);
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return null;
        }
        
    }
}
