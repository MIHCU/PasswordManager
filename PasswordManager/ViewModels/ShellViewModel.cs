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
    public class ShellViewModel : Conductor<object>
    {
        
        public ShellViewModel()
        {
            ActivateItem(new MainViewModel());
        }
    }
}
