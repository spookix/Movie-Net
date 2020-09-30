using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.UI.ViewModel.Users;
using MovieNet.UI.ViewModel.Movies;
using MovieNet.Models;
using System.Collections.ObjectModel;
using MovieNet.Data;
using System.Windows.Controls;
using System.Windows;
using MovieNet.Models.DAO;

namespace MovieNet.UI
{
    public class MainViewModel : ViewModelBase
    {
        DataModelContainer ctx = new DataModelContainer();
        User user = new User();
        Movie currentMovie = new Movie();

        private ViewModelBase _currentViewModel;
        static UserModel _UserModel;
        static UserModifModel _UserModifModel;
        static MovieModel _MovieModel;
        static MovieAjouterModel _MovieAjouterModel;
        public RelayCommand UserCommand { get; }
        public RelayCommand UserModifCommand { get; }
        public RelayCommand MovieCommand { get; }
        public RelayCommand<SelectionChangedEventArgs> MySelectItem { get; }
        public RelayCommand<SelectionChangedEventArgs> MySelectItemMenu { get; }
        public RelayCommand AddMovieCommand { get; }


        //selected Movie
        public int CurrentMovieId
        {
            get { return currentMovie.Id; }
            set {
                currentMovie.Id = value;
                RaisePropertyChanged("CurrentMovieId");
            }
        }
        public  string CurrentMovieTitre
        {
            get { return currentMovie.Titre; }
            set {
                currentMovie.Titre = value;
                RaisePropertyChanged("CurrentMovieTitre");
            }
        }
        public string CurrentMovieGenre
        {
            get { return currentMovie.Genre; }
            set
            {
                currentMovie.Genre = value;
                RaisePropertyChanged("CurrentMovieGenre");
            }
        }
        public string CurrentMovieResume
        {
            get { return currentMovie.Resume; }
            set
            {
                currentMovie.Resume = value;
                RaisePropertyChanged("CurrentMovieResume");
            }
        }
        public double CurrentMovieMoyenne
        {
            get { return currentMovie.Moyenne; }
            set
            {
                currentMovie.Moyenne = value;
                RaisePropertyChanged("CurrentMovieMoyenne");
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        //utilisateur connecte
        public bool UserConnect
        {
            get { return isConnect(); }
            set
            {
                UserConnect = value;
                RaisePropertyChanged("UserConnect");
            }
        }

        public MainViewModel()
        {
            _UserModel = new UserModel();
            _UserModifModel = new UserModifModel();
            _MovieModel = new MovieModel();
          //  _MovieAjouterModel = new MovieAjouterModel();
            CurrentViewModel = MainViewModel._MovieModel;
            UserCommand = new RelayCommand(() => ExecuteUserCommand());
            UserModifCommand = new RelayCommand(() => ExecuteUserModifCommand());
            MovieCommand = new RelayCommand(() => ExecuteMovieCommand());
            MySelectItem = new RelayCommand<SelectionChangedEventArgs>(ExecuteMovieDetailCommand);
            MySelectItemMenu = new RelayCommand<SelectionChangedEventArgs>(ExecuteMenuCommand); 
             AddMovieCommand = new RelayCommand(()=> ExecuteAddMovieCommand());
        }


        private void ExecuteMovieDetailCommand(SelectionChangedEventArgs e)
        {

            List<Movie> movies = new List<Movie>();
            foreach (Movie m in e.AddedItems)
            {
                movies.Add(m);
                Console.WriteLine(m.Titre);
            }
            if (movies.Count > 0)
            {
                Movie m = movies[0];

          //      MessageBox.Show("ID = " + m.Id + "\nTitre = " + m.Titre + "\nGenre = " + m.Genre + "\nResume = " + m.Resume + "\nMoyenne = " + m.Moyenne);
                // Application.Current.Resources["vmmovie"]
                CurrentMovieId = m.Id;
                CurrentMovieTitre = m.Titre;
                CurrentMovieGenre = m.Genre;
                CurrentMovieMoyenne = m.Moyenne;
                CurrentMovieResume = m.Resume;
            }
        }

        private void ExecuteMenuCommand(SelectionChangedEventArgs e)
        {
            List<ListBoxItem> myArrayStr = new List<ListBoxItem>();
            foreach (ListBoxItem listItem in e.AddedItems)
            {
                ListBoxItem l = listItem;
                
                myArrayStr.Add(l);
            }
            if(myArrayStr.Count()>0)
            {
                MessageBox.Show(((ListBoxItem)myArrayStr[0]).ToString());
            }
        }

        private void ExecuteUserCommand()
        {
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
                CurrentViewModel = MainViewModel._UserModifModel;
            else
                CurrentViewModel = MainViewModel._UserModel;
        }

        private void ExecuteUserModifCommand()
        {
            CurrentViewModel = MainViewModel._UserModifModel;
        }

        private void ExecuteMovieCommand()
        {
           
            CurrentViewModel = MainViewModel._MovieModel;
        }

        ObservableCollection<Movie> sampleData = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> SampleData
        {
            get
            {
                Facade facade = Facade.getInstance();
                Movie[] movies = facade.getMovies();
                sampleData.Clear();
                foreach (Movie m in movies)
                {
                    sampleData.Add(m);
                }               
               
                return sampleData;
            }
        }
        
        private void ExecuteAddMovieCommand()
        {
            CurrentViewModel = MainViewModel._MovieAjouterModel;
        }

        private bool CanExecuteAddMovieCommand()
        {
            UserDao userDao = new UserDao();
            List<User> Liste = userDao.findAll();
            Console.WriteLine("CanExecuteAddMovieCommand");
            var utilisateur = Liste.Where(u => u.Connected == true).ToList();
            if (utilisateur.Count > 0)
                return false;
            else
                return true;

        }

        private bool isConnect()
        {
            UserDao userDao = new UserDao();
            List<User> Liste = userDao.findAll();
            Console.WriteLine("CanExecuteAddMovieCommand");
            var utilisateur = Liste.Where(u => u.Connected == true).ToList();
            return utilisateur.Count > 0;
        }
    }

}
