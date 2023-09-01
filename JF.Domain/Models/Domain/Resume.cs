using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.Domain
{
    public class Resume
    {
        public Guid Id { get; }
        public User User { get; }
        public String Description { get; }
        public String Email { get; }
        public String Phone { get; }
        public Status Status { get; }
        public Int32 Salary { get; }
        public String Name { get; }
        public Graphs Graph { get; }
        public Otrasli Otrasl { get; }

        public Resume(Guid id, User user, String description, String email, String phone, Status status, Int32 salary, String name, Graphs gr, Otrasli otr)
        {
            Id = id;
            User = user;
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
