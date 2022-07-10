using System;
using System.Collections.Generic;

namespace Lennt.Dto.Vacancy
{
    public class GetMyVacanciesDto
    {
        public GetVacancyDto Vacancy { get; set; }
        public List<VacancyProposalDto> Proposal { get; set; }
    }
}
