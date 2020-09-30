using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Data;
using MovieNet.Models;
using MovieNet.Models.DAO;

namespace MovieNet.UI.ViewModel.Movies
{
    public class MovieModel : ViewModelBase
    {
        DataModelContainer ctx = new DataModelContainer();
        Movie movie = new Movie();
        private MovieDao movieDAO = null;
        List<Movie> Liste;

        private ViewModelBase _currentViewModel;
        static MovieConsultationModel _movieConsultationModel;
        static MovieCreationModel _movieCreationModel;

        public RelayCommand ConsultationViewCommand { get; }
        public RelayCommand CreationViewCommand { get; }
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

        public MovieModel()
        {
            _movieConsultationModel = new MovieConsultationModel();
            _movieCreationModel = new MovieCreationModel();

            CurrentViewModel = MovieModel._movieConsultationModel;
            ConsultationViewCommand = new RelayCommand(() => ExecuteConsultationViewCommand());
            CreationViewCommand = new RelayCommand(() => ExecuteCreationViewCommand());


        }

        private void ExecuteConsultationViewCommand()
        {
            CurrentViewModel = MovieModel._movieConsultationModel;
        }

        private void ExecuteCreationViewCommand()
        {
            CurrentViewModel = MovieModel._movieCreationModel;
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

       
        public ObservableCollection<string> MenuData
        {
            get
            {

                string[] array_str = { "Ajout", "Consultation" };
                MenuData.Clear();
                foreach (string str in array_str)
                {
                    MenuData.Add(str);
                }

                return MenuData;
            }
        }


        public ObservableCollection<MenuItem> SideBar
        {
            get
            {

                SideBar.Clear();
                SideBar.Add(new MenuItem(0,"Consultation"));
                SideBar.Add(new MenuItem(1, "Ajouter un film"));
                return SideBar;
            }
        }
    }
}
