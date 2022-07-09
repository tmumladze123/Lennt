using System;
using System.Collections.Generic;

namespace Lennt.Dto.Vacancy
{
    public class GetMyVacanciesDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatePersonId { get; set; }
        public string CreatePersonName { get; set; }
        public bool IsFinished { get; set; }
        public bool IsApplied { get; set; }
        public bool IsDoing { get; set; }//?
        public int VacancyTypeId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }
        public List<VacancyProposadDto> Proposal { get; set; }
    }
}
