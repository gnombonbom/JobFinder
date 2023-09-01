using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using JF.Domain.Models.DB;
using JF.Domain.Services.Converters;
using JF.Domain.Models.Blank;

namespace JF.Domain.Services.Repositories
{
    public class UserRepository
    {
        private String _connectionString;

        public UserRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveUser(UserBlank user)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("INSERT INTO users VALUES(@p_id, @p_firstname, @p_lastname, @p_patronymic, @p_birthdate, @p_login, @p_password, @p_education, @p_role, @p_phone)", connect);
                cmd.Parameters.AddWithValue("@p_id", user.Id);
                cmd.Parameters.AddWithValue("@p_firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@p_lastname", user.LastName);
                cmd.Parameters.AddWithValue("@p_patronymic", user.Patronymic);
                cmd.Parameters.AddWithValue("@p_birthdate", user.BirthDate);
                cmd.Parameters.AddWithValue("@p_login", user.Login);
                cmd.Parameters.AddWithValue("@p_password", user.Password);
                cmd.Parameters.AddWithValue("@p_education", user.Education);
                cmd.Parameters.AddWithValue("@p_role", user.Role);
                cmd.Parameters.AddWithValue("@p_phone", user.Phone);
                cmd.ExecuteNonQuery();
            }
        }
        public List<User> GetUsers()
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("SELECT * FROM user", connect);
                var reader = cmd.ExecuteReader();

                if (reader is null)
                    return null;

                List<UserDb> dbs = new();
                while (reader.Read())
                {
                    dbs.Add(new UserDb()
                    {
                        Id = (Guid)reader["id"],
                        FirstName = (String)reader["firstname"],
                        LastName = (String)reader["lastname"],
                        Patronymic = (String)reader["patronymic"],
                        BirthDate = (DateTime)reader["birthdate"],
                        Role = (UserRole)reader["role"],
                        Education = (UserEducation)reader["education"],
                    });
                }
                return UserConverter.ConvertToUsers(dbs);
            }
        }
        public User GetUserById(Guid id)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("SELECT * FROM users WHERE id = @p_id", connect);
                cmd.Parameters.AddWithValue("@p_id", id);
                var reader = cmd.ExecuteReader();

                if (reader is null)
                    return null;

                UserDb db = new();
                while (reader.Read())
                {
                    db = new()
                    {
                        Id = (Guid)reader["id"],
                        FirstName = (String)reader["firstname"],
                        LastName = (String)reader["lastname"],
                        Patronymic = (String)reader["patronymic"],
                        BirthDate = (DateTime)reader["birthdate"],
                        Role = (UserRole)reader["role"],
                        Education = (UserEducation)reader["education"],
                    };
                }
                return UserConverter.ConvertToUser(db);
            }
        }
        public User GetUserByLoginAndPassword(String login, String password)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("SELECT * FROM users WHERE login = @p_login AND password = @p_password", connect);
                cmd.Parameters.AddWithValue("@p_login", login);
                cmd.Parameters.AddWithValue("@p_password", password);
                var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                UserDb db = new();
                while (reader.Read())
                {
                    db = new()
                    {
                        Id = (Guid)reader["id"],
                        FirstName = (String)reader["firstname"],
                        LastName = (String)reader["lastname"],
                        Patronymic = (String)reader["patronymic"],
                        BirthDate = (DateTime)reader["birthdate"],
                        Role = (UserRole)reader["role"],
                        Education = (UserEducation)reader["education"],
                    };
                }
                return UserConverter.ConvertToUser(db);
            }
        }
        public void RemoveUser(Guid id)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("DELETE FROM user WHERE id = @p_id", connect);
                cmd.Parameters.AddWithValue("@p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
