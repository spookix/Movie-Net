using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieNet.UI.ViewModel.Movies
{
    public class MovieAjouterModel : ViewModelBase
    {
        static MovieModel _MovieModel;
        private ViewModelBase _currentViewModel;
        private Movie movie = new Movie();
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
        public RelayCommand MovieCommand { get; }

        public MovieAjouterModel()
        {
            CurrentViewModel = MovieAjouterModel._MovieModel;
         //   MovieCommand = new RelayCommand(() => ExecuteMovieCommand());
          
        }

       

      
    }
}
