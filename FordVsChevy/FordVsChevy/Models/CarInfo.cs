using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FordVSChevy.Models
{
    public class CarInfo
    {
        public int CarInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CarPref { get; set; }
        public int? NumberCars { get; set; }
        public string PhoneNumber { get; set; }
        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }

    }
}
