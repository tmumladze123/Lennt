using System;
namespace Lennt.Model.Entities
{
	public class VacancyPerson : Base
	{
		public VacancyPerson()
		{

		}
        public VacancyPerson(
            long personId,
            long vacancyId,
            bool isApproved
            ) : this()
        {
            PersonId = personId;
            VacancyId = vacancyId;
            IsApproved = isApproved;

        }
        public long PersonId { get; set; }
        public long VacancyId { get; set; }
        public bool IsApproved { get; set; }
        public virtual Person Person { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}

