using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Training.DataAccess;
using Training.Repository;

namespace Training.Service
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        private IEmailService _emailService;

        public UserService(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public UserDTO GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return new UserDTO() {Id=user.Id, Email = user.Email, Modified = user.Modified};
        }

        public UserDTO Save(UserDTO user)
        {
            var validator = new UserValidator();
            var validationresult = validator.Validate(user);
            if (!validationresult.IsValid) return null;
            SendWelcomeEmail(user);
            SetProjectInfoData(user);
            var result = _userRepository.Add(new User() {Email = user.Email, Login = user.Login, Modified = DateTime.Now});
            user.Id = result.Id;
            return user;
        }
        private string SetProjectInfoData(UserDTO user)
        {
            return user.Login+"#;#"+"11"+"#;#"+"ProjName";
        }
        public void SendWelcomeEmail(UserDTO user)
        {
            var message = new EmailDTO();
            message.Body = "Witaj";
            message.Subject = "Witamy w serwisie";
            message.To = user.Email;
            _emailService.SendEmail(message);

        }
    }
}
