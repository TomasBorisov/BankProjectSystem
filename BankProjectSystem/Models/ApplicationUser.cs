using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankProjectSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int EGN { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
}
