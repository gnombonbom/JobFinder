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
    public class ResumeService
    {
        private ResumeRepository _repository;

        public ResumeService(String connect)
        {
            _repository = new(connect);
        }
        public void SaveResume(ResumeBlank blank)
        {
            _repository.SaveResume(blank);
        }

        public async Task<List<Resume>> GetAllResume()
        {
            return await _repository.GetAllResume();
        }
    }
}
