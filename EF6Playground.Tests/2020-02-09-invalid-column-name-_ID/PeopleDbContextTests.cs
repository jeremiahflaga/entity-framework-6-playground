using System;
using System.Data.Entity;
using System.Linq;
using EF6Playground.J_2020_02_09;
using Effort;
using Xunit;

namespace EF6Playground.Tests
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
					context.People.RemoveRange(context.People);
					context.Friendships.RemoveRange(context.Friendships);
					context.SaveChanges();

					var person1 = Person.Create(Guid.NewGuid());
					var person2 = Person.Create(Guid.NewGuid());

					context.People.Add(person1);
					context.People.Add(person2);
					context.Friendships.Add(Friendship.Create(person1.Id, person2.Id));
					context.SaveChanges();

					var result = context.Friendships.ToList();
					var people = context.People.ToList();
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
