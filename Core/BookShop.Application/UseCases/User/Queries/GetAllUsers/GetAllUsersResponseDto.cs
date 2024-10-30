using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.User.Queries.GetAllUsers
{
    public class GetAllUsersResponseDto
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? CreatedDate { get; set; }

        public string? LastLogin { get; set; }
    }
}
