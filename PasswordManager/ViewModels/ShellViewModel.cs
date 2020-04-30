using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xunit.Sdk;
using PasswordManager.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PasswordManager.ViewModels
{
    public class ShellViewModel : Screen
    {
        private BindableCollection<PasswordModel> _passwords = new BindableCollection<PasswordModel>();
        private ObservableCollection<CategoriesModel> _categories = new ObservableCollection<CategoriesModel>();
        private PasswordModel _selectedPassword;
        private CategoriesModel _selectedCategorie;
        private BindableCollection<PasswordModel> asdf = new BindableCollection<PasswordModel>();
        public ShellViewModel()
        {
            Passwords.Add(new PasswordModel { password = "password1", login = "asdf", notes = "notes1", tag = "hello" });
            Passwords.Add(new PasswordModel { password = "password2", login = "log1", notes = "dagjhafgjhjkdfg", tag = "dsaasdasasdf" });
            Passwords.Add(new PasswordModel { password = "password3", login = "emil", notes = "124325", tag = "adsfasdf" });
            asdf.Add(new PasswordModel { password = "ccc", login = "cos", notes = "i", tag = "qwer" });
            asdf.Add(new PasswordModel { password = "password7", login = "ktos", notes = "asdasdasd", tag = "ppp" });

            Categories.Add(new CategoriesModel() { Name = "root" });
            CategoriesModel childCategory = new CategoriesModel() { Name = "cos" };
            CategoriesModel root = new CategoriesModel() { Name = "root" };
            childCategory.Categories.Add(new CategoriesModel() { Name = "ktos", passwords = Passwords});
            childCategory.Categories.Add(root);
            childCategory.passwords = asdf;
            Categories.Add(childCategory);
            Categories.Add(childCategory);
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

        public ObservableCollection<CategoriesModel> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public CategoriesModel SelectedCategorie
        {
            get { return _selectedCategorie; }
            set
            {
                _selectedCategorie = value;
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
            if(_selectedPassword != null)
            Clipboard.SetText(_selectedPassword.login);
        }

        public void SayHello(object asd)
        {
            SelectedCategorie = (CategoriesModel)asd;
        }
    }
}
