using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Blank
{
    public class UserBlank
    {
        public Guid? Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
        public String? Login { get; set; }
        public String? Password { get; set; }
        public UserRole? Role { get; set; }
        public UserEducation? Education { get; set; }
        public String? Phone { get; set; }

        public UserBlank() { }

        public UserBlank(Guid? id, String? firstName, String? lastName, String? patronymic, DateTime? birthDate, String? login, String? password, UserRole? role, UserEducation? education, String? phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Login = login;
            Password = password;
            Role = role;
            Education = education;
            Phone = phone;
        }
    }
}
