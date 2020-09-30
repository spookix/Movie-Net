using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Models;
using MovieNet.Models.DAO;

namespace MovieNet.UI.ViewModel.Users
{
    public class UserConnexionModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
       
        static UserConnectedModel _userConnectedModel;

        public RelayCommand ConnexionViewCommand { get; }
        public RelayCommand ConnectedViewCommand { get; }

        private UserDao userDao = null;
        List<User> Liste;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public UserConnexionModel()
        {
            //_newPerson = new Person();
           // _userConnectedModel = new UserConnectedModel();

            
            //ConnectedViewCommand = new RelayCommand(() => ExecuteConnectedViewCommand());
            CreateSaveCommand();

            //_newPerson = new Person();
            //CreateConnectUser();
        }

        private void ExecuteConnectedViewCommand()
        {
            CurrentViewModel = UserConnexionModel._userConnectedModel;
        }


        DataModelContainer ctx = new DataModelContainer();
        User user = new User();

        private readonly Person _newPerson;

       private const string LoginPropertyName = "Bill";
       public string Login
       {
           get
           {
               return _newPerson.Login;
           }
           set
           {
               _newPerson.Login = value;
               RaisePropertyChanged(LoginPropertyName);
           }
       }

       
        private const string PasswordPropertyName = "test";
        public string Password
        {
            get
            {
                return _newPerson.Password;
            }
            set
            {
                _newPerson.Password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        public ICommand SaveCommand
        {
            get;
            internal set;
        }

        private bool CanExecuteSaveCommand()
        {
            this.userDao = new UserDao();
            Liste = this.userDao.findAll();
            var utilisateur = Liste.Where(u => u.Connected == true).ToList();
            //var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
                return false;
            else
                return true;
        }

        private void CreateSaveCommand()
        {
            SaveCommand = new RelayCommand(ExecuteConnectedViewCommand, CanExecuteSaveCommand);
        }

        public void SaveExecute()
        {
            //Person.Save(_newPerson);
            Console.WriteLine("redirige");
        }
        
    }


}
