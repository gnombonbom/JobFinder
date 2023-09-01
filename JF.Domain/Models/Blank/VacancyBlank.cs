using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Blank
{
    public class VacancyBlank
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public String? Name { get; set; }
        public Int32? Salary { get; set; }
        public String? Town { get; set; }
        public Otrasli? Otrasl { get; set; }
        public Graphs? Graph { get; set; }
        public String? Description { get; set; }
        public String? CompanyName { get; set; }

        public VacancyBlank() { }

        public VacancyBlank(Guid id, Guid? user, String? name, Int32? salary, String? town, Otrasli? otrasl, Graphs? graph, String? description, String? companyName)
        {
            Id = id;
            UserId = user;
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
