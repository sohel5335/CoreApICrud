using FriendApi.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FriendApi.DataAccess
{
    public class FriendDA
    {
        string conString = "Data Source=SOHEL\\SOHEL;Initial Catalog=FriendDB;Integrated Security=true;TrustServerCertificate=True";


        private Friend MapObj(SqlDataReader reader)
        {
            Friend friend = new Friend();

            friend.Id = (int)reader["Id"];
            friend.Name = (string)reader["Name"];
            friend.FriendType = (string)reader["FriendType"];
            friend.isClose = (bool)reader["isClose"];
            friend.BirthDate = (DateTime)reader["BirthDate"];
            friend.Gendar = (string)reader["Gendar"];

            return friend;
        }
        

        public Friend Insert(Friend friend) 
        {
            Friend friend1 = new Friend();
            SqlConnection con = null;
            try
            {

                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spFriendIsert",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", friend.Id);
                cmd.Parameters.AddWithValue("@Name", friend.Name);
                cmd.Parameters.AddWithValue("@FriendType", friend.FriendType);
                cmd.Parameters.AddWithValue("@isClose", friend.isClose);
                cmd.Parameters.AddWithValue("@BirthDate", friend.BirthDate);
                cmd.Parameters.AddWithValue("@Gendar", friend.Gendar);
                SqlDataReader reader=  cmd.ExecuteReader();
                if (reader.Read())
                {
                    friend.Id= MapObj(reader).Id;
                    reader.Close();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return friend;
        }

        public string Delete(int id)
        {
            Friend friend1 = new Friend();
            SqlConnection con = null;
            try
            {

                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand($"Delete from Friend where Id={id}", con);
              
                cmd.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return "Delet Done";
        }

        public Friend Get(int id)
        {
            Friend friend1 = new Friend();
            SqlConnection con = null;
            try
            {

                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand($"select * from Friend where Id={id}", con);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    friend1 = MapObj(reader);
                    reader.Close();
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return friend1;
        }
    }
}
