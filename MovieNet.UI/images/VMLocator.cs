using MovieNet.UI.ViewModel.Users;
using MovieNet.UI.ViewModel.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Models;

namespace MovieNet.UI
{
    public class VMLocator
    {
        public static MainViewModel MainVM { get; } = new MainViewModel();

        public static UserModel UserVM { get; } = new UserModel();

        public static MovieModel MovieVM { get; } = new MovieModel();
    }
}
