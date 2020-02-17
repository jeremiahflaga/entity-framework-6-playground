using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_17
{
	public class Person
	{
		protected Person()
		{
			// protected - for EF use only
			this.PersonDetailOneToManies = new HashSet<PersonDetailOneToMany>();
		}

		public static Person Create(Guid id)
		{
			return new Person
			{
				Id = id,
			};
		}

		public Guid Id { get; protected set; }

		public virtual ICollection<PersonDetailOneToMany> PersonDetailOneToManies { get; protected set; }

		//public virtual PersonDetailOneToMany UniquePersonDetailOneToMany { get; protected set; }
	}
}
