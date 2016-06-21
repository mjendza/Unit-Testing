using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Training.Repository;
using Training.Service;

namespace Training.BusinessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = CreateKernel();
            var userService = kernel.Get<IUserService>();
            var user = userService.Save(new UserDTO() {Email = "Test@test.pl"});
            var userdb = userService.GetById(user.Id);
            Console.WriteLine(userdb.Email);

        }

        static IKernel CreateKernel()
        {
            // Inicjalizacja kernela
            IKernel ninjectKernel = new StandardKernel();
            // Bindowanie
            ninjectKernel.Bind<IUserService>().To<UserService>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IEmailService>().To<EmailService>();
            return ninjectKernel;
        }
    }
}
