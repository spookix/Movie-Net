
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class UserModel : ViewModelBase
    {

        DataModelContainer ctx = new DataModelContainer();
        User user = new User();
        private UserDao userDao = null;
        List<User> Liste;

        private ViewModelBase _currentViewModel;
        static UserConsultationModel _userConsultationModel;
        static UserCreationModel _userCreationModel;
        static UserModificationModel _userModidicationModel;
        static UserConnexionModel _userConnexionModel;
        static UserConnectedModel _userConnectedModel;

        public RelayCommand ConsultationViewCommand { get; }
        public RelayCommand CreationViewCommand { get; }
        public RelayCommand ModificationViewCommand { get; }
        public RelayCommand ConnexionViewCommand { get; }
        public RelayCommand ConnectedViewCommand { get; }
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
       

        public UserModel()
        {
            
            _userConsultationModel = new UserConsultationModel();
            _userCreationModel = new UserCreationModel();
            _userModidicationModel = new UserModificationModel();
            _userConnexionModel = new UserConnexionModel();
            _userConnectedModel = new UserConnectedModel();

            CurrentViewModel = UserModel._userConnexionModel;
            ConsultationViewCommand = new RelayCommand(() => ExecuteConsultationViewCommand());
            CreationViewCommand = new RelayCommand(() => ExecuteCreationViewCommand());
            ModificationViewCommand = new RelayCommand(() => ExecuteModifcationViewCommand());
            ConnexionViewCommand = new RelayCommand(() => ExecuteConnexionViewCommand());
            ConnectedViewCommand = new RelayCommand(() => ExecuteConnectedViewCommand());

            
        }

        private void ExecuteCreationViewCommand()
        {
            CurrentViewModel = UserModel._userCreationModel;
        }

        private void ExecuteConsultationViewCommand()
        {
            CurrentViewModel = UserModel._userConsultationModel;
        }
        private void ExecuteModifcationViewCommand()
        {
            CurrentViewModel = UserModel._userModidicationModel;
        }
        private void ExecuteConnexionViewCommand()
        {
            
            CreateSaveCommand();
            Connected();
            if (co)
            {
                CurrentViewModel = UserModel._userConnectedModel;
            }
            else
                CurrentViewModel = UserModel._userConnexionModel;

        }
        private void ExecuteConnectedViewCommand()
        {
            //Console.WriteLine( "ici!");
            //Console.WriteLine(CanExecuteUserConnect(Login,Password));
            CurrentViewModel = UserModel._userConnectedModel;
            
        }

        //private readonly Person _newPerson;
        private string _Login = "";
        public string Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                RaisePropertyChanged(_Login);
            }
        }

        private string _Password = "";
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                RaisePropertyChanged(_Password);
            }
        }

        public ICommand ConnectUser
        {
            get;
            internal set;
        }

        private bool CanExecuteUserConnect(string Login, string Password)
        {
            var utilisateur = ctx.UserSet.Where(u => u.Login == Login && u.Password == Password).ToList();

            ctx.SaveChanges();

            if (utilisateur.Count > 0)
            //if ((Login.Text == "Bill") & (Password.Password == "test"))
            //if ((ctx.UserSet.Where(u => u.Login.Contains(Login.Text)).Where(u => u.Password.Contains(Password.Password)) )
            {
                Console.WriteLine("Co dans Model");


                return true;
            }
            else
            {
                Console.WriteLine("Pas Co dans Model");
                return false;
            }
        }
        private bool CanExecuteSaveCommand()
        {
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
                return false;
            else
                return true;
        }

        public ICommand SaveCommand
        {
            get;
            internal set;
        }

        private void CreateSaveCommand()
        {
            SaveCommand = new RelayCommand(ExecuteConnectedViewCommand, CanExecuteSaveCommand);
        }

        bool co = false;
        public  void Connected()
        {
            this.userDao = new UserDao();
            Liste = this.userDao.findAll();
            var utilisateur = Liste.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
            {
                co = true;
            }

            else
            {
                co = false;
            }
            
        }

        string login;

        private string _bienvenue = "Bienvenue ";
        private string _bye = "Vous avez saisi un mauvais identifiant ou mot de passe";
        private string _nada = "";
        public string Bienvenue
        {

            get
            {
                this.userDao = new UserDao();
                Liste = this.userDao.findAll();
                login = "";
                _bienvenue = "Bienvenue ";

                var utilisateur = Liste.Where(u => u.Connected == true).ToList();
                if (utilisateur.Count > 0)
                {
                    co = true;
                    login = utilisateur[0].Login;
                    _bienvenue += login;
                    return _bienvenue;
                }

                else
                {
                    co = false;
                    return _nada;
                }
            }
            set
            {
                _bienvenue = value;
            }
        }

        public string Bye
        {
            get
            {
                this.userDao = new UserDao();
                Liste = this.userDao.findAll();
                var utilisateur = Liste.Where(u => u.Connected == true).ToList();
                if (utilisateur.Count > 0)
                {
                    co = true;
                    return _nada;
                }

                else
                {
                    co = false;
                    return _bye;
                }
            }
            set
            {
                _bye = value;
            }
        }
    }
}
