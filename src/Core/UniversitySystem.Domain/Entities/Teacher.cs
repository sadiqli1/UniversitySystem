﻿using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Teacher: BaseEntity
    {
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string FatherName { get; set; }
        //public DateTime Birthday { get; set; }
        //public int PersonalNumber { get; set; }
        //public string Mail { get; set; }
        //public DateTime RegistrationDate { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public List<Group> Groups { get; set; }
        public List<Lesson> Lessons { get; set; }
        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
