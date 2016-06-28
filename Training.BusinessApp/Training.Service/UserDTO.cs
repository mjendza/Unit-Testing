using System;
using FluentValidation;

namespace Training.Service
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime Modified { get; set; }

       

    }

    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotNull();
        }
    }
}