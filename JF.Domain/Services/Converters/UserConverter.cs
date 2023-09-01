using JF.Domain.Models.DB;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services.Converters
{
    public static class UserConverter
    {
        public static List<User> ConvertToUsers(this IEnumerable<UserDb> dbs)
        {
            List<User> users = new();
            foreach(UserDb db in dbs)
            {
                users.Add(ConvertToUser(db));
            }
            return users;
        }

        public static User ConvertToUser(this UserDb db)
        {
            return new User(db.Id, db.FirstName, db.LastName, db.Patronymic, db.BirthDate, db.Education, db.Role, db.Phone);
        }
    }
}
