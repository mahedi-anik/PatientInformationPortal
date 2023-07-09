using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientInformationPortaUI.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace PatientInformationPortaUI.Controllers
{
    public class PatientController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7009/api");
        private readonly HttpClient _httpClient;
        public PatientController()
        {
            _httpClient=new HttpClient();
            _httpClient.BaseAddress = baseAddress;  
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<PatientViewModel> patientsList = new List<PatientViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Patient/GetAllPatientList").Result;
             if(response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                patientsList = JsonConvert.DeserializeObject<List<PatientViewModel>>(data);
            }
            
            return View(patientsList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PatientViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Patient/CreatePatient", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Patient Created.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"]=ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                PatientViewModel patient = new PatientViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient
                    .BaseAddress + "/Patient/GetPatientByID/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    patient = JsonConvert.DeserializeObject<PatientViewModel>(data);
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
       
        }
        [HttpPost]
        public IActionResult Edit(PatientViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Patient/UpdatePatient", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Patient Updated.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View() ;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                PatientViewModel patient = new PatientViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient
                    .BaseAddress + "/Patient/GetPatientByID/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    patient = JsonConvert.DeserializeObject<PatientViewModel>(data);
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            } 
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient
                        .BaseAddress + "/Patient/DeletePatient/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }


    }
}
