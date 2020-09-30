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
    public class UserConnectedModel : ViewModelBase
    {
        DataModelContainer ctx = new DataModelContainer();
        User user = new User();
        private UserDao userDao = null;
        List<User> Liste ;

        bool co = false;
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
                //var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
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
                //var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
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

        private void CanExecuteUserConnect()
        {
            this.userDao = new UserDao();
            Liste = this.userDao.findAll();
            var utilisateur = Liste.Where(u => u.Connected == true).ToList();
            //var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();

            
            if (utilisateur.Count > 0)
            {
                Console.WriteLine("bien co  dans connected");
            }
            else
            {
                Console.WriteLine("Pas Co dans connected");

            }
        }

        public UserConnectedModel()
        {
            CreateCoCommand();
        }

        public ICommand DecoCommand
        {
            get;
            internal set;
        }

        private bool CanExecuteDecoCommand()
        {
            return co;
        }

        private void CreateCoCommand()
        {
            DecoCommand = new RelayCommand(CanExecuteUserConnect, CanExecuteDecoCommand);
        }

        
    }
}
