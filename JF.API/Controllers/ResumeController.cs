using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;
using JF.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JF.API.Controllers
{
    [Route("index/[controller]")]
    [Area("Resume")]
    public class ResumeController : ControllerBase
    {
        private ResumeService _service = new("Data Source=Mikhuil;Initial Catalog=JobFinderDB;Integrated Security=True");

        [HttpPost]
        [Route("SaveResume")]
        public void SaveResume(ResumeBlank blank)
        {
            _service.SaveResume(blank);
        }

        [HttpGet]
        [Route("GetAllResume")]
        public async Task<IActionResult> GetAllResume()
        {
            List<Resume> resume = await _service.GetAllResume();
            return Ok(resume);
        }
        //var response = await client.GetAsync("https://localhost:7056/index/resume/SaveResume?stringContent='123'"); - GET запрос
    }
}
