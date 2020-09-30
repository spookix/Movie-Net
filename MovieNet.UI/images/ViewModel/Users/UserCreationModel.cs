using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Data;
using MovieNet.Models;
using MovieNet.Models.DAO;

namespace MovieNet.UI.ViewModel.Users
{
    public class UserCreationModel : ViewModelBase
    {
        private readonly Person _newPerson;
        private UserDao userDao = null;
        private User user = new User();

        private const string LoginPropertyName = "Login";
        public string Login
        {
            get { return user.Login; }
            set
            {
                user.Login = value;
                RaisePropertyChanged(LoginPropertyName);
            }
        }

        private const string PasswordPropertyName = "Password";
        public string Password
        {
            get
            {
                return user.Password;
            }
            set
            {
                user.Password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        ///
        /// Initialise une nouvelle instance de la classe UserCreationModel.
        ///
        public UserCreationModel()
        {
            _newPerson = new Person();
            CreateSaveCommand();
        }

        public ICommand SaveCommand
        {
            get;
            internal set;
        }

        private bool CanExecuteSaveCommand()
        {
            return !string.IsNullOrEmpty(Login);
        }

        private void CreateSaveCommand()
        {
            SaveCommand = new RelayCommand(SaveExecute, CanExecuteSaveCommand);
        }

        public void SaveExecute()
        {
            this.userDao = new UserDao();
            this.userDao.create(user);
        }

    }
}
