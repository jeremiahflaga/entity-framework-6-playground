using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_09
{
	public class Person
	{
		protected Person()
		{
			// protected - for EF use only
		}

		public static Person Create(Guid id)
		{
			return new Person
			{
				Id = id,
			};
		}

		public Guid Id { get; protected set; }

		public virtual ICollection<Friendship> Friendships_1 { get; protected set; }
		public virtual ICollection<Friendship> Friendships_2 { get; protected set; }
	}
}
