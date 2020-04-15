namespace PasswordManager
{
    internal class Data
    {
        private string Login;
        private string Password;
        private string Tag;
        private string Notes;

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