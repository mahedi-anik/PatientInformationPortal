using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NCDDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NCDDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNCDDetails()
        {
            var users = await _unitOfWork.NCDDetails.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCDDetailsByID(int id)
        {
            var item = await _unitOfWork.NCDDetails.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNCDDetails(NCD_Details nCD_Details)
        {
            var item = await _unitOfWork.NCDDetails.Add(nCD_Details);
            await _unitOfWork.CompleteAsync();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNCDDetails(NCD_Details nCDDetails)
        {
            var item = await _unitOfWork.NCDDetails.Update(nCDDetails);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCDDetails(int id)
        {
            var item = await _unitOfWork.NCDDetails.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Patient.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
