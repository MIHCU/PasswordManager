using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class DatabaseWrap
    {
        SqlConnection connection = null;
        SqlCommand query = null;
        DatabaseWrap()
        {
            ConnectoToDatabase();
        }

        public void AddUser(User newUser)
        {

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

        private void ConnectoToDatabase()
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

        }

        public void ModifyData(int id)
        {

        }
        
        public void DeleteData(int id)
        {

        }

        public ListOfDatas ShowData()
        {

        }

        public Data SearchData(String searchedTag)
        {

        }
    }
}
