using PasswordManager.Database;
using System;
using System.Data.SqlClient;
using System.Numerics;
using System.Windows;

namespace PasswordManager
{
    internal class DatabaseWrap
    {
        private SqlConnection connection = null;
        private MyRSA rsa;

        public DatabaseWrap()
        {
            rsa = new MyRSA();
            ConnectToDatabase();
        }

        public void AddUser(User newUser)
        {
            string query;
        }

        public bool VerifyUser(User user)
        {
            return false;
        }

       
        private void ConnectToDatabase()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\OneDrive\Projekty\PasswordManager\PasswordManager\Database\Database1.mdf;Integrated Security=True");
            connection.Open();
           
        }

        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        private SqlDataReader SendQuery(string queryText)
        {
            SqlCommand query = new SqlCommand(queryText, connection);
            return query.ExecuteReader();
        }

        public void AddData(Data newData)
        {
           
            Data encrpytedData = new Data(rsa.Encryption(newData.Login), rsa.Encryption(newData.Password), rsa.Encryption(newData.Tag), rsa.Encryption(newData.Notes));
            string query = "INSERT INTO Data (login, password, tag, notes) " +
                "values('"+ encrpytedData.Login +"', '"+ encrpytedData.Password + "', '"+ encrpytedData.Tag +"', '" + encrpytedData.Notes +"')";
            SendQuery(query);
        }

        public void ModifyData(int id)
        {
            string query;
        }

        public void DeleteData(Data dataToDelete)
        {
            
            string query = "DELETE FROM Data WHERE Tag = '" + rsa.Encryption(dataToDelete.Tag) + "';";
            SendQuery(query);
        }


        public ListOfDatas GetData()
        {
            ListOfDatas list = new ListOfDatas();
            string query = "SELECT login, password, tag, notes FROM dbo.Data;";
            SqlDataReader response = SendQuery(query);
            if (response.HasRows)
            {
                while (response.Read())
                    list.Add(new Data(response.GetString(response.GetOrdinal("login")), response.GetString(response.GetOrdinal("password")),
                        response.GetString(response.GetOrdinal("tag")), response.GetString(response.GetOrdinal("notes"))));
            }
            response.Close();
            return list;
        }

        public ListOfDatas SearchData(String searchedTag)
        {
            string query = "SELECT login, password, tag, notes FROM dbo.data WHERE tag ='"+ searchedTag +"';";
            ListOfDatas list = new ListOfDatas();
            SqlDataReader response = SendQuery(query);
            if (response.HasRows)
            {
                while(response.Read())
                list.Add(new Data(response.GetString(response.GetOrdinal("login")), response.GetString(response.GetOrdinal("password")),
                    response.GetString(response.GetOrdinal("tag")), response.GetString(response.GetOrdinal("notes"))));
            }
            response.Close();
            return list;
        }

       

    }
}