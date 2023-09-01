using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Domain
{
    public class User
    {
        public Guid Id { get; }
        public String FirstName { get; }
        public String LastName { get; }
        public String? Patronymic { get; }
        public DateTime BirthDate { get; }
        public UserRole Role { get; }
        public UserEducation Education { get; }
        public String Phone { get; }

        public User(Guid id, String firstName, String lastName, String? patronymic, DateTime birthDate, UserEducation education, UserRole role, String phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Education = education;
            Role = role;
            Phone = phone;
        }

        public String DisplayName => $"{LastName} {FirstName} {Patronymic}";
        public String DisplayEducation
        {
            get
            {
                switch(Education)
                {
                    case UserEducation.BasicGeneral:
                        return "Основное общее";
                    case UserEducation.GeneralSecondary:
                        return "Среднее образование";
                    case UserEducation.SecondaryProfessional:
                        return "Среднее профессиональное";
                    case UserEducation.Higher:
                        return "Высшее";
                    default: return "Нет";
                }
            }
        }
    }

}
