using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Playground.J_2020_02_17
{
	public class PeopleDbContext : DbContext
	{
		public PeopleDbContext() : base("PeopleDbContext_2020-02-17")
		{
		}

		public DbSet<Person> People { get; set; }
		public DbSet<PersonDetailOneToMany> PersonDetailOneToManies { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>()
				.ToTable("Person")
				.HasKey(x => x.Id);

			modelBuilder.Entity<PersonDetailOneToMany>()
				.ToTable("PersonDetailOneToMany")
				.HasKey(x => x.Id)
				;

			modelBuilder.Entity<PersonDetailOneToMany>()
				.HasRequired(x => x.UniquePerson)
				.WithMany()
				.HasForeignKey(x => x.UniquePersonId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
