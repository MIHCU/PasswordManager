namespace PasswordManager
{
    internal class Data
    {
        public string Login;
        public string Password;
        public string Tag;
        public string Notes;

        public Data(string Login, string Password, string Tag, string Notes)
        {
            this.Login = Login;
            this.Password = Password;
            this.Tag = Tag;
            this.Notes = Notes;
        }

        public Data(string Login, string Password, string Tag)
        {
            this.Login = Login;
            this.Password = Password;
            this.Tag = Tag;
        }
    }
}