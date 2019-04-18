using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            //1.Display to the console, all the passwords that are "hello".Hint: Where
            var usersWhosePasswordsAreHello = from user in users
                                               where user.Password == "hello"
                                               select user;
            usersWhosePasswordsAreHello.ToList<Models.User>().ForEach(u => { Console.WriteLine(u.Name); });

            //2.Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll
            
            users.Where<Models.User>(u => u.Name.ToLower().Equals(u.Password))
                    .ToList<Models.User>().ForEach(i => i.Password = "");

            //3.Delete the first User that has the password "hello".Hint: First or FirstOrDefault
            var firstUserWithHelloPassword = users.First(u => u.Password.Equals("hello"));
            users.Remove(firstUserWithHelloPassword);

            //4.Display to the console the remaining users with their Name and Password.
            users.ForEach(u => { Console.WriteLine(u.Name + " " + u.Password); });
        }
    }
}
