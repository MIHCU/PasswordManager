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
        public CategoriesModel()
        {
            this.Categories = new ObservableCollection<CategoriesModel>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ObservableCollection<CategoriesModel> Categories { get; set; }
        public BindableCollection<PasswordModel> passwords { get; set; }
       
    }
}
