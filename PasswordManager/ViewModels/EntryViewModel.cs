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
            //MessageBox.Show(Login + Password);
            _eventAggregator.PublishOnUIThread(new ChangeToMainView());
        }
    }
}
