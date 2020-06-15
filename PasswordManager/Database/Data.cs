namespace PasswordManager
{
    public class Data
    {
        public string Login;
        public string Password;
        public string Tag;
        public string Notes;

        public Data()
        {
            this.Login = "";
            this.Password = "";
            this.Tag = "";
            this.Notes = "";
        }

        public Data(string Login, string Password, string Tag, string Notes)
        {
            this.Login = Login;
            this.Password = Password;
            this.Tag = Tag;
            this.Notes = Notes;
        }

        public bool Equals(Data dataToCompare)
        {
            if( dataToCompare.Login == this.Login &&
                dataToCompare.Password == this.Password &&
                dataToCompare.Tag == this.Tag &&
                dataToCompare.Notes == this.Notes )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
} 