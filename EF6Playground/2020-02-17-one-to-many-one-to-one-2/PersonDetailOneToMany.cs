using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_17_Two
{
	public class PersonDetailOneToMany
	{
		protected PersonDetailOneToMany()
		{
			// protected - for EF use only
		}

		public static PersonDetailOneToMany Create(Guid id, Person person)
		{
			return new PersonDetailOneToMany
			{
				Id = id,
				Person = person,
			};
		}

		public Guid Id { get; protected set; }

		public Guid PersonId { get; protected set; }

		public virtual Person Person { get; protected set; }
	}
}
