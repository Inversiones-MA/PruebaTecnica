using System;
using System.Collections.Generic;
using System.Linq;


namespace ApplicationCore.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        public string? Run { get; set; }

        public int RunBody { get; set; }

        public string RunDigit { get; set; } = null!;

        public string? FullName { get; set; }

        public string Names { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? MotherLastName { get; set; }

        public string? Email { get; set; }

        public short GenderCode { get; set; }

        public DateOnly? BirthDate { get; set; }

        public short? RegionCode { get; set; }

        public short? CityCode { get; set; }

        public short? CommuneCode { get; set; }

        public string? Address { get; set; }

        public int? Phone { get; set; }

        public string? Observations { get; set; }
    }

}
