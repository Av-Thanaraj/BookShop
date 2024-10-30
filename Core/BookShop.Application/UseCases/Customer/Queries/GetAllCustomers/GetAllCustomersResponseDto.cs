using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersResponseDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }
    }
}
