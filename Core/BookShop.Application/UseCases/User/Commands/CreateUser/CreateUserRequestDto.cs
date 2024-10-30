using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserRequestDto
    {
        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }
    }
}
