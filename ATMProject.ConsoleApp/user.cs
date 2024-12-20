using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.ConsoleApp
{
    internal class user
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "192.168.0.184",
            InitialCatalog = "ZMK_ATMProject",
            UserID = "thetys",
            Password = "P@ssw0rd",
            TrustServerCertificate = true
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open");

            string query = "select * from Tbl_User";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("User ID: " + dr["UserId"]);
                Console.WriteLine("User Name: " + dr["UserName"]);
                Console.WriteLine("Password: " + dr["Password"]);
                Console.WriteLine("Balance: " + dr["Balance"]);
                Console.WriteLine("Active Flag: " + dr["ActiveFlag"]);
                Console.WriteLine("Created Date: " + dr["CreatedDate"]);
                Console.WriteLine("Updated Date: " + dr["UpdatedDate"]);
                Console.WriteLine(new string('-', 50));
            }
        }

        public void Create(string userName, string password, decimal balance, bool activeFlag,  DateTime createdDate, DateTime updatedDate)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_User]
           ([UserName]
           ,[Password]
           ,[Balance]
           ,[ActiveFlag]
           ,[CreatedDate]
           ,[UpdatedDate])
     VALUES
           (@UserName,
           @Password,
           @Balance,
           @ActiveFlag,
           @CreatedDate,
           @UpdatedDate)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Balance", balance);
            cmd.Parameters.AddWithValue("@ActiveFlag", activeFlag);
            cmd.Parameters.AddWithValue("@CreatedDate", createdDate);
            cmd.Parameters.AddWithValue("@UpdatedDate", updatedDate);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
