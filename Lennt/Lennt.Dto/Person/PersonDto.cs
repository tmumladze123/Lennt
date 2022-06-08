﻿using System;

namespace Lennt.Dto.Person
{
    public class PersonDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        //public int? Review { get; set; }
        //public int ReviewCount { get; set; }
    }
}
