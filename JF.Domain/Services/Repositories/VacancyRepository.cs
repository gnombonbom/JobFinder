using JF.Domain.Models.Blank;
using JF.Domain.Models.DB;
using JF.Domain.Models.Domain;
using JF.Domain.Services.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JF.Domain.Services.Repositories
{
    public class VacancyRepository
    {
        private String _connectionString;
        public VacancyRepository(String connect)
        {
            _connectionString = connect;
        }

        public void SaveVacancy(VacancyBlank blank)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("INSERT INTO vacancy VALUES(@p_id, @p_userid, @p_name, @p_salary, @p_town, @p_otrasl, @p_graph, @p_description, @p_companyname)", connect);
                cmd.Parameters.AddWithValue("@p_id", blank.Id);
                cmd.Parameters.AddWithValue("@p_userid", blank.UserId);
                cmd.Parameters.AddWithValue("@p_name", blank.Name);
                cmd.Parameters.AddWithValue("@p_salary", blank.Salary);
                cmd.Parameters.AddWithValue("@p_town", blank.Town);
                cmd.Parameters.AddWithValue("@p_otrasl", blank.Otrasl);
                cmd.Parameters.AddWithValue("@p_graph", blank.Graph);
                cmd.Parameters.AddWithValue("@p_description", blank.Description);
                cmd.Parameters.AddWithValue("@p_companyname", blank.CompanyName);

                cmd.ExecuteNonQuery();
            }
        }

        public async Task<List<Vacancy>> GetAll()
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("SELECT * FROM vacancy", connect);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return null;

                List<VacancyDb> vacancyList = new();
                List<User> users = new();
                while (reader.Read())
                {
                    VacancyDb db = new()
                    {
                        Id = (Guid)reader["id"],
                        UserId = (Guid)reader["userid"],
                        Description = (String)reader["description"],
                        CompanyName = (String)reader["companyname"],
                        Graph = (Graphs)reader["graph"],
                        Name = (String)reader["name"],
                        Salary = (Int32)reader["salary"],
                        Otrasl = (Otrasli)reader["otrasl"],
                        Town = (String)reader["town"]
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
                    vacancyList.Add(db);
                }

                return VacancyConverter.ConvertToVacancies(vacancyList, users);
            }
        }
    }
}
