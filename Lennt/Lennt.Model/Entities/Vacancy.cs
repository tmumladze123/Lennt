using System;
namespace Lennt.Model.Entities
{
    public class Vacancy : Base
    {
        public Vacancy(
            string title,
            string description,
            bool isFinished,
            bool isApplied,
            bool isDoing,
            int vacancyTypeId,
            int categoryId,
            decimal price,
            string location,
            string duration
            )
        {
            Title = title;
            Description = description;
            IsFinished = isFinished;
            IsApplied = isApplied;
            IsDoing = isDoing;
            VacancyTypeId = vacancyTypeId;
            CategoryId = categoryId;
            Price = price;
            Location = location;
            Duration = duration;


        }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public bool IsApplied { get; set; }
        public bool IsDoing { get; set; }//?
        public int VacancyTypeId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }

        public virtual Category Category { get; set; }
        public virtual VacancyType VacancyType { get; set; }


    }
}