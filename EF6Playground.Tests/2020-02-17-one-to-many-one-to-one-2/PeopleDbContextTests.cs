using System;
using System.Data.Entity;
using System.Linq;
using Effort;
using Xunit;

namespace EF6Playground.J_2020_02_17_Two.Tests
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
					var personId = Guid.NewGuid();
					var personDetailId = Guid.NewGuid();
					var person = Person.Create(personId);
					person.PersonDetailOneToManies.Add(PersonDetailOneToMany.Create(personDetailId, person));
					context.People.Add(person);
					context.SaveChanges();

					person.PersonDetailId = personDetailId;
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
