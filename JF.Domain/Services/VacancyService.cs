using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;
using JF.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services
{
    public class VacancyService
    {
        private VacancyRepository _repository;

        public VacancyService(String connect)
        {
            _repository = new(connect);
        }

        public void SaveVacancy(VacancyBlank blank)
        {
            _repository.SaveVacancy(blank);
        }

        public async Task<List<Vacancy>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
