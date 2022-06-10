using System;
using System.Collections.Generic;

namespace Lennt.Model.Entities
{
    public class Category
    {
        public Category()
        {
            Persons = new HashSet<Person>();
            Vacancies = new HashSet<Vacancy>();


        }
        public Category(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; private set; }
        public virtual ICollection<Vacancy> Vacancies { get; private set; }

    }
}

