using System;
namespace Lennt.Dto.VacancyPerson
{
    public class VacancyPersonDto
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long VacancyId { get; set; }
        public bool IsApproved { get; set; }

    }
}

