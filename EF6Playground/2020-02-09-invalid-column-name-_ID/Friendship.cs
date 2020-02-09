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

		public Guid Person1Id { get; set; }
		public Guid Person2Id { get; set; }

		public virtual Person Person1 { get; set; }
		public virtual Person Person2 { get; set; }
	}
}
