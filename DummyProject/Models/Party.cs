using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyProject.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PartyType { get; set; }
    }
}
