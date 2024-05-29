using IrregularVerbTrainer.Commands;
using IrregularVerbTrainer.DataAccess.Models;
using IrregularVerbTrainer.Views;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace IrregularVerbTrainer.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private readonly Command okCommand;
        private Window window;
        private string name = "";

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand OkCommand => okCommand;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
       

        public LoginViewModel(Window window)
        {
            this.window = window;
            okCommand = new DelegateCommand(_ => Ok());
        }

        private bool CanOk()
        {
            if (name.Length < 2)
            {
                MessageBox.Show("Короткое имя!");
                name = "";
                return false;
            }
            return true;
        }

        private void Ok()
        {
            if (!CanOk()) return;
            IrregularVerbCollection verbsCollection = App.GetIreggularVerbs(name);
            File.Create(App.sessionPath).Close();
            File.AppendAllText(App.sessionPath, name);
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(verbsCollection, mainWindow, name);
            mainWindow.Show();
            window.Close();
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
