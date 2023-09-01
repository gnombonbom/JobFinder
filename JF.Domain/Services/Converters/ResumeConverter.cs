using JF.Domain.Models.DB;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services.Converters
{
    public static class ResumeConverter
    {
        public static List<Resume> ConvertToResumes(this IEnumerable<ResumeDb> dbs, List<User> users)
        {
            Int32 i = 0;
            List<Resume> resumes = new();
            foreach (ResumeDb db in dbs)
            {
                resumes.Add(ConvertToResume(db, users[i]));
                i++;
            }
            return resumes;
        }

        public static Resume ConvertToResume(this ResumeDb db, User user)
        {
            return new Resume(db.Id, user, db.Description, db.Email, db.Phone, db.Status, db.Salary, db.Name, db.Graph, db.Otrasl);
        }
    }
}
