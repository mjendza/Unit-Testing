using System;

namespace Training.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime Modified { get; set; }
    }
}