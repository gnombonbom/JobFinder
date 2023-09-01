using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.DB
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public UserEducation Education { get; set; }
        public UserRole Role { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
    }
}
