using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Model;
using Repository.Common;
using System.Data;

namespace Repository
{
    public class PepperRepository : IPepperRepository
    {
        static string con = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
        static SqlConnection conn = new SqlConnection(con);
        public async Task<int> DeletePepperAsync(int id)
        {
            SqlCommand delete = new SqlCommand("delete from Peppers where PepperID=@id;", conn);

            delete.Parameters.AddWithValue("@id", id);
            conn.Open();

            try
            {
                await delete.ExecuteNonQueryAsync();
                conn.Close();
                return 200;
            }
            catch (Exception)
            {
                conn.Close();
                return 400;
            }
        }

        public async Task<string> SavePepperAsync(PepperModel model)
        {
            SqlCommand insert = new SqlCommand("insert into Peppers values(@id, @name);", conn);

            insert.Parameters.AddWithValue("@id", model.ID);
            insert.Parameters.AddWithValue("@name", model.Name);

            conn.Open();

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = insert;
                await dataAdapter.InsertCommand.ExecuteNonQueryAsync();
                                       
                conn.Close();

                return "Ok";
            }
            catch (Exception e)
            {
                conn.Close();
                return e.ToString();
            }
        }

        public async Task<List<PepperModel>> GetAllPeppersAsync()
        {
            SqlCommand show = new SqlCommand("select * from Peppers;", conn);
            List<PepperModel> peppers = new List<PepperModel>();

            conn.Open();
            SqlDataReader reader = await show.ExecuteReaderAsync();

            try
            {
                string name = "";
                int id;
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        id = reader.GetInt32(0);
                        name = reader.GetString(1);

                        PepperModel pepper = new PepperModel();

                        pepper.ID = id;
                        pepper.Name = name;

                        peppers.Add(pepper);
                    }
                }
                               
                reader.Close();
                conn.Close();
                return peppers;
            }
            catch (Exception)
            {
                conn.Close();
                return null;
            }
        }

        public async Task<int> UpdatePepperAsync(PepperModel model)
        {
            SqlCommand update = new SqlCommand("update Peppers set PepperName = @name where PepperID = @id;", conn); ;

            update.Parameters.AddWithValue("@id", model.ID);
            update.Parameters.AddWithValue("@name", model.Name);

            conn.Open();

            try
            {
                await update.ExecuteNonQueryAsync();
                conn.Close();
                return 200;
            }
            catch (Exception)
            {
                conn.Close();
                return 400;
            }
        }
    }
}
