using System;
namespace Lennt.Dto.Person
{
	public class PersonWithIdDto
	{
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
    }
}

