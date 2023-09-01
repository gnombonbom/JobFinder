using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Domain
{
    public class Vacancy
    {
        public Guid Id { get; }
        public User User { get; }
        public String Name { get; }
        public Int32 Salary { get; }
        public String Town { get; }
        public Otrasli Otrasl { get; }
        public Graphs Graph { get; }
        public String Description { get; }
        public String CompanyName { get; }

        public String DisplayPhone => $"{User.Phone}";
        public String GraphDisplay
        {
            get
            {
                switch (Graph)
                {
                    case Graphs.Вахта: return "Вахта";
                    case Graphs.Гибкий: return "Гибкий график";
                    case Graphs.Подработка: return "Подработка";
                    case Graphs.Полныйдень: return "Полный день";
                    case Graphs.Сменный: return "Сменный график";
                    case Graphs.Удаленнаяработа: return "Удаленная работа";
                    default: return "";
                }
            }
        }

        public Vacancy(Guid id, User user, String name, Int32 salary, String town, Otrasli otrasl, Graphs graph, String description, String companyName)
        {
            Id = id;
            User = user;
            Name = name;
            Salary = salary;
            Town = town;
            Otrasl = otrasl;
            Graph = graph;
            Description = description;
            CompanyName = companyName;
        }

    }
}
