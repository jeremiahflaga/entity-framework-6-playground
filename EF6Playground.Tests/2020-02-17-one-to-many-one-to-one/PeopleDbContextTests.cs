using System;
using System.Data.Entity;
using System.Linq;
using EF6Playground.J_2020_02_09;
using Effort;
using Xunit;

namespace EF6Playground.J_2020_02_17.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void test_1()
		{
			try
			{
				using (var context = new PeopleDbContext())
				{
					var person = Person.Create(Guid.NewGuid());
					person.PersonDetailOneToManies.Add(PersonDetailOneToMany.Create(Guid.NewGuid(), person));
					context.People.Add(person);
					context.SaveChanges();

					var people = context.People.ToList();
					var details = context.PersonDetailOneToManies.ToList();
				}

			}
			catch (Exception ex)
			{
				var error = ex.InnerException?.Message;
				throw;
			}
		}
	}
}
