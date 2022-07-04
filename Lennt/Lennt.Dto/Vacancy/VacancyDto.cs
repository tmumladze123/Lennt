using System;
namespace Lennt.Dto.Vacancy
{
	public class VacancyDto
	{
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int VacancyTypeId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }

    }
}

