using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_09
{
	public class PeopleDbContext : DbContext
	{
		public PeopleDbContext() : base("PeopleDbContext")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PeopleDbContext>());
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Friendship> Friendships { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
				.ToTable("Person")
				.HasKey(x => x.Id)				
				;

			modelBuilder.Entity<Friendship>()
				.ToTable("Friendship")
				.HasKey(x => new { x.Person1Id, x.Person2Id })
				.HasRequired(x => x.Person1)
					.WithMany(x => x.Friendships_1)
					.HasForeignKey(x => x.Person1Id)
					.WillCascadeOnDelete(false)
				;
			modelBuilder.Entity<Friendship>()
				.HasRequired(x => x.Person2)
					.WithMany(x => x.Friendships_2)
					.HasForeignKey(x => x.Person2Id)
					.WillCascadeOnDelete(false)
				;

			base.OnModelCreating(modelBuilder);
		}
	}
}
