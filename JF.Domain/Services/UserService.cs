using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;
using JF.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services
{
    public class UserService
    {
        private UserRepository _repository;

        public UserService(String connectionString)
        {
            _repository = new(connectionString);
        }


        public void SaveUser(UserBlank blank)
        {
            if (blank.Id is null) return;
            if (String.IsNullOrWhiteSpace(blank.FirstName)) return;
            if (String.IsNullOrWhiteSpace(blank.LastName)) return;
            if (String.IsNullOrWhiteSpace(blank.Patronymic)) return;
            if (blank.BirthDate is null) return;
            if (String.IsNullOrWhiteSpace(blank.Login)) return;
            if (blank.Role is null) return;
            if (blank.Education is null) return;

            _repository.SaveUser(blank);
        }
        public List<User> GetUsers()
        {
            return _repository.GetUsers();
        }
        public async Task<User> GetUserById(Guid id)
        {
            if (id == Guid.Empty) return null;

            User user = _repository.GetUserById(id);

            return user;
        }
        public User GetUserByLoginAndPassword(String login, String password)
        {
            if (String.IsNullOrWhiteSpace(login))
                return null;

            if (String.IsNullOrWhiteSpace(password))
                return null;

            return _repository.GetUserByLoginAndPassword(login, password);
        }
        public void RemoveUser(Guid id)
        {
            if (id == Guid.Empty) return;
            _repository.RemoveUser(id);
        }
    }
}
