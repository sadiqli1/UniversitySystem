using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Librarian: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime Birthday { get; set; }
        public int PersonalNumber { get; set; }
        public string Mail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
