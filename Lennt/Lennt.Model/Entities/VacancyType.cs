using System;
using System.Collections.Generic;

namespace Lennt.Model.Entities
{
	public class VacancyType
	{
        public VacancyType()
        {
            Vacancies = new HashSet<Vacancy>();

        }
        public VacancyType(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
		public string Name { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; private set; }

    }
}

