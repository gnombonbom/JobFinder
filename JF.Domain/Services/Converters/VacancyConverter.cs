using JF.Domain.Models.DB;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services.Converters
{
    public static class VacancyConverter
    {
        public static List<Vacancy> ConvertToVacancies(this IEnumerable<VacancyDb> dbs, List<User> users)
        {
            Int32 i = 0;
            List<Vacancy> vacancies = new();
            foreach (VacancyDb db in dbs)
            {
                vacancies.Add(ConvertToVacancy(db, users[i]));
                i++;
            }
            return vacancies;
        }

        public static Vacancy ConvertToVacancy(this VacancyDb db, User user)
        {
            return new Vacancy(db.Id, user, db.Name, db.Salary, db.Town, db.Otrasl, db.Graph, db.Description, db.CompanyName);
        }
    }
}
