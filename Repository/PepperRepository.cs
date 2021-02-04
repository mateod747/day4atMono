using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Configuration;
using System.Text;
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
        public int DeletePepperOrShop(int id, int pepperOrShop)
        {
            SqlCommand delete;
            if (pepperOrShop == 0)
            {
                delete = new SqlCommand("delete from Peppers where PepperID=@id;", conn);
            }
            else
            {
                delete = new SqlCommand("delete from Peppers where ShopID=@id;", conn);
            }
            delete.Parameters.AddWithValue("@id", id);
            conn.Open();

            try
            {
                delete.ExecuteNonQuery();
                conn.Close();
                return 200;
            }
            catch (Exception)
            {
                conn.Close();
                return 400;
            }
        }

        public string SavePepperOrShop(PepperModel model, int pepperOrShop)
        {
            //SqlCommand insert;

            //if (pepperOrShop == 0)
            //{
            //    insert = new SqlCommand("insert into Peppers values(@id, @name);", conn);
            //}
            //else
            //{
            //    insert = new SqlCommand("insert into PepperShops values(@id, @name);", conn);
            //}

            //insert.Parameters.AddWithValue("@id", model.ID);
            //insert.Parameters.AddWithValue("@name", model.Name);

            //conn.Open();

            //try
            //{
            //    insert.ExecuteNonQuery();
            //    conn.Close();
            //    return 200;
            //}
            //catch (Exception)
            //{
            //    conn.Close();
            //    return 200;
            //}


            SqlCommand insert;

            if (pepperOrShop == 0)
            {
                insert = new SqlCommand("insert into Peppers values(@id, @name);", conn);
            }
            else
            {
                insert = new SqlCommand("insert into PepperShops values(@id, @name);", conn);
            }

            insert.Parameters.AddWithValue("@id", model.ID);
            insert.Parameters.AddWithValue("@name", model.Name);

            conn.Open();

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = insert;
                dataAdapter.InsertCommand.ExecuteNonQuery();
                                       
                conn.Close();

                return "Ok";
            }
            catch (Exception e)
            {
                conn.Close();
                return e.ToString();
            }
        }

        public PepperModel ShowPepperOrShop(int id, int pepperOrShop)
        {
            SqlCommand show;
            if (pepperOrShop == 0)
            {
                show = new SqlCommand("select * from Peppers where PepperID=@id;", conn);
            }
            else
            {
                show = new SqlCommand("select * from PepperShops where ShopID=@id;", conn);
            }

            show.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader reader = show.ExecuteReader();

            try
            {
                string name = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(1);
                    }
                }

                PepperModel pepper = new PepperModel();

                pepper.ID = id;
                pepper.Name = name;

                reader.Close();
                conn.Close();
                return pepper;
            }
            catch (Exception)
            {
                conn.Close();
                return null;
            }
        }

        public int UpdatePepperOrShop(PepperModel model, int pepperOrShop)
        {
            SqlCommand update;

            if (pepperOrShop == 0)
            {
                update = new SqlCommand("update Peppers set PepperName = @name where PepperID = @id;", conn);
            }
            else
            {
                update = new SqlCommand("update PepperShops set ShopName = @name where ShopID = @id;", conn);
            }

            update.Parameters.AddWithValue("@id", model.ID);
            update.Parameters.AddWithValue("@name", model.Name);

            conn.Open();

            try
            {
                update.ExecuteNonQuery();
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
