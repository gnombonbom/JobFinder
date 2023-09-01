using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Blank
{
    public class ResumeBlank
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Description { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Status Status { get; set; }
        public Int32 Salary { get; set; }
        public String Name { get; set; }
        public Graphs Graph { get; set; }
        public Otrasli Otrasl { get; set; }

        public ResumeBlank() { }

        public ResumeBlank(Guid id, Guid user, String description, String email, String phone, Status status, Int32 salary, String name, Graphs gr, Otrasli otr)
        {
            Id = id;
            UserId = user;
            Description = description;
            Email = email;
            Phone = phone;
            Status = status;
            Salary = salary;
            Name = name;
            Graph = gr;
            Otrasl = otr;
        }
    }
}
