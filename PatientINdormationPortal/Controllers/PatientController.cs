using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.Interface;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientList()
        {
            var item = await _unitOfWork.Patient.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByID(int id)
        {
            var item = await _unitOfWork.Patient.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(Patient patient)
        {
            var item=await _unitOfWork.Patient.Add(patient);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            var item = await _unitOfWork.Patient.Update(patient);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var item = await _unitOfWork.Patient.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Patient.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}

