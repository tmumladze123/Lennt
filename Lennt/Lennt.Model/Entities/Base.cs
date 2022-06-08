using System;

namespace Lennt.Model.Entities
{
    public class Base
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
