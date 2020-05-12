using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class CategoriesModel
    {
        private string name;
        private CategoriesModel parent = null;
        private ObservableCollection<CategoriesModel> categories { get; set; }
        public CategoriesModel()
        {
            this.Categories = new ObservableCollection<CategoriesModel>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public CategoriesModel Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public ObservableCollection<CategoriesModel> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                Parent = this;
            }
        }

        public BindableCollection<PasswordModel> passwords { get; set; }
       
    }
}
