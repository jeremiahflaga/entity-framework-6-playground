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
		public PeopleDbContext() : base("PeopleDbContext_2020-02-09")
		{
			//Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PeopleDbContext>());
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Friendship> Friendships { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
				.ToTable("Person")
				.HasKey(x => x.Id)				
				;

			//ConfigureFriendshipModel_NoNavigationProperties(modelBuilder);

			//ConfigureFriendshipModel_WithNavigationProperties(modelBuilder);

			ConfigureFriendshipModel_WithNavigationPropertiesAndCollection(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private void ConfigureFriendshipModel_NoNavigationProperties(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Friendship>()
				.ToTable("Friendship")
				.HasKey(x => new { x.Person1Id, x.Person2Id });
		}

		private void ConfigureFriendshipModel_WithNavigationProperties(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Friendship>()
				.ToTable("Friendship")
				.HasKey(x => new { x.Person1Id, x.Person2Id })
				.HasRequired(x => x.PersonOne)
					.WithMany()
					.HasForeignKey(x => x.Person1Id)
					.WillCascadeOnDelete(false);
			modelBuilder.Entity<Friendship>()
				.HasRequired(x => x.PersonTwo)
					.WithMany()
					.HasForeignKey(x => x.Person2Id)
					.WillCascadeOnDelete(false);
		}

		private void ConfigureFriendshipModel_WithNavigationPropertiesAndCollection(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Friendship>()
				.ToTable("Friendship")
				.HasKey(x => new { x.Person1Id, x.Person2Id })
				.HasRequired(x => x.PersonOne)
					.WithMany(x => x.Friendships_1)
					.HasForeignKey(x => x.Person1Id)
					.WillCascadeOnDelete(false);
			modelBuilder.Entity<Friendship>()
				.HasRequired(x => x.PersonTwo)
					.WithMany(x => x.Friendships_2)
					.HasForeignKey(x => x.Person2Id)
					.WillCascadeOnDelete(false);
		}
	}
}
