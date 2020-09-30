using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Models;
using MovieNet.Models.DAO;

namespace MovieNet.UI.ViewModel.Users
{
    public class UserModificationModel : ViewModelBase
    {
        DataModelContainer ctx = new DataModelContainer();
        User user = new User();
        private UserDao userDao = null;
        bool onceLogin = false;
        bool oncePwd = false;

        //private readonly Person _newPerson;

        private const string LoginPropertyName = "Bill";
        public string Login
        {
            get
            {
                var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
                if (utilisateur.Count > 0 && !onceLogin)
                {
                    onceLogin = true;
                    return utilisateur[0].Login;
                }
                else
                    return user.Login;
            }
            set
            {
                user.Login = value;
                RaisePropertyChanged(LoginPropertyName);
            }
        }


        private const string PasswordPropertyName = "test";
        public string Password
        {
            get
            {
                var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
                if (utilisateur.Count > 0 && !oncePwd)
                {
                    oncePwd = true;
                    return utilisateur[0].Password;
                }
                else
                    return user.Password;
            }
            set
            {
                user.Password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        public UserModificationModel()
        {
            //_newPerson = new Person();
            CreateSaveCommand();
        }

        public ICommand ModifCommand
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
            ModifCommand = new RelayCommand(ModifExecute, CanExecuteSaveCommand);
        }

        public void ModifExecute()
        {
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
            {
                if (user.Login == null)
                    user.Login = utilisateur[0].Login;
                if (user.Password == null)
                    user.Password = utilisateur[0].Password;
            }
                this.userDao = new UserDao();
                this.userDao.update(user);
            //Person.Modif(user);
        }

    }
}
