using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_09
{
	public class Friendship
	{
		protected Friendship()
		{
			// protected - for EF use only
		}

		public static Friendship Create(Guid personId1, Guid personId2)
		{
			return new Friendship
			{
				Person1Id = personId1,
				Person2Id = personId2,
			};
		}

		public Guid Person1Id { get; protected set; }
		public Guid Person2Id { get; protected set; }

		public virtual Person PersonOne { get; protected set; }
		public virtual Person PersonTwo { get; protected set; }
	}
}
