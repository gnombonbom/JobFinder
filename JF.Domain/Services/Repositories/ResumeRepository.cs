using JF.Domain.Models.Blank;
using JF.Domain.Models.DB;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using JF.Domain.Services.Converters;

namespace JF.Domain.Services.Repositories
{
    public class ResumeRepository
    {
        private String _connectionString;

        public ResumeRepository(String connect)
        {
            _connectionString = connect;
        }
        public void SaveResume(ResumeBlank blank)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("INSERT INTO resume VALUES (@p_id, @p_userid, @p_desc, @p_email, @p_status, @p_salary, @p_gr, @p_otr, @p_name)", connect);
                cmd.Parameters.AddWithValue("@p_id", blank.Id);
                cmd.Parameters.AddWithValue("@p_userid", blank.UserId);
                cmd.Parameters.AddWithValue("@p_desc", blank.Description);
                cmd.Parameters.AddWithValue("@p_email",blank.Email);
                cmd.Parameters.AddWithValue("@p_status", blank.Status);
                cmd.Parameters.AddWithValue("@p_salary", blank.Salary);
                cmd.Parameters.AddWithValue("@p_gr", blank.Graph);
                cmd.Parameters.AddWithValue("@p_otr", blank.Otrasl);
                cmd.Parameters.AddWithValue("@p_name", blank.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public async Task<List<Resume>> GetAllResume()
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("SELECT * FROM resume", connect);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return null;

                List<ResumeDb> resumeList = new();
                List<User> users = new();
                while(reader.Read())
                {
                    ResumeDb db = new()
                    {
                        Id = (Guid)reader["id"],
                        UserId = (Guid)reader["userid"],
                        Description = (String)reader["description"],
                        Email = (String)reader["email"],
                        Status = (Status)reader["status"],
                        Salary = (Int32)reader["salary"]
                    };
                    User user;
                    using (HttpClient client = new())
                    {
                        HttpResponseMessage response = await client.GetAsync($"https://localhost:7056/index/user/{db.UserId}");
                        if (response.IsSuccessStatusCode)
                        {
                            user = await response.Content.ReadAsAsync<User>();
                            users.Add(user);
                        }
                    }
                    resumeList.Add(db);
                }

                return ResumeConverter.ConvertToResumes(resumeList, users);
            }
        }

        public void RemoveResume(Guid id)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("DELETE FROM resume WHERE id = @p_id", connect);
                cmd.Parameters.AddWithValue("@p_id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
