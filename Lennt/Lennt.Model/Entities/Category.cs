using System;
namespace Lennt.Model.Entities
{
	public class Category : Base
	{
		public Category(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

