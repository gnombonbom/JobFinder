using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Models.DB
{
    public class ResumeDb
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
    }
}
