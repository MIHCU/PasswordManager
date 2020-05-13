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
    public class ShellViewModel : Conductor<object>, IHandle<ChangeToMainView>, IHandle<ChangeToEntryView>
    {
        private readonly IEventAggregator _eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            ActivateItem(new EntryViewModel(_eventAggregator));
        }

        public void Handle(ChangeToMainView message)
        {
            ActivateItem(new MainViewModel(_eventAggregator));
        }

        public void Handle(ChangeToEntryView message)
        {
            ActivateItem(new EntryViewModel(_eventAggregator));
        }
    }
}
