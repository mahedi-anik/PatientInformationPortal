using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortalAPI.Models;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;

namespace PatientINdormationPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetListController : ControllerBase
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;
        public GetListController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DbConnection");
        }
        [HttpGet]
        public JsonResult GetAllDiseases()
        {
            string query = @"
                     select DiseaseName,DiseaseID from Diseases 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet]
        public JsonResult GetAllAllergies()
        {
            string query = @"
                     select AllergiesName,AllergiesID from Allergies
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet]
        public JsonResult GetAllNCDs()
        {
            string query = @"
                     select NCDName,NCDID from NCDs
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
