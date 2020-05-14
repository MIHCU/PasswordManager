using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.ViewModels
{
    class EntryViewModel : Screen
    {
        private string _ligin;
        private string _password;
        private string _tag;
        private string _notes;
        private Data dataToAdd;
        private DatabaseWrap database;
        private readonly IEventAggregator _eventAggregator;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }


        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Login
        {
            get { return _ligin; }
            set { _ligin = value; }
            
        }

        public EntryViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public EntryViewModel()
        {

        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(_notes) && !string.IsNullOrEmpty(_ligin) && !string.IsNullOrEmpty(_password) && !string.IsNullOrEmpty(_tag))
            {
                dataToAdd = new Data(_ligin, _password, _tag, _notes);
                AddToDatabase(dataToAdd);
                _eventAggregator.PublishOnUIThread(new ChangeToMainView());
            }
            else if (string.IsNullOrEmpty(_notes) || string.IsNullOrEmpty(_ligin) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_tag))
            {
                MessageBox.Show("Musisz podać wszystkie dane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //MessageBox.Show(Login + Password);
            
        }

        private void AddToDatabase(Data dataToAdd)
        {
            database = new DatabaseWrap();
            database.AddData(dataToAdd);
        }

    }
}
