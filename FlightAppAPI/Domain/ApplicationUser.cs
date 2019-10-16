using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public abstract class ApplicationUser
    {
        public int ApplicationUserId { get; set; }


        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
    }
}
