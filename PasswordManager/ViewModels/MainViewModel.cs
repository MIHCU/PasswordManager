using Caliburn.Micro;
using PasswordManager.Database;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.ViewModels
{
    class MainViewModel : Screen
    {
        private MyRSA rsa;
        private BindableCollection<PasswordModel> _passwords = new BindableCollection<PasswordModel>();

        private PasswordModel _selectedPassword;
        private CategoriesModel _selectedCategorie;

        public static ListOfDatas dataList;
        private readonly IEventAggregator _eventAggregator;
        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            rsa = new MyRSA();
            dataList = new ListOfDatas();
            for (int i = 0; i < dataList.Size(); i++)
            {
                Data temp = dataList.Give(i);
                Passwords.Add(new PasswordModel { password = rsa.Decryption(temp.Password), login = rsa.Decryption(temp.Login), 
                    notes = rsa.Decryption(temp.Notes), tag = rsa.Decryption(temp.Tag) });
            }

        }

        public BindableCollection<PasswordModel> Passwords
        {
            get { return _passwords; }
            set
            {
                _passwords = value;
                NotifyOfPropertyChange(() => Passwords);
            }
        }

       

        public CategoriesModel SelectedCategorie
        {
            get { return _selectedCategorie; }
            set
            {
                _selectedCategorie = value;
                if (SelectedCategorie != null)
                    Passwords = SelectedCategorie.passwords;
                NotifyOfPropertyChange(() => SelectedCategorie);
            }
        }


        public PasswordModel SelectedPassword
        {
            get { return _selectedPassword; }
            set
            {
                _selectedPassword = value;
                NotifyOfPropertyChange(() => SelectedPassword);
            }
        }

        public void CoppyPasswordToClipboard()
        {
            if (_selectedPassword != null)
                Clipboard.SetText(_selectedPassword.password);
        }

        public void CoppyLoginToClipboard()
        {
            if (_selectedPassword != null)
                Clipboard.SetText(_selectedPassword.login);
        }

        public void setSelectedCategory(object item)
        {
            SelectedCategorie = (CategoriesModel)item;
        }

        
        public void DeleteEntry()
        {
            var result = MessageBox.Show("Are you sure that you would like to delete the entry?", "Delete the entry",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Data dataToRemove = new Data(rsa.Encryption(SelectedPassword.login), rsa.Encryption(SelectedPassword.password),
                    rsa.Encryption(SelectedPassword.tag), rsa.Encryption(SelectedPassword.notes));
                dataList.Delete(dataToRemove);
                Passwords.Remove(SelectedPassword);
            }
                
        }
        public void AddEntry()
        {
            _eventAggregator.PublishOnUIThread(new ChangeToEntryView());
        }
    }
}
