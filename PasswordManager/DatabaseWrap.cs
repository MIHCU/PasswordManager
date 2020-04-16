using System;
using System.Data.SqlClient;

namespace PasswordManager
{
    internal class DatabaseWrap
    {
        private SqlConnection connection = null;
        private SqlCommand query = null;

        private DatabaseWrap()
        {
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

        private Data Encrypt(Data dataToEncrypt)
        {
            //TODO
        }

        private Data Decrypt(Data dataToDecrypt)
        {
            //TODO
        }

        private void ConnectToDatabase()
        {
            connection = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
            connection.Open();
        }

        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        private SqlDataReader SendQuery(string queryText)
        {
            query = new SqlCommand(queryText, connection);
            return query.ExecuteReader();
        }

        public void AddData(Data newData)
        {
            string query;
        }

        public void ModifyData(int id)
        {
            string query;
        }

        public void DeleteData(int id)
        {
            string query;
        }

        public ListOfDatas ShowData()
        {
            ListOfDatas list = new ListOfDatas();
            string query = "SELECT login, pass, tag, notes FROM dbo.data;";
            SqlDataReader response = SendQuery(query);
            while (response.HasRows)
            {
                list.Add(new Data(response.GetString(0), response.GetString(1), response.GetString(2), response.GetString(3)));
                response.NextResult();
            }
            response.Close();
            return list;
        }

        public ListOfDatas SearchData(String searchedTag)
        {
            string query = "SELECT login, pass, tag, notes FROM dbo.data WHERE tag ='"+ searchedTag +"';";
            ListOfDatas list = new ListOfDatas();
            SqlDataReader response = SendQuery(query);
            while (response.HasRows)
            {
                list.Add(new Data(response.GetString(0), response.GetString(1), response.GetString(2), response.GetString(3)));
                response.NextResult();
            }
            response.Close();
            return list;
        }
    }
}