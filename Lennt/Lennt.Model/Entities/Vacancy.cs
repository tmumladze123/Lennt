using System;
using System.Collections.Generic;

namespace Lennt.Model.Entities
{
    public class Vacancy : Base
    {
        public Vacancy()
        {
            VacancyPersons = new HashSet<VacancyPerson>();
        }
        public Vacancy(
            long createPersonId,
            string createPersonName,
            string title,
            string description,
            bool isFinished,
            bool isDoing,
            int vacancyTypeId,
            int categoryId,
            decimal price,
            string location,
            string duration
            ) : this()
        {
            CreatePersonId = createPersonId;
            CreatePersonName = createPersonName;
            Title = title;
            Description = description;
            IsFinished = isFinished;
            IsDoing = isDoing;
            VacancyTypeId = vacancyTypeId;
            CategoryId = categoryId;
            Price = price;
            Location = location;
            Duration = duration;


        }
        public long CreatePersonId { get; set; }
        public string CreatePersonName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public bool IsDoing { get; set; }
        public int VacancyTypeId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }

        public virtual Category Category { get; set; }
        public virtual VacancyType VacancyType { get; set; }

        public virtual ICollection<VacancyPerson> VacancyPersons { get; private set; }

        public Vacancy AddPerson(params VacancyPerson[] vacancyPerson)
        {

            foreach (var vp in vacancyPerson)
            {
                VacancyPersons.Add(vp);
            }
            return this;
        }
    }
}