using MovieNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.UI.ViewModel.Users
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }

        internal static void Save(Person newPerson)
        {

            DataModelContainer ctx = new DataModelContainer();
            User user = new User();
            user.Login = newPerson.Login;
            user.Password = newPerson.Password;

            ctx.UserSet.Add(user);
            //var query = ctx.UserSet.Where(u => u.Login.Contains("i")).ToList();
            var query = ctx.UserSet.ToList();

            ctx.SaveChanges();
        }

        internal static void Modif(User us)
        {

            DataModelContainer ctx = new DataModelContainer();
            User user = new User();
            
            var utilisateur = ctx.UserSet.Where(u => u.Connected == true).ToList();
             if (utilisateur.Count > 0)
            {
                user = ctx.UserSet.Find(utilisateur[0].Id);
                user = utilisateur[0];
                user.Login = us.Login;
                user.Password = us.Password;
                //ctx.UserSet.(user);
                ctx.SaveChanges();
            }
                
        }
    }


}
