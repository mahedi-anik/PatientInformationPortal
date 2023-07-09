using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllergiesDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllergiesDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergiesDetails()
        {
            var users = await _unitOfWork.AllergiesDetails.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergiesDetailsByID(int id)
        {
            var item = await _unitOfWork.AllergiesDetails.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAllergiesDetails(Allergies_Details allergies_Details)
        {
            var item = await _unitOfWork.AllergiesDetails.Add(allergies_Details);
            await _unitOfWork.CompleteAsync();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAllergiesDetails(Allergies_Details allergies_Details)
        {
            var item = await _unitOfWork.AllergiesDetails.Update(allergies_Details);
            await _unitOfWork.CompleteAsync();

            return Ok(item);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergiesDetails(int id)
        {
            var item = await _unitOfWork.AllergiesDetails.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Patient.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
