using MovieNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieNet.UI.Views.Users
{
    /// <summary>
    /// Logique d'interaction pour UserConnectedView.xaml
    /// </summary>
    public partial class UserConnectedView : UserControl
    {
        DataModelContainer ctx = new DataModelContainer();
        public User user = new User();

        public UserConnectedView()
        {
            InitializeComponent();
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true ).ToList();
            ctx.SaveChanges();
        }

        private void Button_Unlog(object sender, RoutedEventArgs e)
        {
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();

            //ctx.SaveChanges();

            if (utilisateur.Count > 0)
            //if ((Login.Text == "Bill") & (Password.Password == "test"))
            //if ((ctx.UserSet.Where(u => u.Login.Contains(Login.Text)).Where(u => u.Password.Contains(Password.Password)) )
            {
                Console.WriteLine("Déco");
                user = utilisateur[0];
                ctx.UserSet.Find(user.Id).Connected = false;
                ctx.SaveChanges();

            }
            else
            {
                Console.WriteLine("Pas Co dans connected");

            }
        }
    }
}
