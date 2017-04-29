using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Data;
using System.Windows.Input;

namespace FL.Modules.FileList
{
    class ViewModel: BindableBase
    {
        private string currentDirectory;
        public string CurrentDirectory
        {
            get { return currentDirectory; }
            set
            {
                currentDirectory = value;
                var entries = Directory.GetFileSystemEntries(currentDirectory);
                this.Entries = new ListCollectionView(entries);
                this.RaisePropertyChanged(nameof(CurrentDirectory));
            }
        }

        private ListCollectionView entries;
        public ListCollectionView Entries
        {
            get { return entries; }
            set
            {
                this.entries = value;
                this.RaisePropertyChanged(nameof(Entries));
            }
        }
        public ICommand MoveCommand
        {
            get;
            private set;
        }

        public ViewModel()
        {
            MoveCommand = new DelegateCommand(() => this.Move());
        }

        protected void Move()
        {
            var path = this.entries.CurrentItem as string;
            if (path == null)
            {
                return;
            }
            if (!Directory.Exists(path))
            {
                return;
            }
            CurrentDirectory = path;
        }
    }
}
