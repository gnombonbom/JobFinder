using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;
using JF.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace JF.API.Controllers
{
    [Route("index/[controller]")]
    [Area("Vacancy")]
    public class VacancyController : Controller
    { 
        private VacancyService service = new("Data Source=Mikhuil;Initial Catalog=JobFinderDb;Integrated Security=True");

        [HttpPost]
        [Route("SaveVacancy")]
        public void SaveVacancy(VacancyBlank blank)
        {
            service.SaveVacancy(blank);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Vacancy> vacancies = await service.GetAll();
            return Ok(vacancies);
        }
    }
}
